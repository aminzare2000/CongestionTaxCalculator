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

namespace CongestionTaxCalculator.EFCore.Data
{
    public class CongestionTaxContext : DbContext
    {
        public CongestionTaxContext(DbContextOptions<CongestionTaxContext> options) : base(options)
        {
            
        }

        public CongestionTaxContext():base()
        {

        }

        public virtual DbSet<City> Cities => Set<City>();
        public virtual DbSet<ExemptVehicle> ExemptVehicles => Set<ExemptVehicle>();
        public virtual DbSet<TariffDefinition> TariffDefinitions => Set<TariffDefinition>();
        public virtual DbSet<TariffCost> TariffCosts => Set<TariffCost>();

        public virtual DbSet<TariffSetting> TariffSettings => Set<TariffSetting>();

        public virtual DbSet<PublicHoliday> PublicHolidays => Set<PublicHoliday>();

        public virtual DbSet<WorkingDay> WorkingDays => Set<WorkingDay>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());

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

            //builder.Entity<ExemptVehicle>()
            //                .Property(v => v.VehicleType)
            //                .HasMaxLength(50);

            //builder.Entity<ExemptVehicle>()
            //                .HasIndex(v => v.VehicleType).IsUnique();

            //builder.Entity<City>().HasMany(x => x.CityVehicles).WithOne(x => x.City).HasForeignKey(x => x.CityId);
            //builder.Entity<ExemptVehicle>().HasMany(x => x.CityVehicles).WithOne(x => x.ExemptVehicle).HasForeignKey(x => x.VehicleId);
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
