﻿using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Application.Abstractions.IRepositories
{
    public interface IStudentRepository
    {
        #region async methods
        Task<int> InsertAsync(Student model);
        Task<int> InsertRangeAsync(List<Student> models);
        Task<int> UpdateAsync(Student model);
        Task<int> DeleteAsync(Student model);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<IEnumerable<Student>> FindByAsync(Expression<Func<Student, bool>> expression);
        Task<Student> GetByIdAsync(Expression<Func<Student, bool>> expression);
        Task<Student> FirstOrDefaultAsync(Expression<Func<Student, bool>> expression);
        #endregion
        Task<StudentResponseModel> GetStudentById(Guid? id);
        Task<List<StudentResponseModel>> GetAllStudents(Guid? id);
        Task<int> Delete(User model);
    }
}