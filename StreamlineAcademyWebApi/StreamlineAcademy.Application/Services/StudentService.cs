using Microsoft.AspNetCore.Http.HttpResults;
using StreamlineAcademy.Application.Abstractions.Identity;
using StreamlineAcademy.Application.Abstractions.IEmailService;
using StreamlineAcademy.Application.Abstractions.IRepositories;
using StreamlineAcademy.Application.Abstractions.IServices;
using StreamlineAcademy.Application.Shared;
using StreamlineAcademy.Application.Utils;
using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Domain.Enums;
using StreamlineAcademy.Domain.Models.Requests;
using StreamlineAcademy.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IUserRepository userRepository;
        private readonly IEmailHelperService emailHelperService;
        private readonly IContextService contextService;

        public StudentService(IStudentRepository studentRepository,
                              IUserRepository userRepository,
                              IEmailHelperService emailHelperService,
                              IContextService contextService)
        {
            this.studentRepository = studentRepository;
            this.userRepository = userRepository;
            this.emailHelperService = emailHelperService;
            this.contextService = contextService;
        }
        public async Task<ApiResponse<StudentResponseModel>> AddStudent(StudentRequestModel model)
        {
            var existingEmail = await userRepository.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (existingEmail is not null)
                return ApiResponse<StudentResponseModel>.ErrorResponse(APIMessages.StudentManagement.StudentAlreadyRegistered, HttpStatusCodes.Conflict);

            var UserSalt = AppEncryption.GenerateSalt();
            var user = new User()
            {
                Name = model.Name,
                Email = model.Email,
                PostalCode = model.PostalCode,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                UserRole = UserRole.Instructor,
                Salt = UserSalt,
                Password = AppEncryption.CreatePassword(model.Password!, UserSalt),
                CreatedBy = Guid.Empty,
                CreatedDate = DateTime.Now,
                ModifiedBy = Guid.Empty,
                ModifiedDate = DateTime.Now,
                DeletedBy = Guid.Empty,
                IsActive = true
            };
            var returnVal = await userRepository.InsertAsync(user);
            if (returnVal > 0)
            {
                var student = new Student()
                {
                    Id = user.Id,
                    CountryId = model.CountryId,
                    StateId = model.StateId,
                    CityId = model.CityId,
                    AcademyId=model.AcademyId,
                    DateOfBirth = model.DateOfBirth,
                    EmergencyContactNo=model.EmergencyContactNo
                };
                var result = await studentRepository.InsertAsync(student);
                if (result > 0)
                {
                    List<StudentInterests> StdIntrests= new List<StudentInterests>();
                    foreach (var item in model.CourseId!)
                    {
                        var StudentIntrests = new StudentInterests()
                        {
                            StudentId = user.Id,
                            CourseId =item,
                            CreatedBy = Guid.Empty,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = Guid.Empty,
                            ModifiedDate = DateTime.Now,
                            DeletedBy = Guid.Empty,
                            IsActive = true
                        };
                        StdIntrests.Add(StudentIntrests);
                    }
                   
                    if (await emailHelperService.SendRegistrationEmail(user.Email!, user.Name!, model.Password!))
                    {
                        var res = await studentRepository.GetStudentById(student.Id);
                        return ApiResponse<StudentResponseModel>.SuccessResponse(res);
                    }
                }
                return ApiResponse<StudentResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.BadRequest);
            }
            return ApiResponse<StudentResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.BadRequest);
        }

        public Task<ApiResponse<IEnumerable<StudentResponseModel>>> GetallStudents()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<StudentResponseModel>> GetStudentById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<StudentResponseModel>> UpdateStudent(StudentUpdateRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
