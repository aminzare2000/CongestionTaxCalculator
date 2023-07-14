using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Persistence.InterfaceRepository
{
    public interface ITariffDefinitionRepository : IRepository<TariffDefinition>
    {
        public IEnumerable<TariffDefinition> GetAllTariff(int cityId, int startTariffYear, int tariffNO);

        TariffDefinition GetActiveTariff(string cityName, int startTariffYear, int tariffNO);
    }
}
