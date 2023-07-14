using CongestionTaxCalculator.Domain.Persistence;
using CongestionTaxCalculator.Domain.Persistence.InterfaceRepository;
using CongestionTaxCalculator.EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.EFCore.Repository
{
    public class TariffDefinitionRepository : Repository<TariffDefinition>, ITariffDefinitionRepository
    {
        private readonly CityRepository _cityRepository;
        public TariffDefinitionRepository(CongestionTaxContext context) : base(context)
        {
            _cityRepository = new CityRepository(_context);
        }

        public IEnumerable<TariffDefinition> GetTariff(int cityId, int startTariffYear, int tariffNO)
            => _context.TariffDefinitions.Where(x => x.CityId == cityId && x.StartTariffYear == startTariffYear && x.TariffNO == tariffNO);

        private TariffDefinition? GetActiveTariff(int cityId) 
            => _context.TariffDefinitions.Where(x => x.CityId == cityId && x.IsActive)?.Include( z=> z.TariffCosts)
                                                                                      .Include(v=>v.ExemptVehicles)
                                                                                      .Include(t=>t.TariffSetting)
                                                                                          .ThenInclude(h=>h!.PublicHolidays).FirstOrDefault();


        public TariffDefinition GetActiveTariff(string CityName)
        {
            
            City city = _cityRepository.GetByName(CityName) ?? throw new ApplicationException("NotFoundCityException");
            TariffDefinition tariffDefinition = GetActiveTariff(cityId: city.Id) ?? throw new ApplicationException("NotFoundTariffDefinitionException");     
            if(tariffDefinition.TariffCosts is null) throw new ApplicationException("NotFoundTariffCostsException");
            if (tariffDefinition.TariffSetting is null) throw new ApplicationException("NotFoundTariffSettingException");
            if (tariffDefinition.TariffSetting.PublicHolidays is null) throw new ApplicationException("NotFoundPublicHolidayException");
            return tariffDefinition;
        }

    }
}
