using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Persistence
{
    public class Tariff
    {
        public int Id { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public Decimal Amount { get; set; }

        //Tariff Number
        public int TariffNO { get; set; } = 1;
        public int DefineTariffYear { get; set; } = 2013;
        public City City { get; set; } = null!;
        public int CityId { get; set; }
    }
}
