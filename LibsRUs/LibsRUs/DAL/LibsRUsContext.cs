using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

using LibsRUs.Models;

namespace LibsRUs.DAL
{
    public class LibsRUsContext : IdentityDbContext<User>
    {
        //"throwIfV1Schema: false" - Fixes "The ConnectionString property has not been initialized."
        //For whatever reason...  2 hour headache.
        public LibsRUsContext() : base("LibsRUsContext", throwIfV1Schema: false)
        {
        }

        public static LibsRUsContext Create()
        {
            return new LibsRUsContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Change the name of the table to be Users instead of AspNetUsers
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<User>().ToTable("Users");
        }

        public DbSet<Lib> Libs { get; set; }
        public DbSet<LibTag> LibTags { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        //Join Tables
        //public DbSet<LibPlatform> LibPlatforms { get; set; }
        //public DbSet<LibProgrammingLanguage> LibProgrammingLanguages { get; set; }
    }
}