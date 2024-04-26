using Microsoft.EntityFrameworkCore;
using StreamlineAcademy.Application.Abstractions.IRepositories;
using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Domain.Models.Responses;
using StreamlineAcademy.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Persistence.Repositories
{
    public class CourseResourceRepository:BaseRepository<CourseResource>,ICourseResourceRepository
    {
        private readonly StreamlineDbContet context;

        public CourseResourceRepository(StreamlineDbContet context):base(context)
        {
            this.context = context;
        }
        public async Task<CourseResourceResponseModel> GetCourseResourceById(Guid? id)
        {
            var courseResource = await context.CourseResources
              .Include(a => a.Course)
              .FirstOrDefaultAsync(a => a.Id == id);

            if (courseResource is not null)
            {  
                var response = new CourseResourceResponseModel
                {
                    Id = courseResource.Id,
                    Name = courseResource.Name,
                    Description = courseResource.Description,
                    Type =courseResource.Type!,
                    FilePath = courseResource.FilePath,
                    CourseName = courseResource.Name,
                };

                return response;
            }
            return new CourseResourceResponseModel() { };
        }

        public async Task<AppFiles?> GetByEntityIdAsync(Guid? entityId)
        {
            return await context.AppFiles.FirstOrDefaultAsync(x => x.EntityId == entityId);
        }
    }
}
