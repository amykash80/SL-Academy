using Microsoft.EntityFrameworkCore;
using StreamlineAcademy.Application.Abstractions.IRepositories;
using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Domain.Models.Responses;
using StreamlineAcademy.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Persistence.Repositories
{
    public class CourseRepository:BaseRepository<Course>,ICourseRepository
    {
        private readonly StreamlineDbContet context;

        public CourseRepository(StreamlineDbContet context):base(context)
        {
            this.context = context;
        }

        public async Task<CourseResponseModel> GetCourseById(Guid? id)
        {
            var course = await context.Courses
            .Include(a => a.CourseCategory)
            .FirstOrDefaultAsync(a => a.Id == id);

            if (course is not null)
            { 
                var response = new CourseResponseModel
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                    DurationInWeeks = course.DurationInWeeks, 
                    CategoryName = course.CourseCategory!.CategoryName,
                    IsActive = course.IsActive,
                    Fee = course.Fee,
                };

                return response;
            }
            return new CourseResponseModel() { };
        }

        public async Task<List<CourseResponseModel>> GetAllCourses()
        {
            var course = await context.Courses                    
                .Include(a => a.CourseCategory) 
                .Select(a => new CourseResponseModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    DurationInWeeks = a.DurationInWeeks, 
                    CategoryName = a.CourseCategory!.CategoryName,
                    IsActive = a.IsActive,
                    Fee = a.Fee,
                })
                .ToListAsync();

            return course;
        }

    }
}
