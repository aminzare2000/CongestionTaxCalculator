using Microsoft.EntityFrameworkCore;
using CongestionTaxCalculator.Domain.Persistence;
using CongestionTaxCalculator.Domain.Persistence.Configuration;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using CongestionTaxCalculator.Infrastructure;

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

        public DbSet<TariffDefinition> TariffDefinitions => Set<TariffDefinition>();
        public DbSet<TariffCost> TariffCosts => Set<TariffCost>();

        public DbSet<TariffSetting> TariffSettings => Set<TariffSetting>();

        public DbSet<PublicHoliday> PublicHolidays => Set<PublicHoliday>();

        public DbSet<WorkingDay> WorkingDays => Set<WorkingDay>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new CityVehicleConfiguration());

            builder.ApplyConfiguration(new TariffDefineConfiguration());
            builder.ApplyConfiguration(new TariffDefineConfiguration());
            builder.ApplyConfiguration(new TariffCostConfiguration());
            builder.ApplyConfiguration(new TariffSettingConfiguration());


            builder.ApplyConfiguration(new PublicHolidayConfiguration());
            builder.ApplyConfiguration(new WorkingDayConfiguration());

            /* Configure your own tables/entities inside here */



            //builder.Entity<City>()
            //                .Property(c => c.Name)
            //                .HasMaxLength(500);

            //builder.Entity<City>()
            //    .HasIndex(c => c.Name).IsUnique();

            //builder.Entity<Vehicle>()
            //                .Property(v => v.VehicleType)
            //                .HasMaxLength(50);

            //builder.Entity<Vehicle>()
            //                .HasIndex(v => v.VehicleType).IsUnique();

            //builder.Entity<City>().HasMany(x => x.CityVehicles).WithOne(x => x.City).HasForeignKey(x => x.CityId);
            //builder.Entity<Vehicle>().HasMany(x => x.CityVehicles).WithOne(x => x.Vehicle).HasForeignKey(x => x.VehicleId);
            //builder.Entity<CityVehicle>().HasKey(x => new { x.CityId, x.VehicleId });




        }

        //protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        //{
        //    base.ConfigureConventions(builder);

        //    builder.Properties<TimeOnly>()
        //        .HaveConversion<TimeOnlyConverter>();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableDetailedErrors(true);
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
    }
}
