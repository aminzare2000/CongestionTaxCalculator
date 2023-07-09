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
                        new Vehicle { Id=1 , VehicleType="Emergency" },
                        new Vehicle { Id=2 , VehicleType="Bus" },
                        new Vehicle { Id=3 , VehicleType="Diplomat" },
                        new Vehicle { Id=4 , VehicleType="Motorcycles" },
                        new Vehicle { Id=5 , VehicleType="Foreign" },
                        new Vehicle { Id=6 , VehicleType="Van"},
                        new Vehicle { Id=7 , VehicleType="Minibus" },
                        new Vehicle { Id=8 , VehicleType="Car"},
                        new Vehicle { Id=9 , VehicleType="Truck"} };
                await congestionTaxContext.Vehicles.AddRangeAsync(vehicles);
                await congestionTaxContext.SaveChangesAsync();

                logger.LogInformation($"Seed Vehicles- Database associated with context {typeof(CongestionTaxContextSeed).Name}");
            }


            if (!(await congestionTaxContext.Cities.AnyAsync()))
            {
                if (vehicles is null)
                {
                    vehicles = congestionTaxContext.Vehicles.ToList();
                }

                List<City> cities = new List<City>()
                {
                    new City {
                        Name = "Gothenburg" ,
                        Vehicles = new List<Vehicle>() {
                                                                    vehicles[0],
                                                                    vehicles[1],
                                                                    vehicles[2],
                                                                    vehicles[3],
                                                                    vehicles[4],
                                                                    vehicles[5],
                        }
                    }, // Gothenburg City
                    new City {
                        Name = "London" ,
                        Vehicles = new List<Vehicle>() {
                                                                    vehicles[0],
                                                                    vehicles[1],
                                                                    vehicles[2],
                                                                    vehicles[3],
                                                                    vehicles[4],
                                                                    vehicles[5],
                                                                    vehicles[6],
                                                                    vehicles[7],
                                                                    vehicles[8]
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
