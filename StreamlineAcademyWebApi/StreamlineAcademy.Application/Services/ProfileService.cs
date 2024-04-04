using AutoMapper;
using StreamlineAcademy.Application.Abstractions.Identity;
using StreamlineAcademy.Application.Abstractions.IRepositories;
using StreamlineAcademy.Application.Abstractions.IServices;
using StreamlineAcademy.Application.Shared;
using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Domain.Models.Requests;
using StreamlineAcademy.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StreamlineAcademy.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository profileRepository;
        private readonly IMapper mapper;
        private readonly IContextService contextService;

        public ProfileService(IProfileRepository profileRepository, IMapper mapper, IContextService contextService)
        {
            this.profileRepository = profileRepository;
            this.mapper = mapper;
            this.contextService = contextService;
        }
        public async Task<ApiResponse<ContactInfoResponseModel>> GetContactInfoById()
        {
            var userid = contextService.GetUserId();
            var contact = await profileRepository.GetByIdAsync(x => x.Id == userid);
            if (contact is null)
                return ApiResponse<ContactInfoResponseModel>.ErrorResponse(APIMessages.ProfileManagement.UserNotFound);
            var responseModel = new ContactInfoResponseModel
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber
            };
            return ApiResponse<ContactInfoResponseModel>.SuccessResponse(responseModel);


        }

        public async Task<ApiResponse<ContactUpdateModel>> UpdateContact(ContactUpdateModel request)
        {
            var userId = contextService.GetUserId();
            var existingContact = await profileRepository.GetByIdAsync(x => x.Id == userId);

            if (existingContact == null)
                return ApiResponse<ContactUpdateModel>.ErrorResponse(APIMessages.ProfileManagement.UserNotFound);
            existingContact.Name = request.Name;
            existingContact.Email = request.Email;
            existingContact.PhoneNumber = request.PhoneNumber;
            var updateUser = await profileRepository.UpdateAsync(existingContact);
            if (updateUser > 0)
            {
                var updatedContactResponse = new ContactUpdateModel
                {
                    Name = existingContact.Name,
                    Email = existingContact.Email,
                    PhoneNumber = existingContact.PhoneNumber
                };
                return ApiResponse<ContactUpdateModel>.SuccessResponse(updatedContactResponse, APIMessages.ProfileManagement.ContactUpdated, HttpStatusCodes.Created);
            }

            return ApiResponse<ContactUpdateModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.InternalServerError);
        }

        public async Task<ApiResponse<AddressInfoResponseModel>> GetAddressInfoById()
        {

            var id = contextService.GetUserId();
            var res = await profileRepository.GetAddressInfo(id);
            if (res is not null)
                return ApiResponse<AddressInfoResponseModel>.SuccessResponse(res, APIMessages.ProfileManagement.UserFound);
            return ApiResponse<AddressInfoResponseModel>.ErrorResponse(APIMessages.TechnicalError);
        }


        public async Task<ApiResponse<AddressInfoUpdateModel>> UpdateAddress(AddressInfoUpdateModel request)
        {
            var id = contextService.GetUserId();
            var superadmin = await profileRepository.GetAddressInfo(id);
            
            if (superadmin is not null)
            {
                superadmin.Address = request.Address;
                superadmin.PostalCode = request.PostalCode;
                superadmin.CountryName = request.CountryName;
                superadmin.StateName = request.StateName;
                superadmin.CityName = request.CityName;
              
                return ApiResponse<AddressInfoUpdateModel>.SuccessResponse(request, APIMessages.ProfileManagement.ContactUpdated, HttpStatusCodes.Created);
            }


            return ApiResponse<AddressInfoUpdateModel>.ErrorResponse(APIMessages.TechnicalError);
        }
    }
}
