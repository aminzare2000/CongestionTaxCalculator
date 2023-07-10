using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Persistence
{
    public class TariffCost
    {
        public int Id { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public Decimal Amount { get; set; }

        public TariffDefinition TariffDefinition { get; set; } = null!;
        public int TariffDefinitionId { get; set; }
    }
}
