using Org.BouncyCastle.Asn1.Ocsp;
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
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorReository instructorRepository;
        private readonly IUserRepository userRepository;
        private readonly IEmailHelperService emailHelperService;

        public InstructorService(IInstructorReository instructorRepository,
                                  IUserRepository userRepository,
                                  IEmailHelperService emailHelperService)
        {
            this.instructorRepository = instructorRepository;
            this.userRepository = userRepository;
            this.emailHelperService = emailHelperService;
        }
        public async Task<ApiResponse<InstructorResponseModel>> AddInstructor(InstructorRequestModel model)
        {

            var existingEmail = await userRepository.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (existingEmail is not null)
                return ApiResponse<InstructorResponseModel>.ErrorResponse(APIMessages.InstructorManagement.EmailAlreadyTaken, HttpStatusCodes.Conflict);
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
                var instructor = new Instructor()
                {
                    Id = user.Id,
                    CountryId = model.CountryId,
                    StateId = model.StateId,
                    CityId = model.CityId,
                    WorkExperiance=model.WorkExperience,
                    DateOfBirth=model.DateOfBirth,
                    Skill=Skill.Programming
                };
                var result = await instructorRepository.InsertAsync(instructor);
                if (result > 0)
                {
                    if (await emailHelperService.SendRegistrationEmail(user.Email!, user.Name!, model.Password!))
                    {
                        var res = await instructorRepository.GetInstructorById(instructor.Id);
                        return ApiResponse<InstructorResponseModel>.SuccessResponse(res);
                    }
                }
                return ApiResponse<InstructorResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.BadRequest);
            }
            return ApiResponse<InstructorResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.BadRequest);
        }

        public async Task<ApiResponse<InstructorResponseModel>> DeleteInstructor(Guid id)
        {
            var existingInstructor = await instructorRepository.GetInstructorById(id);

            if (existingInstructor is null)
                return ApiResponse<InstructorResponseModel>.ErrorResponse(APIMessages.InstructorManagement.InstructorNotFound, HttpStatusCodes.NotFound);

            var result = await userRepository.FirstOrDefaultAsync(x => x.Id == existingInstructor.Id);
            result.IsActive = false;
            result.DeletedDate = DateTime.Now;
            if (result is not null)
            {
                int isSoftDelted = await instructorRepository.Delete(result);
                if (isSoftDelted > 0)
                {
                    var returnVal = await instructorRepository.GetInstructorById(existingInstructor.Id);
                    return ApiResponse<InstructorResponseModel>.SuccessResponse(returnVal, APIMessages.InstructorManagement.InstructorDeleted);
                }
            }
            return ApiResponse<InstructorResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.InternalServerError);
        }

        public async  Task<ApiResponse<IEnumerable<InstructorResponseModel>>> GetallInstructors()
        {
            var returnVal = await instructorRepository.GetAllInstructors();
            if (returnVal is not null)
                return ApiResponse<IEnumerable<InstructorResponseModel>>.SuccessResponse(returnVal.OrderBy(_ => _.Name), $"Found {returnVal.Count()} Instructors");
            return ApiResponse<IEnumerable<InstructorResponseModel>>.ErrorResponse(APIMessages.InstructorManagement.InstructorNotFound, HttpStatusCodes.NotFound);
        }

        public async Task<ApiResponse<InstructorResponseModel>> GetInstructorById(Guid id)
        {
            var instructor = await instructorRepository.GetInstructorById(id);
            if (instructor is null)
                return ApiResponse<InstructorResponseModel>.ErrorResponse(APIMessages.InstructorManagement.InstructorNotFound, HttpStatusCodes.NotFound);

            var responseModel = await instructorRepository.GetInstructorById(id);
            if (responseModel is null)
                return ApiResponse<InstructorResponseModel>.ErrorResponse(APIMessages.TechnicalError);
            return ApiResponse<InstructorResponseModel>.SuccessResponse(responseModel);
        }

        public async Task<ApiResponse<InstructorResponseModel>> UpdateInstructor(InstructorUpdateRequestModel request)
        {
            var user = await userRepository.GetByIdAsync(x=>x.Id==request.Id);

            if (user is null)
                return ApiResponse<InstructorResponseModel>.ErrorResponse(APIMessages.InstructorManagement.InstructorNotFound, HttpStatusCodes.NotFound);
            user.Email= request.Email;
            user.PhoneNumber= request.PhoneNumber;
            user.Address=request.Address;
            user.PostalCode= request.PostalCode;
            user.Name=request.Name;
            user.ModifiedDate = DateTime.Now;
            user.IsActive = request.IsActive;
            var userResponse = await userRepository.UpdateAsync(user);

            var instructor = await instructorRepository.GetByIdAsync(x=>x.Id==user.Id);
            instructor.DateOfBirth = request.DateOfBirth;
            instructor.WorkExperiance = request.WorkExperience;
            instructor.DateOfBirth=request.DateOfBirth;
            instructor.CountryId= request.CountryId;
            instructor.StateId=request.StateId;
            instructor.CityId=request.CityId;
            
            var instructorResponse = await userRepository.UpdateAsync(user);

            if (instructorResponse is > 0)
            {
                var responseModel= await instructorRepository.GetInstructorById(user.Id);
                return ApiResponse<InstructorResponseModel>.SuccessResponse(responseModel, APIMessages.InstructorManagement.InstructorUpdated);
            }
            return ApiResponse<InstructorResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.InternalServerError);
        }
    }
}
