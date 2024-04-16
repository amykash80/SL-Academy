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
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        [HttpPost("register-student")]
        public async Task<ApiResponse<StudentResponseModel>> AddStudent(StudentRequestModel model) => await studentService.AddStudent(model);
        [HttpGet("getAll-Students")]
        public async Task<ApiResponse<IEnumerable<StudentResponseModel>>> GetAllStudents() => await studentService.GetallStudents();

        [HttpGet("getStudentById/{id:guid}")]
        public async Task<ApiResponse<StudentResponseModel>> GetStudentById(Guid id) => await studentService.GetStudentById(id);

        [HttpPut("updateStudent")]
        public async Task<ApiResponse<StudentResponseModel>> UpdateStudent(StudentUpdateRequestModel model) => await studentService.UpdateStudent(model);
    }
}
