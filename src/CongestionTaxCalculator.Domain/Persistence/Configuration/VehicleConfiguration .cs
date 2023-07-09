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
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(v => v.VehicleType)
                .HasMaxLength(50);
            builder.HasIndex(v => v.VehicleType).IsUnique();

            builder.HasMany(x => x.CityVehicles).WithOne(x => x.Vehicle).HasForeignKey(x => x.VehicleId);

        }
    }
}
