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
            if (!(await congestionTaxContext.Vehicles.AnyAsync()))
            {
                List<Vehicle> vehicles = new List<Vehicle>() {
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
                List<City> cities = new List<City>()
                {
                    new City { Name = "Gothenburg" },
                    new City { Name = "London" }
                };
                await congestionTaxContext.Cities.AddRangeAsync(cities);
                await congestionTaxContext.SaveChangesAsync();

                logger.LogInformation($"Seed Cities- Database associated with context {typeof(CongestionTaxContextSeed).Name}");
            }

            if (!(await congestionTaxContext.CityVehicles.AnyAsync()))
            {

                                                                    var temp = new CityVehicle { City = congestionTaxContext.Cities.Where(x => x.Name == "Gothenburg").Single(), Vehicle = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Emergency").Single(), IsExempt = true };
                                                                    temp = new CityVehicle { City = congestionTaxContext.Cities.Where(x => x.Name == "Gothenburg").Single(), Vehicle = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Bus").Single(), IsExempt = true };
                                                                    temp = new CityVehicle { City = congestionTaxContext.Cities.Where(x => x.Name == "Gothenburg").Single(), Vehicle = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Diplomat").Single(), IsExempt = true };
                                                                    temp = new CityVehicle { City = congestionTaxContext.Cities.Where(x => x.Name == "Gothenburg").Single(), Vehicle = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Motorcycles").Single(), IsExempt = true };
                                                                    temp = new CityVehicle { City = congestionTaxContext.Cities.Where(x => x.Name == "Gothenburg").Single(), Vehicle = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Foreign").Single(), IsExempt = true };
                                                                    temp = new CityVehicle { City = congestionTaxContext.Cities.Where(x => x.Name == "Gothenburg").Single(), Vehicle = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Car").Single(), IsExempt = false };

                    
                    
                                                                    temp = new CityVehicle { City = congestionTaxContext.Cities.Where(x => x.Name == "London").Single(), Vehicle = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Emergency").Single(), IsExempt = true };
                                                                    temp = new CityVehicle { City = congestionTaxContext.Cities.Where(x => x.Name == "London").Single(), Vehicle = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Bus").Single(), IsExempt = true };
                                                                    temp = new CityVehicle { City = congestionTaxContext.Cities.Where(x => x.Name == "London").Single(), Vehicle = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Diplomat").Single(), IsExempt = true };
                                                                    temp = new CityVehicle { City = congestionTaxContext.Cities.Where(x => x.Name == "London").Single(), Vehicle = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Motorcycles").Single(), IsExempt = true };
                                                                    temp = new CityVehicle { City = congestionTaxContext.Cities.Where(x => x.Name == "London").Single(), Vehicle = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Foreign").Single(), IsExempt = true };
                                                                    temp = new CityVehicle { City = congestionTaxContext.Cities.Where(x => x.Name == "London").Single(), Vehicle = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Car").Single(), IsExempt = false };
                                                                    temp = new CityVehicle { City = congestionTaxContext.Cities.Where(x => x.Name == "London").Single(), Vehicle = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Van").Single(), IsExempt = false };
                                                                    temp = new CityVehicle { City = congestionTaxContext.Cities.Where(x => x.Name == "London").Single(), Vehicle = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Minibus").Single(), IsExempt = false };
                                                                    temp = new CityVehicle { City = congestionTaxContext.Cities.Where(x => x.Name == "London").Single(), Vehicle = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Truck").Single(), IsExempt = false };


                var cityVehicles = new List<CityVehicle>()
                {
                                                                    new CityVehicle { City = congestionTaxContext.Cities.Where(x=>x.Name=="Gothenburg").Single() , Vehicle = congestionTaxContext.Vehicles.Where(x=>x.VehicleType=="Emergency").Single(), IsExempt = true } ,
                                                                    new CityVehicle { City = congestionTaxContext.Cities.Where(x=>x.Name=="Gothenburg").Single() , Vehicle = congestionTaxContext.Vehicles.Where(x=>x.VehicleType=="Bus").Single(), IsExempt = true } ,
                                                                    new CityVehicle { City = congestionTaxContext.Cities.Where(x=>x.Name=="Gothenburg").Single() , Vehicle = congestionTaxContext.Vehicles.Where(x=>x.VehicleType=="Diplomat").Single(), IsExempt = true } ,
                                                                    new CityVehicle { City = congestionTaxContext.Cities.Where(x=>x.Name=="Gothenburg").Single() , Vehicle = congestionTaxContext.Vehicles.Where(x=>x.VehicleType=="Motorcycles").Single(), IsExempt = true } ,
                                                                    new CityVehicle { City = congestionTaxContext.Cities.Where(x=>x.Name=="Gothenburg").Single() , Vehicle = congestionTaxContext.Vehicles.Where(x=>x.VehicleType=="Foreign").Single(), IsExempt = true } ,
                                                                    new CityVehicle { City = congestionTaxContext.Cities.Where(x=>x.Name=="Gothenburg").Single() , Vehicle = congestionTaxContext.Vehicles.Where(x=>x.VehicleType=="Car").Single(), IsExempt = false } 

                    , // Gothenburg City
                    
                                                                    new CityVehicle { City = congestionTaxContext.Cities.Where(x=>x.Name=="London").Single() , Vehicle = congestionTaxContext.Vehicles.Where(x=>x.VehicleType=="Emergency").Single(), IsExempt = true } ,
                                                                    new CityVehicle { City = congestionTaxContext.Cities.Where(x=>x.Name=="London").Single() , Vehicle = congestionTaxContext.Vehicles.Where(x=>x.VehicleType=="Bus").Single(), IsExempt = true } ,
                                                                    new CityVehicle { City = congestionTaxContext.Cities.Where(x=>x.Name=="London").Single() , Vehicle = congestionTaxContext.Vehicles.Where(x=>x.VehicleType=="Diplomat").Single(), IsExempt = true } ,
                                                                    new CityVehicle { City = congestionTaxContext.Cities.Where(x=>x.Name=="London").Single() , Vehicle = congestionTaxContext.Vehicles.Where(x=>x.VehicleType=="Motorcycles").Single(), IsExempt = true } ,
                                                                    new CityVehicle { City = congestionTaxContext.Cities.Where(x=>x.Name=="London").Single() , Vehicle = congestionTaxContext.Vehicles.Where(x=>x.VehicleType=="Foreign").Single(), IsExempt = true } ,
                                                                    new CityVehicle { City = congestionTaxContext.Cities.Where(x=>x.Name=="London").Single() , Vehicle = congestionTaxContext.Vehicles.Where(x=>x.VehicleType=="Car").Single(), IsExempt = false } ,
                                                                    new CityVehicle { City = congestionTaxContext.Cities.Where(x=>x.Name=="London").Single() , Vehicle = congestionTaxContext.Vehicles.Where(x=>x.VehicleType=="Van").Single(), IsExempt = false } ,
                                                                    new CityVehicle { City = congestionTaxContext.Cities.Where(x=>x.Name=="London").Single() , Vehicle = congestionTaxContext.Vehicles.Where(x=>x.VehicleType=="Minibus").Single(), IsExempt = false } ,
                                                                    new CityVehicle { City = congestionTaxContext.Cities.Where(x=>x.Name=="London").Single() , Vehicle = congestionTaxContext.Vehicles.Where(x=>x.VehicleType=="Truck").Single(), IsExempt = false } ,
                     // London City
                };
                await congestionTaxContext.CityVehicles.AddRangeAsync(cityVehicles);
                await congestionTaxContext.SaveChangesAsync();

                logger.LogInformation($"Seed CityVehicle- Database associated with context {typeof(CongestionTaxContextSeed).Name}");
            }
        }
    }


}
