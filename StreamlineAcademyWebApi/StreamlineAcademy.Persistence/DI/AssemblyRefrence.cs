using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StreamlineAcademy.Application.Abstractions.IRepositories;
using StreamlineAcademy.Application.Abstractions.IServices;
using StreamlineAcademy.Persistence.Data;
using StreamlineAcademy.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Persistence.DI
{
    public static class AssemblyRefrence
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContextPool<StreamlineDbContet>(options => options.UseSqlServer(configuration.GetConnectionString("SLAcademyDBConnection")));
            services.AddScoped<IEnquiryRepository, EnquiryRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IAcademyRepository, AcademyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            return services;
        }
    }
}
