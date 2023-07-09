using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CongestionTaxCalculator.Domain.Persistence
{
    public class TariffDefinition
    {

        public int Id { get; set; }

        //Tariff Number
        public int TariffNO { get; set; } = 1;
        public int TariffYear { get; set; } = 2013;

        public bool IsActive { get; set; } = false;

        public virtual ICollection<City>? Cities { get; set; }

        public virtual ICollection<TariffCost>? TariffCosts { get; set; }

        public TariffSetting TariffSetting { get; set; } = new TariffSetting();
    }
}