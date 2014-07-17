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
        public LibsRUsContext() : base("LibsRUsContext")
        {
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
    }

    //public class ApplicationDbContext : 
    //{
    //    public ApplicationDbContext() : base("DefaultConnection")
    //    {
    //    }
    //}
}