using Microsoft.EntityFrameworkCore;
using StreamlineAcademy.Application.Abstractions.IRepositories;
using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Persistence.Repositories
{
    public class ProfileRepository:BaseRepository<User>, IProfileRepository
    {
        private readonly StreamlineDbContet context;

        public ProfileRepository(StreamlineDbContet context) : base(context)
        {
            this.context = context;
        }

        //public async Task<User> GetAddressInfoByIdAsync(string query)
        //{
        //    return await context.Users.FromSqlRaw(query).Include(u => u.SuperAdmin).FirstOrDefaultAsync();
        //}
       
    }
}
