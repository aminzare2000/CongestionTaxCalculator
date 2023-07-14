using CongestionTaxCalculator.Domain.Persistence;
using CongestionTaxCalculator.Domain.Persistence.InterfaceRepository;
using CongestionTaxCalculator.EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.EFCore.Repository
{
    public class VehicleRepository : Repository<ExemptVehicle>, IVehicleRepository
    {
        public VehicleRepository(CongestionTaxContext context) : base(context)
        {
        }
        public ExemptVehicle? GetByVehicleType(string vehicleType) => _context.ExemptVehicles.Where(c => c.VehicleType == vehicleType)?.FirstOrDefault();




        //public City? GetByName(string name) { 
        //    var cit = _context.Cities.Where(c => c.Name == name)?.FirstOrDefault(); 
        //    //_context.Entry(cit).Collection(x=>x.CityVehicles).Load();
        //    return cit;
        //}

        //public IEnumerable<CityVehicle>? GetByName(string name) {
        //    var temp = _context.Cities.Where(c => c.Name == name).FirstOrDefault()?.CityVehicles;
        //        return temp; 
        //}

    }
}
