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
    public class TariffCostConfiguration : IEntityTypeConfiguration<TariffCost>
    {
        public void Configure(EntityTypeBuilder<TariffCost> builder)
        {
            builder.HasOne(c => c.TariffDefinition)
                   .WithMany(c => c.TariffCosts)
                   .HasForeignKey(c => c.TariffDefinitionId);
        }
    }

    public class TariffDefineConfiguration : IEntityTypeConfiguration<TariffDefinition>
    {
        public void Configure(EntityTypeBuilder<TariffDefinition> builder)
        {
            builder.HasMany(x => x.Cities)
                .WithOne(x => x.TariffDefinition)
                .HasForeignKey(x => x.TariffDefinitionId);

            builder.HasIndex(c => new { c.TariffYear , c.TariffNO }).IsUnique();
        }
    }
}
