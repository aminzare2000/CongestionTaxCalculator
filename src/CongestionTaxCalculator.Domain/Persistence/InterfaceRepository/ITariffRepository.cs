using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Persistence.InterfaceRepository
{
    public interface ITariffDefinitionRepository : IRepository<TariffDefinition>
    {
        public IEnumerable<TariffDefinition> GetTariff(int cityId, int startTariffYear, int tariffNO);

        public TariffDefinition GetActiveTariff(string CityName);
    }
}
