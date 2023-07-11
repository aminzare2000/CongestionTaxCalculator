using CongestionTaxCalculator.Domain.Persistence;
using CongestionTaxCalculator.Domain.Persistence.InterfaceRepository;
using CongestionTaxCalculator.EFCore.Data;

namespace CongestionTaxCalculator.EFCore.Repository
{
    public class TariffDefinitionRepository : Repository<TariffDefinition>, ITariffDefinitionRepository
    {
        public TariffDefinitionRepository(CongestionTaxContext context) : base(context)
        {
        }

        public IEnumerable<TariffDefinition> GetTariff(int CityId, int StartTariffYear, int TariffNO)
            => _context.TariffDefinitions.Where(x => x.CityId == CityId && x.StartTariffYear == StartTariffYear && x.TariffNO == TariffNO);



    }
}
