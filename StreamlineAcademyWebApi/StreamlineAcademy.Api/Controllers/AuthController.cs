using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreamlineAcademy.Application.Abstractions.IServices;
using StreamlineAcademy.Application.Services;
using StreamlineAcademy.Application.Shared;
using StreamlineAcademy.Domain.Models.Requests;
using StreamlineAcademy.Domain.Models.Responses;

namespace StreamlineAcademy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<ApiResponse<string>> ChangePassword(ChangePasswordRequestModel model) => await authService.ChangePassword(model);

        
        [HttpPost("Login")]
        public async Task<ApiResponse<LoginResponseModel>> login(LoginRequestModel model) => await authService.Login(model);
    }
}
