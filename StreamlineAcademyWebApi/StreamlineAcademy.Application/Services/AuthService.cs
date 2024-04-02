﻿using AutoMapper;
using StreamlineAcademy.Application.Abstractions.Identity;
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
        private readonly IMapper mapper;
        private readonly IContextService contextService;
        private readonly IJwtProvider jwtProvider;

        public AuthService(IAuthRepository authRepository, 
                           IMapper mapper, 
                           IContextService contextService,
                           IJwtProvider jwtProvider)
        {
            this.authRepository = authRepository;
            this.mapper = mapper;
            this.contextService = contextService;
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
                return ApiResponse<LoginResponseModel>.ErrorResponse("Invalid credentials", HttpStatusCodes.BadRequest);

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

	}
     
}
