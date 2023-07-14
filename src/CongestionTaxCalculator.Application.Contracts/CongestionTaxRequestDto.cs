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
        public int TariffNO { get; set; } = 1;
        public int StartTariffYear { get; set; } = 2013;

        /// <summary>
        ///  sorted date and time of all passes on one day
        /// </summary>
        public List<DateTime> TrafficTimeSequence { get; set; } = new List<DateTime>();

    }
}
