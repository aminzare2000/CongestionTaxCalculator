using Microsoft.EntityFrameworkCore;
using CongestionTaxCalculator.Domain.Persistence;


namespace CongestionTaxCalculator.DbMigrator.Data
{
    public class CongestionTaxContextSeed
    {
        public static async Task SeedAsync(CongestionTaxContext congestionTaxContext, ILogger<CongestionTaxContextSeed> logger)
        {
            //### Tax Exempt vehicles
            //- Emergency vehicles
            //- Busses
            //- Diplomat vehicles
            //- Motorcycles
            //- Military vehicles
            //- Foreign vehicle
            //### Other vehicles
            //- Van
            //- Minibus
            //- Car
            //- Truck
            List<Vehicle>? vehicles = null;
            if (!(await congestionTaxContext.Vehicles.AnyAsync()))
            {
                vehicles = new List<Vehicle>() {
                        new Vehicle {  VehicleType="Emergency" },
                        new Vehicle {  VehicleType="Bus" },
                        new Vehicle {  VehicleType="Diplomat" },
                        new Vehicle {  VehicleType="Motorcycles" },
                        new Vehicle {  VehicleType="Foreign" },
                        new Vehicle {  VehicleType="Van"},
                        new Vehicle {  VehicleType="Minibus" },
                        new Vehicle {  VehicleType="Car"},
                        new Vehicle {  VehicleType="Truck"} };
                await congestionTaxContext.Vehicles.AddRangeAsync(vehicles);
                await congestionTaxContext.SaveChangesAsync();

                logger.LogInformation($"Seed Vehicles- Database associated with context {typeof(CongestionTaxContextSeed).Name}");
            }


            if (!(await congestionTaxContext.Cities.AnyAsync()))
            {

                vehicles = congestionTaxContext.Vehicles.ToList();
                List<City> cities = new List<City>()
                {
                    new City {
                        Name = "Gothenburg" ,
                        Vehicles = new List<Vehicle>() {
                                                                    vehicles.Where(x=>x.VehicleType=="Emergency").Single(),
                                                                    vehicles.Where(x=>x.VehicleType=="Bus").Single(),
                                                                    vehicles.Where(x=>x.VehicleType=="Diplomat").Single(),
                                                                    vehicles.Where(x=>x.VehicleType=="Motorcycles").Single(),
                                                                    vehicles.Where(x=>x.VehicleType=="Foreign").Single(),
                                                                    vehicles.Where(x=>x.VehicleType=="Car").Single(),
                        }
                    }, // Gothenburg City
                    new City {
                        Name = "London" ,
                        Vehicles = new List<Vehicle>() {
                                                                    vehicles.Where(x=>x.VehicleType=="Emergency").Single(),
                                                                    vehicles.Where(x=>x.VehicleType=="Bus").Single(),
                                                                    vehicles.Where(x=>x.VehicleType=="Diplomat").Single(),
                                                                    vehicles.Where(x=>x.VehicleType=="Motorcycles").Single(),
                                                                    vehicles.Where(x=>x.VehicleType=="Foreign").Single(),
                                                                    vehicles.Where(x=>x.VehicleType=="Car").Single(),
                                                                    vehicles.Where(x=>x.VehicleType=="Van").Single(),
                                                                    vehicles.Where(x=>x.VehicleType=="Minibus").Single(),
                                                                    vehicles.Where(x=>x.VehicleType=="Truck").Single(),

                        }
                    }, // London City

                };
                await congestionTaxContext.Cities.AddRangeAsync(cities);
                await congestionTaxContext.SaveChangesAsync();

                logger.LogInformation($"Seed Cities- Database associated with context {typeof(CongestionTaxContextSeed).Name}");
            }
        }
    }


}
