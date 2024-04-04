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
            var userid =  contextService.GetUserId();
            var contact =await  profileRepository.GetByIdAsync(x => x.Id == userid);
            if (contact is null)
                return ApiResponse<ContactInfoResponseModel>.ErrorResponse(APIMessages.ProfileManagement.UserNotFound);
            return ApiResponse<ContactInfoResponseModel>.SuccessResponse(mapper.Map<ContactInfoResponseModel>(contact)); 
           

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
            if(updateUser > 0)
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

    //    public async Task<ApiResponse<AddressInfoResponseModel>> GetAddressInfoById()
    //    {
    //        var userid = contextService.GetUserId();
    //        var contactUser = await profileRepository.GetByIdAsync(x => x.Id == userid);
    //        var query = @"
    //            SELECT u.*, sa.CountryId, sa.StateId, sa.CityId,
    //                   c.Name AS CountryName, s.Name AS StateName, ci.Name AS CityName
    //            FROM Users u
    //            LEFT JOIN SuperAdmins sa ON u.Id = sa.UserId
    //            LEFT JOIN Countries c ON sa.CountryId = c.Id
    //            LEFT JOIN States s ON sa.StateId = s.Id
    //            LEFT JOIN Cities ci ON sa.CityId = ci.Id
    //            WHERE u.Id = @userId;
    //        ";

            
    //        var contact = await profileRepository.GetAddressInfoByIdAsync(query);
    //        if (contact is null)
    //            return ApiResponse<AddressInfoResponseModel>.ErrorResponse(APIMessages.ProfileManagement.UserNotFound);
    //        //var superAdmin = contact.SuperAdmin;

    //        //var countryName = superAdmin.Country?.CountryName;
    //        //var stateName = superAdmin.State?.StateName;
    //        //var cityName = superAdmin.City?.CityName;
    //        var countryName = contact.SuperAdmin?.Country?.CountryName;
    //        var stateName = contact.SuperAdmin?.State?.StateName;
    //        var cityName = contact.SuperAdmin?.City?.CityName;

    //        var responseModel = new AddressInfoResponseModel
    //        {
    //            Id = contact.Id,
    //            Address = contact.Address,
    //            PostalCode = contact.PostalCode,
    //            CountryName = countryName,
    //            StateName = stateName,
    //            CityName = cityName
    //        };
    //        return ApiResponse<AddressInfoResponseModel>.SuccessResponse(responseModel);


    //    }
    }
}
