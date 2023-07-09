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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);




            /* Configure your own tables/entities inside here */


            builder.Entity<City>()
                            .HasMany(v => v.Vehicles)
                            .WithMany(c => c.Cities);


            builder.Entity<Vehicle>()
                            .Property(v => v.Id)
                            .ValueGeneratedNever();

            builder.Entity<Vehicle>()
                            .Property(v => v.VehicleType)
                            .HasMaxLength(50);

            builder.Entity<City>()
                            .Property(c => c.Name)
                            .HasMaxLength(500);




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
