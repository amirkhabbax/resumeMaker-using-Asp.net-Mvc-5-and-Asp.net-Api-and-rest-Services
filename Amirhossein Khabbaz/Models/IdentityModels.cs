﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Amirhossein_Khabbaz.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Amirhossein_Khabbaz.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Skill> Skills { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Interests> Interests { get; set; }

        public DbSet<WorkExperience> WorkExperiences { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Education> Educations { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}