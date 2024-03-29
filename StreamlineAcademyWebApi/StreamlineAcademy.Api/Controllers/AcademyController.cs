using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreamlineAcademy.Application.Abstractions.IServices;
using StreamlineAcademy.Application.Services;
using StreamlineAcademy.Application.Shared;
using StreamlineAcademy.Domain.Enums;
using StreamlineAcademy.Domain.Models.Requests;
using StreamlineAcademy.Domain.Models.Responses;
using System.Runtime.InteropServices;
//using static StreamlineAcademy.Domain.Models.Requests.AcademyResponseModel;

namespace StreamlineAcademy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademyController : ControllerBase
    {
        private readonly IAcademyService academyService;

        public AcademyController(IAcademyService academyService)
        {
            this.academyService = academyService;
        }

        [HttpPost("register")]
        public async Task<ApiResponse<AcademyResponseModel>> RegisterAcademy(AcademyRequestModel request) => await academyService.RegisterAcademy(request);

        [HttpGet("getAll")]
        public async Task<ApiResponse<IEnumerable<AcademyResponseModel>>> GetAllAcademies() => await academyService.GetAllAcademies();

        [HttpGet("getById/{id:guid}")]
        public async Task<ApiResponse<AcademyResponseModel>> GetAcademyById(Guid id) => await academyService.GetAcademyById(id);

        [HttpDelete("delete/{id:guid}")]
        public async Task<ApiResponse<AcademyResponseModel>> DeleteAcademy(Guid id) => await academyService.DeleteAcademy(id);

        [HttpPut("update")]
        public async Task<ApiResponse<AcademyResponseModel>> UpdateAcademy(AcademyUpdateRequest model) => await academyService.UpdateAcademy(model);

        [HttpGet("check-name/{academyName}")]

        public async Task<IResult> IsAcadeyNameUnique(string academyName)
        {
            var isUnique = await academyService.IsAcademyNameUnique(academyName);
            return Results.Ok(isUnique);
        }

        [HttpGet("check-email/{academyEmail}")]

        public async Task<IResult> IsAcademyEmailUnique(string academyEmail)
        {
            var isUnique = await academyService.IsAcademyEmailUnique(academyEmail);
            return Results.Ok(isUnique);
        }
    }
}
