using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StreamlineAcademy.Application.Abstractions.IEmailService;
using StreamlineAcademy.Application.Abstractions.IServices;
using StreamlineAcademy.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Application.DI
{
    public static class AssemblyRefrencecs
    {

        public static IServiceCollection AddAplicationService(this IServiceCollection services,string WebRootPath,IConfiguration configuration )
        {
			services.AddAuthentication(options =>
			{

				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

			}).AddJwtBearer(options =>
			{
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,

					ValidIssuer = configuration["Jwt:Issuer"],
					ValidAudience = configuration["Jwt:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
				};
			});
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IEnquiryService,EnquiryService>();
            services.AddScoped<IFileService, FileService>();
            services.AddSingleton<IStorageService>(new StorageService(WebRootPath));
            services.AddScoped<IAcademyService, AcademyService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddTransient<IEmailHelperService, EmailHelperService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<ICourseService, CourseService>();
			services.AddScoped<IInstructorService, InstructorService>();
			
            return services;
        }
    }
}
