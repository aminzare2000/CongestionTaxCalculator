using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CongestionTaxCalculator.Domain.Persistence
{
    public class PublicHoliday
    {

        public int Id { get; set; }
        public DateTime DateHoliday { get; set; }

        public string Description { get; set; } = string.Empty; 

        public TariffSetting TariffSetting { get; set; } = null!;
        public int TariffSettingId { get; set; }
    }
}