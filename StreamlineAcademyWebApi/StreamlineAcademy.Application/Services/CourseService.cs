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
                CategoryId = request.CategoryId,
                DurationInWeeks = request.DurationInWeeks,
                InstructorId = request.InstructorId,
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
                var courseResponse = await courseRepository.GetByIdAsync(x => x.Id == course.Id);
                var response = new CourseResponseModel()
                {
                    Id = courseResponse.Id,
                    Name = courseResponse.Name,
                    Category= courseResponse.Category,
                    DurationInWeeks = courseResponse.DurationInWeeks,
                    InstructorName= courseResponse.InstructorName,
                    Fee= courseResponse.Fee,
                };
                return ApiResponse<CourseResponseModel>.SuccessResponse(response, APIMessages.CourseManagement.CourseAdded, HttpStatusCodes.Created);
            }
            return ApiResponse<CourseResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.InternalServerError);
        }

        public Task<ApiResponse<CourseResponseModel>> DeleteCourse(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<IEnumerable<CourseResponseModel>>> GetAllCourses()
        {
            var courseList = await courseRepository.GetAllAsync();
            if (courseList.Any())
            {
                var sortedCourse = courseList.OrderBy(x => x.Name).Select(e => new CourseResponseModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Category = e.Category,
                    DurationInWeeks = e.DurationInWeeks,
                    InstructorName= e.InstructorName,
                    Fee= e.Fee,  
                });
                return ApiResponse<IEnumerable<CourseResponseModel>>.SuccessResponse(sortedCourse, $"Found {courseList.Count()} Courses");
               
            }
            return ApiResponse<IEnumerable<CourseResponseModel>>.ErrorResponse(APIMessages.CourseManagement.CourseNotFound, HttpStatusCodes.NotFound);
        }

        public async Task<ApiResponse<CourseResponseModel>> GetCourseById(Guid id)
        {
            var course = await courseRepository.GetByIdAsync(x => x.Id == id);
            if (course == null)
            {
                return ApiResponse<CourseResponseModel>.ErrorResponse(APIMessages.EnquiryManagement.EnquiryNotFound);
            }
            var response = new CourseResponseModel
            {
                Id = course.Id,
                Name = course.Name,
                Category = course.Category,
                DurationInWeeks = course.DurationInWeeks,
                InstructorName = course.InstructorName,
                Fee = course.Fee
            };
            return ApiResponse<CourseResponseModel>.SuccessResponse(response);
        }
       

        public async Task<ApiResponse<CourseResponseModel>> UpdateCourse(CourseUpdateRequest request)
        {
            var existCourse = await courseRepository.GetByIdAsync(x => x.Id == request.Id);
            if (existCourse is null)
                return ApiResponse<CourseResponseModel>.ErrorResponse(APIMessages.CourseManagement.CourseNotFound, HttpStatusCodes.NotFound);
            var course = new Course()
            {
                Name = request.Name,
                CategoryId = request.CategoryId,
                DurationInWeeks = request.DurationInWeeks,
                InstructorId = request.InstructorId,
                Fee = request.Fee,
                IsActive = true,
                CreatedBy = Guid.Empty,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                DeletedBy = Guid.Empty,
                DeletedDate = DateTime.Now,
            };
            var returnVal = await courseRepository.UpdateAsync(course);
            if (returnVal > 0)
            {
                var response = new CourseResponseModel()
                {
                    Id = existCourse.Id,
                    Name = existCourse.Name,
                    Category = existCourse.Category,
                    DurationInWeeks = existCourse.DurationInWeeks,
                    InstructorName = existCourse.InstructorName,
                    Fee = existCourse.Fee
                };
                return ApiResponse<CourseResponseModel>.SuccessResponse(response, APIMessages.CourseManagement.CourseUpdated, HttpStatusCodes.Created);
            }
            return ApiResponse<CourseResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.InternalServerError);
        }

        public Task<ApiResponse<CourseResponseModel>> UpdateCourse(CourseRequestModel request)
        {
            throw new NotImplementedException();
        }

        //public async Task<ApiResponse<CourseResponseModel>> DeleteAcademy(Guid id)
        //{
        //    var existingCourse = await courseRepository.GetByIdAsync(x => x.Id == id);

        //    if (existingCourse is null)
        //        return ApiResponse<CourseResponseModel>.ErrorResponse(APIMessages.CourseManagement.CourseNotFound, HttpStatusCodes.NotFound);

        //    var result = await courseRepository.FirstOrDefaultAsync(x => x.Id == existingCourse.Id);
        //    result.IsActive = false;
        //    result.DeletedDate = DateTime.Now;
        //    if (result is not null)
        //    {
        //        int isSoftDelted = await courseRepository.DeleteAsync(result);
        //        if (isSoftDelted > 0)
        //        {

        //            return ApiResponse<CourseResponseModel>.SuccessResponse(returnVal, APIMessages.AcademyManagement.AcademyDeleted);
        //        }
        //    }
        //    return ApiResponse<AcademyResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.InternalServerError);
        //}
    }
}

