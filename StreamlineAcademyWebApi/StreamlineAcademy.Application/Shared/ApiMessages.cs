using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Application.Shared
{
public static class APIMessages
{
    // Common Errors 
    public static readonly string TechnicalError = "There is some technical error, please try again later.";
    public static readonly string ProjectName = "Streamline Academies";
    public static readonly string AlreadyAvailable = "Already Registered";
    public static readonly string NotFound = "Not found.";
    public static readonly string InvaildStatusCode = "Invalid status code.";
    public static readonly string UpdatedSuccessfully = "Updated Successfully.";
    public static readonly string VerifyEmailLink = "api/auth/verifyemail";
    public static readonly string ValidationException = "Validation error";
    public static readonly string ForbiddenException = "Forbidden error";
    public static readonly string InfoOrAndConflictException = "Info/Conflict error";
    public static readonly string DbUpdateException = "Database Update Exception";
    public static readonly string ResetPasswordLink = "api/auth/resetpassword";
    public static readonly string Success = "Success.";
    public static readonly string Error = "Error.";
    public static readonly string InvaildAPIStatusCodes = "Invalid status code.";
    public static readonly string Admin = "Admin";
    public static readonly string EmailTemplates = "EmailTemplates";
    public static readonly string Templates = "D:\\Repository\\KashmirService\\API\\KashmirServices-Api\\KashmirService.Infrastructure\\EmailTemplates";
    public static readonly string ConfirmEmailSubject = "Verify Your Email And Complete Registration";
    public static readonly string PasswordResetEmailSubject = "Reset Your Password";

    public static class Addresses
    {
        public static readonly string NoAddressFound = "No addresses found";
        public static readonly string AddressUpdated = "Address updated successfully";
    }

    public static class CourseManagement
    {
        public static readonly string CourseNotFound = "Course not found.";
        public static readonly string CourseAdded = "Course Added Successfully.";
        public static readonly string CourseUpdated = "Course Updated Successfully.";
        public static readonly string CourseAlreadyRegistered = "Course already Added";
        public static readonly string CourseDeleted = "Course deleted Successfully";

        }
        public static class AcademyManagement
		{
			public static readonly string AcademyNotFound = "Academy not found.";
			public static readonly string AcademyAdded = "Academy Registered Successfully.";
			public static readonly string AcademyUpdated = "Academy Updated Successfully.";
			public static readonly string AcademyDeleted = "Academy Deleted Successfully.";
            public static readonly string AcademyAlreadyRegistered = "Academy with this email already registered";

		}
        public static class UserManagement
        {
            public static readonly string UserNotFound = "user not found.";
            public static readonly string UserAdded = "user Registered Successfully.";
            public static readonly string UserUpdated = "user Updated Successfully.";
            public static readonly string UserDeleted = "user Deleted Successfully.";
            public static readonly string UserAlreadyRegistered = "user with this email already registered";

        
        }
        public static class InstructorManagement
        {
            public static readonly string InstructorNotFound = "Instructor not found.";
            public static readonly string InstructorAdded = "Instructor Registered Successfully.";
            public static readonly string InstructorUpdated = "Instructor Updated Successfully.";
            public static readonly string InstructorDeleted = "Instructor Deleted Successfully.";
            public static readonly string InstructorAlreadyRegistered = "Instructor with this email already registered";

        }

        public static class EnquiryManagement
		{
			public static readonly string EnquiryNotFound = "Enquiry not found.";
			public static readonly string EnquiryAdded = "Enquiry Added Successfully.";
			public static readonly string EnquiryUpdated = "Enquiry Updated Successfully.";
            public static readonly string EnquiryDeleted = "Enquiry Deleted Successfully.";
            public static readonly string EnquiryNameExist = "Name already Exist.";
            public static readonly string EnquiryEmailExist = "Email already Exist.";
            public static readonly string InvalidCredential = "Invalid Credentials.";
        }

        public static class ProfileManagement
        {
            public static readonly string UserNotFound = "User not found.";
            public static readonly string ContactUpdated = "Contact Updated Successfully.";
            public static readonly string UserFound = "Userfound.";
            public static readonly string AddressUpdated = "Address Updated Successfully.";
            public static readonly string PhotoUploaded = "Photo Uploaded Successfully.";
            

        }

        public static class Auth
    {
        public const string NameAlreadyTaken = "Name is already taken.";
        public const string EmailAlreadyRegistered = "Email already registered.";
        public const string PhoneNumberAlreadyRegistered = "Phone Number already registered.";
        public const string EmailOrPasswordIsIncorrect = "Email or/and Password is Incorrect.";
        public const string PasswordChangedSuccess = "Password changed successfully.";
        public const string LinkExpired = "Email verification link has been expired, please try again.";
        public const string EmailVerified = "Email verified successfully, please try to login again.";
        public const string VerifyEmailError = "Please verify your email to login.";
        public const string InactiveUser = "Your account is temporarily inactive. Please contact the administrator for assistance.";
        public const string InVaildEmailAddress = "User not found, please enter a vaild email.";
        public const string CheckEmailToResetPassword = "Please check your email inbox for instructions on how to reset your password.";
        public const string PasswordResetSuccess = "Your password has been successfully reset. You can now log in using your new password.";
        public const string UserNotFound = "User not found";
        public const string IncorrectOldPassword = "Old Password is Incorrect";
        public const string LoggedIn = "Successfully logged in";
        public const string InValidResetCode = "Invalid Reset Code";

        }

        public static class TemplateNames
    {
            public static readonly string AcademyRegistration = "AcademyRegistration.cshtml";
            public static readonly string PasswordReset = "PasswordReset.cshtml";
    }
		public static class AppRoutes
		{
			public static readonly string ClientResetPasswordRoute = "resetpassword";
			public static readonly string loginRoute = "login";

		}

	}

}
