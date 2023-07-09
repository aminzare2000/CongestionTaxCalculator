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

            City londonCity = congestionTaxContext.Cities.Where(x => x.Name == "London").Single();
            City gothenburgCity = congestionTaxContext.Cities.Where(x => x.Name == "Gothenburg").Single();

            Vehicle emergency = congestionTaxContext.Vehicles.Where(x=>x.VehicleType == "Emergency").Single();
            Vehicle bus = congestionTaxContext.Vehicles.Where(x=>x.VehicleType == "Bus").Single();
            Vehicle diplomat = congestionTaxContext.Vehicles.Where(x=>x.VehicleType == "Diplomat").Single();
            Vehicle motorcycles = congestionTaxContext.Vehicles.Where(x=>x.VehicleType == "Motorcycles").Single();
            Vehicle foreign = congestionTaxContext.Vehicles.Where(x=>x.VehicleType == "Foreign").Single();
            Vehicle van = congestionTaxContext.Vehicles.Where(x=>x.VehicleType == "Van").Single();
            Vehicle minibus = congestionTaxContext.Vehicles.Where(x=>x.VehicleType == "Minibus").Single();
            Vehicle car = congestionTaxContext.Vehicles.Where(x=>x.VehicleType == "Car").Single();
            Vehicle truck = congestionTaxContext.Vehicles.Where(x=>x.VehicleType == "Truck").Single();

            if (!(await congestionTaxContext.CityVehicles.AnyAsync()))
            {


                var cityVehicles = new List<CityVehicle>()
                {
                     // Vehicles Type of Gothenburg City
                    new CityVehicle { City = gothenburgCity , Vehicle = emergency, IsExempt = true } ,
                    new CityVehicle { City = gothenburgCity , Vehicle = bus, IsExempt = true } ,
                    new CityVehicle { City = gothenburgCity , Vehicle = diplomat, IsExempt = true } ,
                    new CityVehicle { City = gothenburgCity , Vehicle = motorcycles, IsExempt = true } ,
                    new CityVehicle { City = gothenburgCity , Vehicle = foreign, IsExempt = true } ,
                    new CityVehicle { City = gothenburgCity , Vehicle = car, IsExempt = false } 

                    ,
                     // Vehicles Type of London City                    
                    new CityVehicle { City = londonCity , Vehicle = emergency, IsExempt = true } ,
                    new CityVehicle { City = londonCity , Vehicle = bus, IsExempt = true } ,
                    new CityVehicle { City = londonCity , Vehicle = diplomat, IsExempt = true } ,
                    new CityVehicle { City = londonCity , Vehicle = motorcycles, IsExempt = true } ,
                    new CityVehicle { City = londonCity , Vehicle = foreign, IsExempt = true } ,
                    new CityVehicle { City = londonCity , Vehicle = car, IsExempt = false },
                    new CityVehicle { City = londonCity , Vehicle = van, IsExempt = false },
                    new CityVehicle { City = londonCity , Vehicle = minibus, IsExempt = false },
                    new CityVehicle { City = londonCity , Vehicle = truck, IsExempt = false },

                };
                await congestionTaxContext.CityVehicles.AddRangeAsync(cityVehicles);
                await congestionTaxContext.SaveChangesAsync();

                logger.LogInformation($"Seed CityVehicle- Database associated with context {typeof(CongestionTaxContextSeed).Name}");
            }

            #region Tariff Defination            
            congestionTaxContext.Entry(gothenburgCity).State = EntityState.Unchanged;

            //--------------------------------------- Tariff Defination: No:1 , Year = 2013----------------------------------------------------------------------------
            Tariff tariff1 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(0, 0, 0), ToTime = new TimeSpan(5, 59, 59), Amount = 0.00m };

            Tariff tariff2 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(6, 0, 0), ToTime = new TimeSpan(6, 29, 59), Amount = 8.00m };
            Tariff tariff3 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(6, 30, 0), ToTime = new TimeSpan(6, 59, 59), Amount = 13.00m };
            Tariff tariff4 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(7, 0, 0), ToTime = new TimeSpan(7, 59, 59), Amount = 18.00m };
            Tariff tariff5 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(8, 0, 0), ToTime = new TimeSpan(8, 29, 59), Amount = 13.00m };

            Tariff tariff6 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(8, 30, 0), ToTime = new TimeSpan(14, 59, 59), Amount = 8.00m };
            Tariff tariff7 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(15, 0, 0), ToTime = new TimeSpan(15, 29, 59), Amount = 13.00m };
            Tariff tariff8 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(15, 30, 0), ToTime = new TimeSpan(16, 59, 59), Amount = 18.00m };
            Tariff tariff9 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(17, 0, 0), ToTime = new TimeSpan(17, 59, 59), Amount = 13.00m };

            Tariff tariff10 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(18, 0, 0), ToTime = new TimeSpan(18, 29, 59), Amount = 8.00m };
            Tariff tariff11 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(18, 30, 0), ToTime = new TimeSpan(23, 59, 59), Amount = 0.00m };

            //--------------------------------------- Tariff Defination: No:2 , Year = 2013----------------------------------------------------------------------------
            Tariff tariffNO2_2013_1 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(0, 0, 0), ToTime = new TimeSpan(5, 59, 59), Amount = 0.00m, TariffNO=2 };

            Tariff tariffNO2_2013_2 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(6, 0, 0), ToTime = new TimeSpan(6, 29, 59), Amount = 8.00m, TariffNO=2 };
            Tariff tariffNO2_2013_3 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(6, 30, 0), ToTime = new TimeSpan(6, 59, 59), Amount = 13.00m, TariffNO=2 };
            Tariff tariffNO2_2013_4 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(7, 0, 0), ToTime = new TimeSpan(7, 59, 59), Amount = 18.00m, TariffNO=2 };
            Tariff tariffNO2_2013_5 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(8, 0, 0), ToTime = new TimeSpan(8, 29, 59), Amount = 13.00m, TariffNO=2 };

            Tariff tariffNO2_2013_6 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(8, 30, 0), ToTime = new TimeSpan(14, 59, 59), Amount = 8.00m, TariffNO=2 };
            Tariff tariffNO2_2013_7 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(15, 0, 0), ToTime = new TimeSpan(15, 29, 59), Amount = 13.00m, TariffNO=2 };
            Tariff tariffNO2_2013_8 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(15, 30, 0), ToTime = new TimeSpan(16, 59, 59), Amount = 18.00m, TariffNO=2 };
            Tariff tariffNO2_2013_9 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(17, 0, 0), ToTime = new TimeSpan(17, 59, 59), Amount = 13.00m, TariffNO=2 };

            Tariff tariffNO2_2013_10 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(18, 0, 0), ToTime = new TimeSpan(18, 29, 59), Amount = 8.00m, TariffNO=2 };
            Tariff tariffNO2_2013_11 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(18, 30, 0), ToTime = new TimeSpan(23, 59, 59), Amount = 0.00m, TariffNO=2 };


            //--------------------------------------- Tariff Defination: No:1 , Year = 2012----------------------------------------------------------------------------
            Tariff tariffNO1_2012_1 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(0, 0, 0), ToTime = new TimeSpan(5, 59, 59), Amount = 0.00m, DefineTariffYear=2012 };

            Tariff tariffNO1_2012_2 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(6, 0, 0), ToTime = new TimeSpan(6, 29, 59), Amount = 8.00m, DefineTariffYear=2012 };
            Tariff tariffNO1_2012_3 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(6, 30, 0), ToTime = new TimeSpan(6, 59, 59), Amount = 13.00m, DefineTariffYear=2012 };
            Tariff tariffNO1_2012_4 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(7, 0, 0), ToTime = new TimeSpan(7, 59, 59), Amount = 18.00m, DefineTariffYear=2012 };
            Tariff tariffNO1_2012_5 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(8, 0, 0), ToTime = new TimeSpan(8, 29, 59), Amount = 13.00m, DefineTariffYear=2012 };

            Tariff tariffNO1_2012_6 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(8, 30, 0), ToTime = new TimeSpan(14, 59, 59), Amount = 8.00m, DefineTariffYear=2012 };
            Tariff tariffNO1_2012_7 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(15, 0, 0), ToTime = new TimeSpan(15, 29, 59), Amount = 13.00m, DefineTariffYear=2012 };
            Tariff tariffNO1_2012_8 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(15, 30, 0), ToTime = new TimeSpan(16, 59, 59), Amount = 18.00m, DefineTariffYear=2012 };
            Tariff tariffNO1_2012_9 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(17, 0, 0), ToTime = new TimeSpan(17, 59, 59), Amount = 13.00m, DefineTariffYear=2012 };

            Tariff tariffNO1_2012_10 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(18, 0, 0), ToTime = new TimeSpan(18, 29, 59), Amount = 8.00m, DefineTariffYear=2012 };
            Tariff tariffNO1_2012_11 = new Tariff { City = gothenburgCity, FromTime = new TimeSpan(18, 30, 0), ToTime = new TimeSpan(23, 59, 59), Amount = 0.00m, DefineTariffYear=2012 };
            #endregion

            if (!(await congestionTaxContext.Tariffs.AnyAsync()))
            {


                #region Tariff Add Db
                await congestionTaxContext.Tariffs.AddAsync(tariff1);  await congestionTaxContext.Tariffs.AddAsync(tariff2);  await congestionTaxContext.Tariffs.AddAsync(tariff3);
                await congestionTaxContext.Tariffs.AddAsync(tariff4);  await congestionTaxContext.Tariffs.AddAsync(tariff5);  await congestionTaxContext.Tariffs.AddAsync(tariff6);
                await congestionTaxContext.Tariffs.AddAsync(tariff7);  await congestionTaxContext.Tariffs.AddAsync(tariff8);  await congestionTaxContext.Tariffs.AddAsync(tariff9);
                await congestionTaxContext.Tariffs.AddAsync(tariff10); await congestionTaxContext.Tariffs.AddAsync(tariff11);
                
                await congestionTaxContext.Tariffs.AddAsync(tariffNO2_2013_1); await congestionTaxContext.Tariffs.AddAsync(tariffNO2_2013_2); await congestionTaxContext.Tariffs.AddAsync(tariffNO2_2013_3);
                await congestionTaxContext.Tariffs.AddAsync(tariffNO2_2013_4); await congestionTaxContext.Tariffs.AddAsync(tariffNO2_2013_5); await congestionTaxContext.Tariffs.AddAsync(tariffNO2_2013_6);
                await congestionTaxContext.Tariffs.AddAsync(tariffNO2_2013_7); await congestionTaxContext.Tariffs.AddAsync(tariffNO2_2013_8); await congestionTaxContext.Tariffs.AddAsync(tariffNO2_2013_9);
                await congestionTaxContext.Tariffs.AddAsync(tariffNO2_2013_10); await congestionTaxContext.Tariffs.AddAsync(tariffNO2_2013_11);
                
                await congestionTaxContext.Tariffs.AddAsync(tariffNO1_2012_1); await congestionTaxContext.Tariffs.AddAsync(tariffNO1_2012_2); await congestionTaxContext.Tariffs.AddAsync(tariffNO1_2012_3);
                await congestionTaxContext.Tariffs.AddAsync(tariffNO1_2012_4); await congestionTaxContext.Tariffs.AddAsync(tariffNO1_2012_5); await congestionTaxContext.Tariffs.AddAsync(tariffNO1_2012_6);
                await congestionTaxContext.Tariffs.AddAsync(tariffNO1_2012_7); await congestionTaxContext.Tariffs.AddAsync(tariffNO1_2012_8); await congestionTaxContext.Tariffs.AddAsync(tariffNO1_2012_9);
                await congestionTaxContext.Tariffs.AddAsync(tariffNO1_2012_10); await congestionTaxContext.Tariffs.AddAsync(tariffNO1_2012_11);
                #endregion
                await congestionTaxContext.SaveChangesAsync();
                logger.LogInformation($"Seed Tariffs- Database associated with context {typeof(CongestionTaxContextSeed).Name}");
            }
        }
    }


}
