using Microsoft.EntityFrameworkCore;
using StreamlineAcademy.Application.Abstractions.Identity;
using StreamlineAcademy.Application.Abstractions.IRepositories;
using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Domain.Models.Responses;
using StreamlineAcademy.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Persistence.Repositories
{
    public class ProfileRepository : BaseRepository<User>, IProfileRepository
    {
        private readonly StreamlineDbContet context;
        private readonly IContextService contextService;

        public ProfileRepository(StreamlineDbContet context, IContextService contextService) : base(context)
        {
            this.context = context;
            this.contextService = contextService;
        }

        public async Task<AddressInfoResponseModel> GetAddressInfo(Guid? userId)
        {   
            var superadmin = await context.SuperAdmins
             .Include(a => a.User)
             .Include(a => a.Country)
             .Include(a => a.State)
             .Include(a => a.City)
             .FirstOrDefaultAsync(a => a.Id == userId);
            if (superadmin is not null)
            { 
                var response = new AddressInfoResponseModel
                {
                    Id =superadmin.User!.Id,
                    Address = superadmin.User.Address,
                    PostalCode = superadmin.User.PostalCode,
                    CountryName = superadmin.Country!.CountryName,
                    StateName = superadmin.State!.StateName,
                    CityName = superadmin.City!.CityName, 
                };
                return response;
            }
            return new AddressInfoResponseModel() { };
        }

        public async Task<int> UpdateAddressAsync(SuperAdmin superAdmin)
        {
            context.Set<SuperAdmin>().Update(superAdmin);
            return await context.SaveChangesAsync();
        }
    }
}
