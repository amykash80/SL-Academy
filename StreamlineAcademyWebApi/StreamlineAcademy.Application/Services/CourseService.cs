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

        public async Task<ApiResponse<CourseCategoryResponseModel>> CreateCourseCategory(CourseCategoryRequestModel model)
        {
            var courseCategory = await courseRepository.GetCourseCategoryById(x => x.CategoryName == model.CategoryName);
            if (courseCategory is not null)
                return ApiResponse<CourseCategoryResponseModel>.ErrorResponse(APIMessages.CourseCategoryManagement.CourseCategoryAlreadyRegistered, HttpStatusCodes.Conflict);
            var courseCategoryModel = new CourseCategory()
            {
                CategoryName= model.CategoryName,
                CreatedBy = Guid.Empty,
                CreatedDate = DateTime.Now,
                ModifiedBy = Guid.Empty,
                ModifiedDate = DateTime.Now,
                DeletedBy = Guid.Empty,
                IsActive = true
            };
            var res = await courseRepository.CreateCourseCategory(courseCategoryModel);
            if (res > 0)
            {
                var returnModel = new CourseCategoryResponseModel()
                {

                    Id = courseCategoryModel.Id,
                    CategoryName = model.CategoryName,
                };
                return ApiResponse<CourseCategoryResponseModel>.SuccessResponse(returnModel);
            }
            return ApiResponse<CourseCategoryResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.InternalServerError);
        }

        public Task<ApiResponse<CourseResponseModel>> DeleteCourse(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<IEnumerable<CourseCategoryResponseModel>>> GetAllCourseCategories()
        {
            var returnVal = await courseRepository.GetAllCourseCategories();
            List<CourseCategoryResponseModel> CourseCategoryResponseModels = new List<CourseCategoryResponseModel>();
            if (returnVal is not null)
            {
                foreach (var item in returnVal)
                {
                    var CourseCategoryResponseModel = new CourseCategoryResponseModel
                    {
                        Id = item.Id,
                        CategoryName = item.CategoryName,

                    };
                    CourseCategoryResponseModels.Add(CourseCategoryResponseModel);
                }
                return ApiResponse<IEnumerable<CourseCategoryResponseModel>>.SuccessResponse(CourseCategoryResponseModels.ToList().OrderBy(_ => _.CategoryName), $"Found {CourseCategoryResponseModels.Count()} CourseCategories");
            }

            return ApiResponse<IEnumerable<CourseCategoryResponseModel>>.ErrorResponse(APIMessages.CourseCategoryManagement.CourseCategoryNotFound, HttpStatusCodes.NotFound);
        }

        public async Task<ApiResponse<IEnumerable<CourseResponseModel>>> GetAllCourses()
        {
            var courseList = await courseRepository.GetAllCourses();
            if (courseList.Any())
             return ApiResponse<IEnumerable<CourseResponseModel>>.SuccessResponse(courseList, $"Found {courseList.Count()} Courses");
            return ApiResponse<IEnumerable<CourseResponseModel>>.ErrorResponse(APIMessages.CourseManagement.CourseNotFound, HttpStatusCodes.NotFound);
        }

        public async Task<ApiResponse<CourseResponseModel>> GetCourseById(Guid id)
        {
            var course = await courseRepository.GetCourseById(id);
            if (course is not null)
                return ApiResponse<CourseResponseModel>.SuccessResponse(course, APIMessages.EnquiryManagement.EnquiryNotFound);
               return ApiResponse<CourseResponseModel>.ErrorResponse(APIMessages.TechnicalError);
        }

        public async Task<ApiResponse<CourseCategoryResponseModel>> GetCourseCategoryById(Guid id)
        {
           var res= await courseRepository.GetCourseCategoryById(x => x.Id == id);
            if (res is not null)
            return ApiResponse<CourseCategoryResponseModel>.SuccessResponse(new CourseCategoryResponseModel() { Id = res!.Id, CategoryName = res.CategoryName, }, HttpStatusCodes.OK.ToString());

            return ApiResponse<CourseCategoryResponseModel>.ErrorResponse(APIMessages.TechnicalError);

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
                    DurationInWeeks = existCourse.DurationInWeeks,
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

