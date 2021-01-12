using DeviceInventory.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceInventory.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Subsidiary> Subsidiary { get; set; }
        public DbSet<EmployeeType> EmployeeType { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<DeviceModel> DeviceModel { get; set; }
        public DbSet<DeviceColor> DeviceColor { get; set; }
        public DbSet<DeviceType> DeviceType { get; set; }
        public DbSet<PropertyType> PropertyType { get; set; }
        public DbSet<Visitor> Visitor { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
       
        //override the onmodelcrete method from the base class
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            //Using non claustered index

            //builder.Entity<Attendance>().HasIndex(a => new { a.CheckTime, a.PersonnelNo }).IsUnique().ForSqlServerIsClustered(false).HasName("UQ_CheckTimePerssonelNo");
            builder.Entity<Profile>().HasIndex(p => p.EmployeeId).IsUnique();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();
                var connectionString = configuration.GetConnectionString("DeviceInventoryConnection");
                optionsBuilder.UseSqlServer(connectionString);

            }
        }
    }
}
