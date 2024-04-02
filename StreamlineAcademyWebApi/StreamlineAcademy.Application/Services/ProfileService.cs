using AutoMapper;
using StreamlineAcademy.Application.Abstractions.Identity;
using StreamlineAcademy.Application.Abstractions.IRepositories;
using StreamlineAcademy.Application.Abstractions.IServices;
using StreamlineAcademy.Application.Shared;
using StreamlineAcademy.Domain.Entities;
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
        public async Task<ApiResponse<ContactInfoResponse>> GetContactInfoById(Guid id)
        {
            var userid =  contextService.GetUserId();
            var contact =await  profileRepository.GetByIdAsync(x => x.Id == id);
            if (contact is null)
                return ApiResponse<ContactInfoResponse>.ErrorResponse(APIMessages.UserManagement.UserNotFound);
            return ApiResponse<ContactInfoResponse>.SuccessResponse(mapper.Map<ContactInfoResponse>(contact)); 
           

        }
    }
}
