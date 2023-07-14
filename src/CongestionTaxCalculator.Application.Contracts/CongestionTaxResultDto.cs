using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongestionTaxCalculator.Domain.Model;

namespace CongestionTaxCalculator.Application.Contracts
{
    public class CongestionTaxResultDto
    {
        public Decimal TotalFee { get; set; } = 2013;
        public List<TariffCost> TrafficTimeSequence { get; set; } = new List<TariffCost>();

    }
}
