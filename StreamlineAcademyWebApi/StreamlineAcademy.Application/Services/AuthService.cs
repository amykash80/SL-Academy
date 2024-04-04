using AutoMapper;
using Microsoft.AspNetCore.Identity.Data;
using StreamlineAcademy.Application.Abstractions.Identity;
using StreamlineAcademy.Application.Abstractions.IEmailService;
using StreamlineAcademy.Application.Abstractions.IRepositories;
using StreamlineAcademy.Application.Abstractions.IServices;
using StreamlineAcademy.Application.Abstractions.JWT;
using StreamlineAcademy.Application.Shared;
using StreamlineAcademy.Application.Utils;
using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Domain.Models.Requests;
using StreamlineAcademy.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository authRepository;
        private readonly IUserRepository userRepository;
        private readonly IContextService contextService;
        private readonly IEmailHelperService emailHelperService;
        private readonly IJwtProvider jwtProvider;

        public AuthService(IAuthRepository authRepository,
                           IUserRepository userRepository,
                           IContextService contextService,
                           IEmailHelperService emailHelperService,
                           IJwtProvider jwtProvider)
        {
            this.authRepository = authRepository;
            this.userRepository = userRepository;
            this.contextService = contextService;
            this.emailHelperService = emailHelperService;
            this.jwtProvider = jwtProvider;
        }

        public async Task<ApiResponse<string>> ChangePassword(ChangePasswordRequestModel model)
        { 
            var id = contextService.GetUserId();
            var user=await authRepository.FirstOrDefaultAsync(x=>x.Id == id);
            if (user is null)
                return ApiResponse<string>.ErrorResponse(APIMessages.Auth.UserNotFound, HttpStatusCodes.NotFound);

            if (AppEncryption.ComparePassword(model.OldPassword!, user.Password!, user.Salt!))
                return ApiResponse<string>.ErrorResponse("Old Password is Incorrect", HttpStatusCodes.BadRequest);

            user.Salt = AppEncryption.GenerateSalt();
            user.Password = AppEncryption.CreatePassword(model.NewPassword!, user.Salt);
            int returnVal = await authRepository.UpdateAsync(user);
            if (returnVal > 0)
                return ApiResponse<string>.SuccessResponse(APIMessages.Auth.PasswordChangedSuccess, HttpStatusCodes.OK.ToString());
            return ApiResponse<string>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.InternalServerError);   
        }

        public async Task<ApiResponse<LoginResponseModel>> Login(LoginRequestModel request)
        {
            var user = await authRepository.FirstOrDefaultAsync(x=>x.Email==request.Email);
            if (user is null)
                return ApiResponse<LoginResponseModel>.ErrorResponse(APIMessages.EnquiryManagement.InvalidCredential,HttpStatusCodes.BadRequest);

            var res = AppEncryption.ComparePassword(user.Password!, request.Password!, user.Salt!);
            if(!res)
                return ApiResponse<LoginResponseModel>.ErrorResponse(APIMessages.EnquiryManagement.InvalidCredential, HttpStatusCodes.BadRequest);

            var response = new LoginResponseModel()
            {
                FullName = user.Name,
                UserRole = user.UserRole,
                Token = jwtProvider.GenerateToken(user) 
            };

            return ApiResponse<LoginResponseModel>.SuccessResponse(response,"Successfully Logged In");
        }

		public async Task<bool> IsEmailUnique(string email)
		{
			return await authRepository.FirstOrDefaultAsync(x => x.Email == email) == null;
		}

		public async Task<bool> IsPhoneNumberUnique(string phoneNumber)
		{
			return await authRepository.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber) == null;
		}

        public async Task<ApiResponse<string>> ForgotPassword(ForgotPasswordRequestModel model)
        {
            var user = await userRepository.FirstOrDefaultAsync(user => user.Email == model.Email);
            if (user is null) return ApiResponse<string>.ErrorResponse(APIMessages.Auth.InVaildEmailAddress);
            user.ResetCode = await GenerateConfirmationCode();

            var returnVal=await userRepository.UpdateAsync(user);
            if (returnVal > 0)
            {
              var isEmailSent= await emailHelperService.SendResetPasswordEmail(user.Email!);
                if(isEmailSent) 
             return ApiResponse<string>.SuccessResponse(APIMessages.Auth.CheckEmailToResetPassword);

            }
            return ApiResponse<string>.ErrorResponse(APIMessages.TechnicalError);

        }

        public async Task<ApiResponse<string>> ResetPassword(ResetPasswordRequestModel model)
        {
            var user = await userRepository.FirstOrDefaultAsync(x => x.ResetCode!.Trim() == model.ResetCode!.Trim());

            if (user is null)
                return ApiResponse<string>.ErrorResponse(APIMessages.Auth.LinkExpired, HttpStatusCodes.NotFound);
            user.Salt = AppEncryption.GenerateSalt();
            user.Password = AppEncryption.CreatePassword(model.NewPassword!, user.Salt);
            user.ResetCode = string.Empty;
            int updateResult = await userRepository.UpdateAsync(user);
            if (updateResult > 0)
                return ApiResponse<string>.SuccessResponse(APIMessages.Auth.PasswordResetSuccess);

            return ApiResponse<string>.ErrorResponse(APIMessages.TechnicalError);
        }

        private async Task<string> GenerateConfirmationCode()
        {
            string randomValue = AppEncryption.GetRandomConfirmationCode();

            var user = await userRepository.FirstOrDefaultAsync(x => x.ConfirmationCode == randomValue);
            while (user is not null)
            {
                randomValue = AppEncryption.GetRandomConfirmationCode();
                user = await userRepository.FirstOrDefaultAsync(x => x.ConfirmationCode == randomValue);
            }
            return randomValue;
        }
    }
     
}
