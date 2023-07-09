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
    public class CityVehicleConfiguration : IEntityTypeConfiguration<CityVehicle>
    {
        public void Configure(EntityTypeBuilder<CityVehicle> builder)
        {
            builder.HasKey(x => new { x.CityId, x.VehicleId });
        }
    }
}
