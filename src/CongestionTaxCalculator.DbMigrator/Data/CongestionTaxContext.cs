using Microsoft.EntityFrameworkCore;
using CongestionTaxCalculator.Domain.Persistence;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CongestionTaxCalculator.DbMigrator.Data
{
    public class CongestionTaxContext : DbContext
    {
        public CongestionTaxContext(DbContextOptions<CongestionTaxContext> options) : base(options)
        {
        }

        public DbSet<City> Cities => Set<City>();
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();

        public DbSet<CityVehicle> CityVehicles => Set<CityVehicle>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);




            /* Configure your own tables/entities inside here */



            builder.Entity<City>()
                            .Property(c => c.Name)
                            .HasMaxLength(500);

            builder.Entity<City>()
                .HasIndex(c => c.Name).IsUnique();

            builder.Entity<Vehicle>()
                            .Property(v => v.VehicleType)
                            .HasMaxLength(50);

            builder.Entity<Vehicle>()
                            .HasIndex(v => v.VehicleType).IsUnique();

            builder.Entity<City>().HasMany(x => x.CityVehicles).WithOne(x => x.City).HasForeignKey(x => x.CityId);
            builder.Entity<Vehicle>().HasMany(x => x.CityVehicles).WithOne(x => x.Vehicle).HasForeignKey(x => x.VehicleId);
            builder.Entity<CityVehicle>().HasKey(x => new { x.CityId, x.VehicleId });
        }



        //protected override async void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Customer>().HasData
        //    if (!(await Customers.AnyAsync()))
        //    {
        //        await Customers.AddRangeAsync(CustomerGenerator.GenerateCustomers());
        //        await SaveChangesAsync();

        //    }

        //}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableDetailedErrors(true);
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
    }
}
