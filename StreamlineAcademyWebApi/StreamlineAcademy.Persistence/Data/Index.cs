using Microsoft.EntityFrameworkCore;
using StreamlineAcademy.Application.Utils;
using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Persistence.Data
{
    public static class Index
    {
        private static void ConfigureIndex(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enquiry>().HasIndex(x => x.Name);
            modelBuilder.Entity<Enquiry>().HasIndex(x => x.Email);
            modelBuilder.Entity<Academy>().HasIndex(x => x.AcademyName);
        }

        private static void setdata(ModelBuilder modelbuilder)
        {
            var Passwordsalt = AppEncryption.GenerateSalt();
            var commonId = Guid.NewGuid();
            modelbuilder.Entity<User>().HasData(

                new User()
                {

                    Id = commonId,
                    Name = "Ram",
                    Address = "123 Main Street,Bangalore",
                    PostalCode = "786545",
                    PhoneNumber = "8997654556",
                    Email = "ram@gmail.com",
                    Password = AppEncryption.CreatePassword("superadmin", Passwordsalt),
                    Salt = Passwordsalt,
                    UserRole = UserRole.SuperAdmin,
                    IsActive = true,
                    CreatedBy = Guid.Empty,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = Guid.Empty,
                    ModifiedDate = DateTime.Now,
                    DeletedBy = Guid.Empty

                }
            );

         }

        public static void ConfigureIndexesAndData(this ModelBuilder modelBuilder)
        {
            Index.ConfigureIndex(modelBuilder);
            Index.setdata(modelBuilder);
        }
}
}
