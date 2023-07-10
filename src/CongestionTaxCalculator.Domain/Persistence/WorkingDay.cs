using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Persistence
{
    public class WorkingDay
    {

        public int Id { get; set; }
        public DAYS day { get; set; }

        public bool IsWeekend { get; set; }

        public virtual ICollection<TariffSetting> TariffSettings { get; set; } = new HashSet<TariffSetting>();
    }
}