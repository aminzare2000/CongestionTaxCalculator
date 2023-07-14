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

        public IEnumerable<TariffDefinition> GetAllTariff(int cityId, int startTariffYear, int tariffNO)
            => _context.TariffDefinitions.Where(x => x.CityId == cityId && x.StartTariffYear == startTariffYear && x.TariffNO == tariffNO);

        private TariffDefinition? GetActiveTariff(int cityId, int startTariffYear, int tariffNO) 
            => _context.TariffDefinitions.Where(x => x.CityId == cityId && x.StartTariffYear == startTariffYear && x.TariffNO == tariffNO && x.IsActive)?.Include( z=> z.TariffCosts)
                                                                                      .Include(v=>v.ExemptVehicles)
                                                                                      .Include(t=>t.TariffSetting)
                                                                                          .ThenInclude(h=>h!.PublicHolidays).FirstOrDefault();


        public TariffDefinition GetActiveTariff(string cityName, int startTariffYear, int tariffNO)
        {
            
            City city = _cityRepository.GetByName(cityName) ?? throw new ApplicationException("NotFoundCityException");
            TariffDefinition tariffDefinition = GetActiveTariff(cityId: city.Id, startTariffYear: startTariffYear, tariffNO:tariffNO) ?? throw new ApplicationException("NotFoundActiveTariffDefinitionException");     
            if(tariffDefinition.TariffCosts is null) throw new ApplicationException("NotFoundTariffCostsException");
            if (tariffDefinition.TariffSetting is null) throw new ApplicationException("NotFoundTariffSettingException");
            if (tariffDefinition.TariffSetting.PublicHolidays is null) throw new ApplicationException("NotFoundPublicHolidayException");
            return tariffDefinition;
        }

    }
}
