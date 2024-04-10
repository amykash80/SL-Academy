using AutoMapper;
using StreamlineAcademy.Application.Abstractions.IRepositories;
using StreamlineAcademy.Application.Abstractions.IServices;
using StreamlineAcademy.Application.Shared;
using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Domain.Models.Requests;
using StreamlineAcademy.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Application.Services
{
    public class CourseService:ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<ApiResponse<CourseResponseModel>> CreateCourse(CourseRequestModel request)
        {
            var existingCourse = await courseRepository.GetByIdAsync(x => x.Name == request.Name);
            if (existingCourse is not null)
                return ApiResponse<CourseResponseModel>.ErrorResponse(APIMessages.CourseManagement.CourseAlreadyRegistered, HttpStatusCodes.Conflict);
            var course = new Course()
            {
                Name = request.Name,
                Description=request.Description,
                CategoryId = request.CategoryId,
                DurationInWeeks = request.DurationInWeeks,
                Fee = request.Fee,
                IsActive = true,
                CreatedBy = Guid.Empty,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                DeletedBy = Guid.Empty,
                DeletedDate = DateTime.Now,

            };
            var res = await courseRepository.InsertAsync(course);
            if (res > 0)
            {
                var courseResponse = await courseRepository.GetCourseById(course.Id);
               
                return ApiResponse<CourseResponseModel>.SuccessResponse(courseResponse, APIMessages.CourseManagement.CourseAdded, HttpStatusCodes.Created);
            }
            return ApiResponse<CourseResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.InternalServerError);
        }

        public async Task<ApiResponse<CourseResponseModel>> DeleteCourse(Guid id)
        {
            var existingCourse = await courseRepository.GetByIdAsync(x => x.Id == id);

            if (existingCourse == null)
                return ApiResponse<CourseResponseModel>.ErrorResponse(APIMessages.CourseManagement.CourseNotFound, HttpStatusCodes.NotFound);

            existingCourse.IsActive = false; 
            existingCourse.DeletedDate = DateTime.Now; 

            int isSoftDeleted = await courseRepository.UpdateAsync(existingCourse);

            if (isSoftDeleted > 0)
            {
                return ApiResponse<CourseResponseModel>.SuccessResponse(null, APIMessages.CourseManagement.CourseDeleted);
            }

            return ApiResponse<CourseResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.InternalServerError);
        }
        
        public async Task<ApiResponse<IEnumerable<CourseResponseModel>>> GetAllCourses()
        {
            var returnVal = await courseRepository.GetAllCourses();
            if (returnVal is not null)
                return ApiResponse<IEnumerable<CourseResponseModel>>.SuccessResponse(returnVal.OrderBy(_ => _.Name), $"Found {returnVal.Count()} Courses");
            return ApiResponse<IEnumerable<CourseResponseModel>>.ErrorResponse(APIMessages.AcademyManagement.AcademyNotFound, HttpStatusCodes.NotFound);
        }
        
        public async Task<ApiResponse<CourseResponseModel>> GetCourseById(Guid id)
        {
            var course = await courseRepository.GetByIdAsync(x => x.Id == id);
            if (course is null)
                return ApiResponse<CourseResponseModel>.ErrorResponse(APIMessages.CourseManagement.CourseNotFound, HttpStatusCodes.NotFound);

            var responseModel = await courseRepository.GetCourseById(id);

            return ApiResponse<CourseResponseModel>.SuccessResponse(responseModel);
        }
        

        public async Task<ApiResponse<CourseResponseModel>> UpdateCourse(CourseUpdateRequest request)
        {
            var existingCourse = await courseRepository.GetByIdAsync(x => x.Id == request.Id);
            if (existingCourse == null)
                return ApiResponse<CourseResponseModel>.ErrorResponse(APIMessages.CourseManagement.CourseNotFound, HttpStatusCodes.NotFound);
            existingCourse.Name = request.Name;
            existingCourse.Description = request.Description;
            existingCourse.DurationInWeeks = request.DurationInWeeks;
            existingCourse.Fee = request.Fee;
            existingCourse.CategoryId = request.CategoryId;
            existingCourse.ModifiedDate = DateTime.Now;

            var returnVal = await courseRepository.UpdateAsync(existingCourse);
            if (returnVal > 0)
            {   
                var response = new CourseResponseModel()
                {
                    Id = existingCourse.Id,
                    Name = existingCourse.Name,
                    Description = existingCourse.Description,
                    DurationInWeeks = existingCourse.DurationInWeeks,
                    CategoryName = existingCourse.CourseCategory?.CategoryName, 
                    Fee = existingCourse.Fee,
                    IsActive = existingCourse.IsActive
                };
                return ApiResponse<CourseResponseModel>.SuccessResponse(response, APIMessages.CourseManagement.CourseUpdated, HttpStatusCodes.OK);
            }
            return ApiResponse<CourseResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.InternalServerError);
        }
        
       
    }
}

