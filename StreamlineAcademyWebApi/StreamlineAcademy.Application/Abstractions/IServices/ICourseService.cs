using StreamlineAcademy.Application.Shared;
using StreamlineAcademy.Domain.Models.Requests;
using StreamlineAcademy.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Application.Abstractions.IServices
{
    public interface ICourseService
    {
        Task<ApiResponse<CourseResponseModel>> CreateCourse(CourseRequestModel request);
        Task<ApiResponse<IEnumerable<CourseResponseModel>>> GetAllCourses();
        Task<ApiResponse<CourseResponseModel>> GetCourseById(Guid id);
        Task<ApiResponse<CourseResponseModel>> UpdateCourse(CourseRequestModel request);
        //Task<ApiResponse<CourseResponseModel>> DeleteCourse(Guid id);

    }
}
