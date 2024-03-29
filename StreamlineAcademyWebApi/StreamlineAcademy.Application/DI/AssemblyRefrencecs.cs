using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

        public static IServiceCollection AddAplicationService(this IServiceCollection services,string WebRootPath )
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IEnquiryService,EnquiryService>();
            services.AddScoped<IFileService, FileService>();
            services.AddSingleton<IStorageService>(new StorageService(WebRootPath));
            services.AddScoped<IAcademyService, AcademyService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddTransient<IEmailHelperService, EmailHelperService>();
            return services;
        }
    }
}
