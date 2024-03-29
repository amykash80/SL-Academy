using AutoMapper;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.Cmp;
using StreamlineAcademy.Application.Abstractions.Identity;
using StreamlineAcademy.Application.Abstractions.IEmailService;
using StreamlineAcademy.Application.Abstractions.IRepositories;
using StreamlineAcademy.Application.Abstractions.IServices;
using StreamlineAcademy.Application.Shared;
using StreamlineAcademy.Application.Utils;
using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Domain.Enums;
using StreamlineAcademy.Domain.Models.Requests;
using StreamlineAcademy.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//using static StreamlineAcademy.Domain.Models.Requests.AcademyResponseModel;

namespace StreamlineAcademy.Application.Services
{
    public class AcademyService : IAcademyService
    {
        private readonly IAcademyRepository academyRepository;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IEnquiryService enquiryService;
		private readonly IContextService contextService;
		private readonly IEmailHelperService emailHelperService;

		public AcademyService(IAcademyRepository academyRepository,
                               IMapper mapper ,
                               IUserRepository userRepository ,
                               IEnquiryService enquiryService,
                               IContextService contextService,
                               IEmailHelperService emailHelperService)
        {
            this.academyRepository = academyRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.enquiryService = enquiryService;
			this.contextService = contextService;
			this.emailHelperService = emailHelperService;
		}

        public async Task<ApiResponse<AcademyResponseModel>> GetAcademyById(Guid id)
        {
            var academy = await academyRepository.GetByIdAsync(x => x.Id == id);
            if (academy is null)
                return ApiResponse<AcademyResponseModel>.ErrorResponse(APIMessages.AcademyManagement.AcademyNotFound, HttpStatusCodes.NotFound);

            var responseModel = await academyRepository.GetAcademyById(id);
           
            return ApiResponse<AcademyResponseModel>.SuccessResponse(responseModel);
        }

        public async Task<ApiResponse<IEnumerable<AcademyResponseModel>>> GetAllAcademies()
        {
            var returnVal = await academyRepository.GetAllAcademies();
            if (returnVal is not null)
                return ApiResponse<IEnumerable<AcademyResponseModel>>.SuccessResponse(returnVal.OrderBy(_=>_.AcademyName),$"Found {returnVal.Count()} Academies");
                return ApiResponse<IEnumerable<AcademyResponseModel>>.ErrorResponse(APIMessages.AcademyManagement.AcademyNotFound,HttpStatusCodes.NotFound);
        }

        public async Task<ApiResponse<AcademyResponseModel>> RegisterAcademy(AcademyRequestModel request)
        { 
            var existingAcademy = await academyRepository.GetByIdAsync(x => x.AcademyName == request.AcademyName);
            if (existingAcademy is not  null)
                return ApiResponse<AcademyResponseModel>.ErrorResponse(APIMessages.AcademyManagement.AcademyAlreadyRegistered,HttpStatusCodes.Conflict);

            var existingEmail = await userRepository.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (existingEmail is not null)
              return ApiResponse<AcademyResponseModel>.ErrorResponse(APIMessages.AcademyManagement.AcademyAlreadyRegistered,HttpStatusCodes.Conflict); 

            var user = mapper.Map<User>(request);
            user.Salt = AppEncryption.GenerateSalt();
            user.Password=AppEncryption.CreatePassword(request.Password!,user.Salt);
            user.UserRole = UserRole.AcademyAdmin;
            user.CreatedBy = Guid.Empty;
            user.CreatedDate= DateTime.Now;
            user.ModifiedBy = Guid.Empty;
            user.ModifiedDate= DateTime.Now;
            user.IsActive = true;


            var returnVal = await userRepository.InsertAsync(user); 
            if (returnVal > 0)
            {
                var academy=mapper.Map<Academy>(request);
                academy.Id = user.Id;
                var result = await academyRepository.InsertAsync(academy);
                if (result > 0)
				{
                    var isEmailSent = await emailHelperService.SendRegistrationEmail(user.Email!, user.Name!, user.Password);
					var updateStatusResponse = await academyRepository.UpdateRegistrationStatus(academy.Id, RegistrationStatus.Approved);
                    var res = await academyRepository.GetAcademyById(academy.Id);
                    return ApiResponse<AcademyResponseModel>.SuccessResponse(mapper.Map<AcademyResponseModel>(res)); 
                } 
                return ApiResponse<AcademyResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.BadRequest); 
            }
            return ApiResponse<AcademyResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.BadRequest); 
        }

        public async Task<ApiResponse<AcademyResponseModel>> DeleteAcademy(Guid id)
        {
            var existingAcademy = await academyRepository.GetByIdAsync(x => x.Id == id);

            if (existingAcademy is null)
                return ApiResponse<AcademyResponseModel>.ErrorResponse(APIMessages.AcademyManagement.AcademyNotFound,HttpStatusCodes.NotFound);

            var result = await userRepository.FirstOrDefaultAsync(x => x.Id == existingAcademy.Id);
            result.IsActive = false;
            result.DeletedDate = DateTime.Now;

            if (result is not null )
            {
                int isSoftDelted = await academyRepository.Delete(result);
                if (isSoftDelted > 0)
                {
					var returnVal = await academyRepository.GetAcademyById(existingAcademy.Id);
					return ApiResponse<AcademyResponseModel>.SuccessResponse(returnVal, APIMessages.AcademyManagement.AcademyDeleted);

				}
			} 
            return ApiResponse<AcademyResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.InternalServerError); 
        }
         

        public async Task<ApiResponse<AcademyResponseModel>> UpdateAcademy(AcademyUpdateRequest request)
        {
            var existAcademy = await academyRepository.GetByIdAsync(x => x.Id == request.Id);
            if (existAcademy is null)
                return ApiResponse<AcademyResponseModel>.ErrorResponse(APIMessages.AcademyManagement.AcademyNotFound, HttpStatusCodes.NotFound);

            var academy = new Academy
            {
                Id = existAcademy.Id,
                AcademyName = request.AcademyName,
                AcademyTypeId = request.AcademyTypeId,
                CountryId = request.CountryId,
                StateId = request.StateId,
                CityId = request.CityId
            };
            var updateAcademy = await academyRepository.UpdateAsync(existAcademy);
            if (updateAcademy is > 0)
            {
                var responseModel = new AcademyResponseModel
                {
                    Id = existAcademy.Id,
                    AcademyName = existAcademy.AcademyName,
                    Email = existAcademy.User!.Email,
                    PhoneNumber = existAcademy.User.PhoneNumber,
                    AcademyAdmin = existAcademy.User.Name,
                    PostalCode = existAcademy.User.PostalCode,
                    Address = existAcademy.User.Address,
                    AcademyType = existAcademy.AcademyType!.Name,
                    CountryName = existAcademy.Country!.CountryName,
                    StateName = existAcademy.State!.StateName,
                    CityName = existAcademy.City!.CityName,
                    UserRole = existAcademy.User.UserRole
                };
                return ApiResponse<AcademyResponseModel>.SuccessResponse(responseModel,APIMessages.AcademyManagement.AcademyUpdated);
            }
            return ApiResponse<AcademyResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.InternalServerError);
        }

        public async Task<bool> IsAcademyNameUnique(string name)
        {
            return await academyRepository.FirstOrDefaultAsync(x => x.AcademyName == name) == null; 
        }
         
        public async Task<bool> IsAcademyEmailUnique(string email)
        {
            return await userRepository.FirstOrDefaultAsync(x => x.Email == email) == null; 
        }
    }
}
