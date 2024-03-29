using Microsoft.EntityFrameworkCore;
using StreamlineAcademy.Application.Utils;
using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private static void SetData(ModelBuilder modelBuilder)
        {
            var Passwordsalt = AppEncryption.GenerateSalt();
            modelBuilder.Entity<SuperAdmin>().HasData(

                    new SuperAdmin()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Ram",
                        Email = "ram@gmail.com",
                        UserName = "superadmin@123",
                        Salt = Passwordsalt,
                        Password = AppEncryption.CreatePassword("superadmin", Passwordsalt),
                        PhoneNumber = "7267636376",
                        UserRole = UserRole.SuperAdmin,
                        CreatedDate = DateTime.Now,

                    }

            );
        }
        public static void ConfigureIndexesAndData(this ModelBuilder modelBuilder)
        {
            Index.ConfigureIndex(modelBuilder);
            Index.SetData(modelBuilder);
        }
    }
}
