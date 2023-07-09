using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CongestionTaxCalculator.Domain.Persistence
{
    public class TariffSetting
    {

        public int Id { get; set; }

        public int NoTaxFreeDaysBeforeHoliday { get; set; } = 1;

        public Decimal MaxTaxAmount { get; set; } = 60.00m;

        public MONTH TaxFreeMonthCalender { get; set; } = MONTH.July;

        public TariffDefinition TariffDefinition { get; set; } = null!;
        public int TariffDefinitionId { get; set; }

    }
}