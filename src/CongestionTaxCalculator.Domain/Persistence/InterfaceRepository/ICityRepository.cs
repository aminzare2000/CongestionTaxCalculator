using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Persistence.InterfaceRepository
{
    public interface ICityRepository : IRepository<City>
    {
        City? GetByName(string name);
        //public IEnumerable<CityVehicle>? GetByName(string name);
    }
}
