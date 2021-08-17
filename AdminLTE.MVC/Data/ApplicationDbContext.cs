using System;
using System.Collections.Generic;
using System.Text;
using AdminLTE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminLTE.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<TerritorialCommunity> TerritorialCommunities { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            IdentityRole role = new IdentityRole
            {
                Name = ENV.AdminRole,
                NormalizedName = ENV.AdminRole.ToUpper()
            };

            IdentityUser user = new IdentityUser
            {
                Email = ENV.AdminEmail,
                NormalizedEmail=ENV.AdminEmail.ToUpper(),
                UserName = ENV.AdminEmail,
                NormalizedUserName=ENV.AdminEmail.ToUpper(),
                PasswordHash = "AQAAAAEAACcQAAAAEN7DD2NJJON38Cnw2UI3EIpg/hGe7q5VK7ABsvsOKYJPqJx3j6AP4EcwV7LpzRWlvQ=="

            };

            builder.Entity<IdentityRole>().HasData(role);
            builder.Entity<IdentityUser>().HasData(user);

            var userRole = new IdentityUserRole<string>() { RoleId = role.Id, UserId = user.Id };
            builder.Entity<IdentityUserRole<string>>().HasData(userRole);


        }

    }
}
