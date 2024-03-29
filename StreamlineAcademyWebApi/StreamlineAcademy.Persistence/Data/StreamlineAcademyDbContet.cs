using Microsoft.EntityFrameworkCore;
using StreamlineAcademy.Application.Utils;
using StreamlineAcademy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StreamlineAcademy.Domain.Enums;
using System.Threading.Tasks;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace StreamlineAcademy.Persistence.Data
{
    public class StreamlineDbContet : DbContext
    {
        public StreamlineDbContet(DbContextOptions<StreamlineDbContet> options):base(options) 
        {
           
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; }
        public DbSet<Academy> Academies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<AcademyType> AcademyTypes { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ConfigureIndexesAndData();

        }

        


        
        
    }
}
