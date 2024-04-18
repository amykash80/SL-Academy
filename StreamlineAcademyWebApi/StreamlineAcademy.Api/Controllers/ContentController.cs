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
    public class ContentController : ControllerBase
    {
        private readonly IContentService contentService;

        public ContentController(IContentService contentService)
        {
            this.contentService = contentService;
        }

        [HttpPost("createContent")]
        public async Task<ApiResponse<CourseContentResponseModel>> CreateContent(CourseContentRequestModel request) => await contentService.CreateContent(request);
        [HttpGet("getContentById/{id:guid}")]
        public async Task<ApiResponse<CourseContentResponseModel>> GetContentById(Guid id) => await contentService.GetContentById(id);
        [HttpPut("updateContent")]
        public async Task<ApiResponse<CourseContentResponseModel>> UpdateContent(CourseContentUpdateRequest model) => await contentService.UpdateContent(model);
        [HttpDelete("deleteContent/{id:guid}")]
        public async Task<ApiResponse<CourseContentResponseModel>> DeleteContent(Guid id) => await contentService.DeleteContent(id);

    }
}
