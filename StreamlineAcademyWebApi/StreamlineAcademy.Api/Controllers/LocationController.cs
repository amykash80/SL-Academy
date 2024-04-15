using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreamlineAcademy.Application.Abstractions.IServices;
using StreamlineAcademy.Application.Shared;
using StreamlineAcademy.Domain.Enums;
using StreamlineAcademy.Domain.Models.Requests;
using StreamlineAcademy.Domain.Models.Responses;

namespace StreamlineAcademy.Api.Controllers
{
    [Authorize(Roles = nameof(UserRole.AcademyAdmin))]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService locationService;

        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        [HttpPost]
        public async Task<ApiResponse<LocationResponseModel>> AddLocation(LocationRequestModel model)=>await locationService.AddLocation(model);
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<LocationResponseModel>>> GetLocations() => await locationService.GetAllLocations();
    }
}
