using CongestionTaxCalculator.Domain.Persistence;
using CongestionTaxCalculator.Domain.Persistence.InterfaceRepository;
using CongestionTaxCalculator.EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.EFCore.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(CongestionTaxContext context) : base(context)
        {
        }

        public City? GetByName(string name) => _context.Cities.Where(c=>c.Name == name)?.FirstOrDefault();

    }
}
