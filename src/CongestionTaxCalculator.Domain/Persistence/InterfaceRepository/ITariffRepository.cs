using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Persistence.InterfaceRepository
{
    public interface ITariffDefinitionRepository : IRepository<TariffDefinition>
    {
        IEnumerable<TariffDefinition> GetTariff(int CityId, int StartTariffYear, int TariffNO);
    }
}
