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

        public async Task<StudentResponseModel> GetStudentById(Guid? id)
        {

            var student = await context.Students
              .Include(a => a.User)
              .Include(a => a.Country)
              .Include(a => a.State)
              .Include(a => a.City)
              .FirstOrDefaultAsync(a => a.Id == id);

            if (student is not null)
            {

                var response = new StudentResponseModel()
                {
                    Id = student.Id,
                    Name = student.User!.Name,
                    Email = student.User!.Email,
                    PhoneNumber = student.User.PhoneNumber,
                    PostalCode = student.User.PostalCode,
                    Address = student.User.Address,
                    DateOfBirth = student.DateOfBirth,
                    CountryName = student.Country!.CountryName,
                    AcademyName = student.Academy!.AcademyName,
                    StateName = student.State!.StateName,
                    CityName = student.City!.CityName,
                    IsActive = student.User.IsActive,
                    UserRole = student.User.UserRole,

                };

                return response;
            }
            return new StudentResponseModel() { };

        }


        public async Task<List<StudentResponseModel>> GetAllStudents(Guid? id)
        {
            var students = await context.Students
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
                    AcademyName=a.Academy!.AcademyName,
                    CountryName = a.Country!.CountryName,
                    StateName = a.State!.StateName,
                    CityName = a.City!.CityName,
                    UserRole = a.User.UserRole
                })
                .ToListAsync();

            return students;
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

       

    }
}
