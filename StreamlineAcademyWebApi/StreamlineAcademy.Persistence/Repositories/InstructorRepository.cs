﻿using Microsoft.EntityFrameworkCore;
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
    public class InstructorRepository : IInstructorReository
    {
        private readonly StreamlineDbContet context;

        public InstructorRepository(StreamlineDbContet context)
        {
            this.context = context;
        }

        public Task<int> DeleteAsync(Instructor model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Instructor>> FindByAsync(Expression<Func<Instructor, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Instructor> FirstOrDefaultAsync(Expression<Func<Instructor, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Instructor>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Instructor> GetByIdAsync(Expression<Func<Instructor, bool>> expression)
        {
			return await context.Instructors.FirstOrDefaultAsync(expression);

        }

        public async Task<InstructorResponseModel> GetInstructorById(Guid? id)
        {

            var instructor = await context.Instructors
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
                    WorkExperiance = instructor.WorkExperiance,
                    Skill = instructor.Skill,
                    DateOfBirth = instructor.DateOfBirth,
                    CountryName = instructor.Country!.CountryName,
                    StateName = instructor.State!.StateName,
                    CityName = instructor.City!.CityName,
                    IsActive=instructor.User.IsActive,
                    UserRole = instructor.User.UserRole,
                    

                };

                return response;
            }
            return new InstructorResponseModel() { };

        }


        public async Task<List<InstructorResponseModel>> GetAllInstructors()
        {
            var instructors = await context.Instructors
                .Include(a => a.User)
                .Include(a => a.Country)
                .Include(a => a.State)
                .Include(a => a.City)
                .Select(a => new InstructorResponseModel
                {
                    Id = a.Id,
                    Email = a.User!.Email,
                    PhoneNumber = a.User.PhoneNumber,
                    PostalCode = a.User.PostalCode,
                    Address = a.User.Address,
                    WorkExperiance = a.WorkExperiance,
                    DateOfBirth= a.DateOfBirth,
                    Skill=a.Skill,
                    CountryName = a.Country!.CountryName,
                    StateName = a.State!.StateName,
                    CityName = a.City!.CityName,
                    UserRole = a.User.UserRole
                })
                .ToListAsync();

            return instructors;
        }

        public async Task<int> InsertAsync(Instructor model)
        {
            await context.Set<Instructor>().AddAsync(model);
            return await context.SaveChangesAsync();
        }

        public Task<int> InsertRangeAsync(List<Instructor> models)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Instructor model)
        {
            await context.Instructors.AddAsync(model);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(User model)
        {
            await Task.Run(() => context.Set<User>().Update(model));
            return await context.SaveChangesAsync();
        }
    }
}