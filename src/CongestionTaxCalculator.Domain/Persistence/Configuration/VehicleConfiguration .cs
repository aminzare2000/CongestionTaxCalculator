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
    public class VehicleConfiguration : IEntityTypeConfiguration<ExemptVehicle>
    {
        public void Configure(EntityTypeBuilder<ExemptVehicle> builder)
        {
            builder.Property(v => v.VehicleType)
                .HasMaxLength(50);
            builder.HasIndex(v => v.VehicleType);

            builder.HasOne(x => x.TariffDefinition).WithMany(x => x.ExemptVehicles).HasForeignKey(x => x.TariffDefinitionId);

        }
    }
}
