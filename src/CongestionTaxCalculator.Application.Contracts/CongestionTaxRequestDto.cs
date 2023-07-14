using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.Contracts
{
    public class CongestionTaxRequestDto
    {
        public string CityName { get; set; } = string.Empty;
        public string VehicleType { get; set; } = "NotExempt";

        public List<DateTime> TrafficTimeSequence { get; set; } = new List<DateTime>();

    }
}
