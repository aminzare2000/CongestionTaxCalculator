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
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {            
            builder.Property(c => c.Name)
                            .HasMaxLength(500);
            builder.HasIndex(c => c.Name).IsUnique();
            builder.HasMany(x => x.CityVehicles).WithOne(x => x.City).HasForeignKey(x => x.CityId);


            builder.HasOne(t => t.TariffDefinition)
                            .WithMany(t=>t.Cities)
                            .HasForeignKey(t=>t.TariffDefinitionId);
                    

        }
    }
}
