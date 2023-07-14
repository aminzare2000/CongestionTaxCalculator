using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://code-maze.com/migrations-and-seed-data-efcore/
namespace CongestionTaxCalculator.Domain.Persistence.Configuration
{
    public class TariffDefineConfiguration : IEntityTypeConfiguration<TariffDefinition>
    {
        public void Configure(EntityTypeBuilder<TariffDefinition> builder)
        {
            builder.HasOne(x => x.City)
                .WithMany(x => x.TariffDefinitions)
                .HasForeignKey(x => x.CityId);

            builder.HasMany(x => x.TariffCosts)
                .WithOne(x => x.TariffDefinition)
                .HasForeignKey(x => x.TariffDefinitionId);

            builder.HasMany(x => x.ExemptVehicles)
                .WithOne(x => x.TariffDefinition)
                .HasForeignKey(x => x.TariffDefinitionId);


            builder.HasOne(c => c.TariffSetting)
                   .WithOne(c => c.TariffDefinition)
                   .HasForeignKey<TariffSetting>(c=>c.TariffDefinitionId)
                   .IsRequired();
                   

            builder.HasIndex(c => new { c.CityId, c.StartTariffYear , c.TariffNO }).IsUnique();
        }
    }

    public class TariffCostConfiguration : IEntityTypeConfiguration<TariffCost>
    {
        public void Configure(EntityTypeBuilder<TariffCost> builder)
        {
            builder.HasOne(c => c.TariffDefinition)
                   .WithMany(c => c.TariffCosts)
                   .HasForeignKey(c => c.TariffDefinitionId);
        }
    }

    public class TariffSettingConfiguration : IEntityTypeConfiguration<TariffSetting>
    {
        public void Configure(EntityTypeBuilder<TariffSetting> builder)
        {

            builder.HasOne(c => c.TariffDefinition)
                   .WithOne(c => c.TariffSetting)
                   .HasForeignKey<TariffSetting>(c=>c.TariffDefinitionId)
                   .IsRequired();

            builder.HasMany(c=>c.PublicHolidays)
                .WithOne(c=>c.TariffSetting)
                .HasForeignKey(c=>c.TariffSettingId);


            builder.HasMany(c => c.WorkingDays)
                .WithMany(c => c.TariffSettings);
        }
    }
}
