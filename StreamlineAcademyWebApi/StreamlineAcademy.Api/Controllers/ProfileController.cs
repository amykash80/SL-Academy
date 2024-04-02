using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreamlineAcademy.Application.Abstractions.IServices;
using StreamlineAcademy.Application.Services;
using StreamlineAcademy.Application.Shared;
using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Domain.Models.Requests;
using StreamlineAcademy.Domain.Models.Responses;
using StreamlineAcademy.Persistence.Data;

namespace StreamlineAcademy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly StreamlineDbContet contet;
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            
            this.profileService = profileService;
        }
        [HttpGet("getById/{id:guid}")]

        public async Task<ApiResponse<ContactInfoResponse>> GetEnquiryById(Guid id) => await profileService.GetContactInfoById(id);
         

        
    }
}
