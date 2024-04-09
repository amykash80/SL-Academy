﻿using Microsoft.AspNetCore.Http;
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
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            this.instructorService = instructorService;
        }

        [HttpPost("register")]
        public async Task<ApiResponse<InstructorResponseModel>> AddInstructor(InstructorRequestModel model) => await instructorService.AddInstructor(model);
        [HttpGet("getAll-instructors")]
        public async Task<ApiResponse<IEnumerable<InstructorResponseModel>>> GetAllInstructors() => await instructorService.GetallInstructors();

        [HttpGet("getById/{id:guid}")]
        public async Task<ApiResponse<InstructorResponseModel>> GetInstructorById(Guid id) => await instructorService.GetInstructorById(id);

        [HttpDelete("delete/{id:guid}")]
        public async Task<ApiResponse<InstructorResponseModel>> DeleteInstructor(Guid id) => await instructorService.DeleteInstructor(id);

        [HttpPut("update")]
        public async Task<ApiResponse<InstructorResponseModel>> UpdateInstructor(InstructorUpdateRequestModel model) => await instructorService.UpdateInstructor(model);
    }
}