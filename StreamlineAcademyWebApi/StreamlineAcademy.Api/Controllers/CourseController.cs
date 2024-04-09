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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;
        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpPost("create")]
        public async Task<ApiResponse<CourseResponseModel>> CreateCourse(CourseRequestModel request) => await courseService.CreateCourse(request);

        [HttpGet("getAll")] 
        public async Task<ApiResponse<IEnumerable<CourseResponseModel>>> GetAllEnquiries() => await courseService.GetAllCourses();


        [HttpGet("getById/{id:guid}")]

        public async Task<ApiResponse<CourseResponseModel>> GetEnquiryById(Guid id) => await courseService.GetCourseById(id);
        [HttpPut("update")]

        public async Task<ApiResponse<CourseResponseModel>> UpdateCourse(CourseUpdateRequest model) => await courseService.UpdateCourse(model);
        //[HttpDelete("delete/{id:guid}")]
        //public async Task<ApiResponse<CourseResponseModel>> DeleteCourse(Guid id) => await courseService.DeleteCourse(id);
    }
}
