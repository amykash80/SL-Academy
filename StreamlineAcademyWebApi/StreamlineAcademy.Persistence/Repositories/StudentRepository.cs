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
    public class StudentRepository:IStudentRepository
    {
        private readonly StreamlineDbContet context;

        public StudentRepository(StreamlineDbContet context)
        {
            this.context = context;
        }

        public Task<int> DeleteAsync(Student model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> FindByAsync(Expression<Func<Student, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Student> FirstOrDefaultAsync(Expression<Func<Student, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetByIdAsync(Expression<Func<Student, bool>> expression)
        {
            return await context.Students.FirstOrDefaultAsync(expression);

        }

        public async Task<InstructorResponseModel> GetStudentById(Guid? id)
        {

            var instructor = await context.Students
              .Include(a => a.User)
              .Include(a => a.Country)
              .Include(a => a.State)
              .Include(a => a.City)
              .FirstOrDefaultAsync(a => a.Id == id);

            if (instructor is not null)
            {

                var response = new InstructorResponseModel()
                {
                    Id = instructor.Id,
                    Name = instructor.User!.Name,
                    Email = instructor.User!.Email,
                    PhoneNumber = instructor.User.PhoneNumber,
                    PostalCode = instructor.User.PostalCode,
                    Address = instructor.User.Address,
                    DateOfBirth = instructor.DateOfBirth,
                    CountryName = instructor.Country!.CountryName,
                    StateName = instructor.State!.StateName,
                    CityName = instructor.City!.CityName,
                    IsActive = instructor.User.IsActive,
                    UserRole = instructor.User.UserRole,


                };

                return response;
            }
            return new InstructorResponseModel() { };

        }


        public async Task<List<InstructorResponseModel>> GetAllStudents(Guid? id)
        {
            var instructors = await context.Students
                 .Where(a => a.AcademyId == id)
                .Include(a => a.User)
                .Include(a => a.Country)
                .Include(a => a.State)
                .Include(a => a.City)
                .Select(a => new StudentResponseModel
                {
                    Id = a.Id,
                    Email = a.User!.Email,
                    PhoneNumber = a.User.PhoneNumber,
                    PostalCode = a.User.PostalCode,
                    Address = a.User.Address,
                    DateOfBirth = a.DateOfBirth,
                    CountryName = a.Country!.CountryName,
                    StateName = a.State!.StateName,
                    CityName = a.City!.CityName,
                    UserRole = a.User.UserRole
                })
                .ToListAsync();

            return default;
        }

        public async Task<int> InsertAsync(Student model)
        {
            await context.Set<Student>().AddAsync(model);
            return await context.SaveChangesAsync();
        }

        public async Task<int> InsertRangeAsync(List<StudentInterests> models)
        {
            await context.StudentInterests.AddRangeAsync(models);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Student model)
        {
            await context.Students.AddAsync(model);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(User model)
        {
            await Task.Run(() => context.Set<User>().Update(model));
            return await context.SaveChangesAsync();
        }

        Task<StudentResponseModel> IStudentRepository.GetStudentById(Guid? id)
        {
            throw new NotImplementedException();
        }

        Task<List<StudentResponseModel>> IStudentRepository.GetAllStudents(Guid? id)
        {
            throw new NotImplementedException();
        }
    }
}
