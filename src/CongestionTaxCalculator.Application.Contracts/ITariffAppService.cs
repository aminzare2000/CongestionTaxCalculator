using CongestionTaxCalculator.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.Contracts
{
    public interface ITariffAppService
    {        
        public City GetACity(string name);
        public TariffDefinition GenrateTariffDefination(CongestionTaxRequestDto request);


    }
}
