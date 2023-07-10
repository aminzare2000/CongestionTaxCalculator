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
    public class PublicHolidayConfiguration : IEntityTypeConfiguration<PublicHoliday>
    {
        public void Configure(EntityTypeBuilder<PublicHoliday> builder)
        {
            builder.HasOne(c => c.TariffSetting)
                   .WithMany(c => c.PublicHolidays)
                   .HasForeignKey(c => c.TariffSettingId);

            builder.Property(c => c.Description)
                .HasMaxLength(2000);

        }
    }



    public class WorkingDayConfiguration : IEntityTypeConfiguration<WorkingDay>
    {
        public void Configure(EntityTypeBuilder<WorkingDay> builder)
        {
            builder.HasMany(c => c.TariffSettings)
                   .WithMany(c => c.WorkingDays);
        }
    }
}
