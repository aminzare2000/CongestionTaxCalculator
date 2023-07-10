using Microsoft.EntityFrameworkCore;
using CongestionTaxCalculator.Domain.Persistence;
using CongestionTaxCalculator.Domain.Common;


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

            Vehicle emergency; Vehicle bus; Vehicle diplomat; Vehicle motorcycles;
            Vehicle foreign; Vehicle van; Vehicle minibus; Vehicle car; Vehicle truck;
           
            #region Vehicles 
            if (!(await congestionTaxContext.Vehicles.AnyAsync()))
            {

                emergency = new Vehicle { VehicleType = "Emergency" };
                bus = new Vehicle { VehicleType = "Bus" };
                diplomat = new Vehicle { VehicleType = "Diplomat" };
                motorcycles = new Vehicle { VehicleType = "Motorcycles" };
                foreign = new Vehicle { VehicleType = "Foreign" };
                van = new Vehicle { VehicleType = "Van" };
                minibus = new Vehicle { VehicleType = "Minibus" };
                car = new Vehicle { VehicleType = "Car" };
                truck = new Vehicle { VehicleType = "Truck" };


                await congestionTaxContext.Vehicles.AddAsync(emergency); await congestionTaxContext.Vehicles.AddAsync(bus); await congestionTaxContext.Vehicles.AddAsync(diplomat);
                await congestionTaxContext.Vehicles.AddAsync(motorcycles); await congestionTaxContext.Vehicles.AddAsync(foreign); await congestionTaxContext.Vehicles.AddAsync(van);
                await congestionTaxContext.Vehicles.AddAsync(minibus); await congestionTaxContext.Vehicles.AddAsync(car); await congestionTaxContext.Vehicles.AddAsync(truck);

                await congestionTaxContext.SaveChangesAsync();

                logger.LogInformation($"Seed Vehicles- Database associated with context {typeof(CongestionTaxContextSeed).Name}");
            }
            else
            {
                emergency = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Emergency").Single();
                bus = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Bus").Single();
                diplomat = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Diplomat").Single();
                motorcycles = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Motorcycles").Single();
                foreign = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Foreign").Single();
                van = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Van").Single();
                minibus = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Minibus").Single();
                car = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Car").Single();
                truck = congestionTaxContext.Vehicles.Where(x => x.VehicleType == "Truck").Single();
            }
            #endregion


            #region Cities 
            City londonCity; City gothenburgCity;
            if (!(await congestionTaxContext.Cities.AnyAsync()))
            {

                gothenburgCity = new City { Name = "Gothenburg" };
                londonCity = new City { Name = "London" };

                await congestionTaxContext.Cities.AddAsync(gothenburgCity); await congestionTaxContext.Cities.AddAsync(londonCity);
                await congestionTaxContext.SaveChangesAsync();

                logger.LogInformation($"Seed Cities- Database associated with context {typeof(CongestionTaxContextSeed).Name}");
            }
            else
            {
                londonCity = congestionTaxContext.Cities.Where(x => x.Name == "London").Single();
                gothenburgCity = congestionTaxContext.Cities.Where(x => x.Name == "Gothenburg").Single();
                congestionTaxContext.Entry(gothenburgCity).State = EntityState.Unchanged;
                congestionTaxContext.Entry(londonCity).State = EntityState.Unchanged;
            }
            #endregion





            #region CityVehicles 
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
            #endregion

            #region TariffDefinition            
            
            TariffDefinition tariffDefinitionGothenburg_NO1_2013; TariffDefinition tariffDefinitionGothenburg_NO1_2012; TariffDefinition tariffDefinitionGothenburg_NO2_2012; 
            TariffDefinition tariffDefinitionLondon_NO1_2013;

            if (!(await congestionTaxContext.TariffDefinitions.AnyAsync()))
            {

                //--------------------------------------- Tariff Defination: No:1 , Year = 2013----------------------------------------------------------------------------
                tariffDefinitionGothenburg_NO1_2013 = new TariffDefinition { City = gothenburgCity, TariffNO = 1, StartTariffYear = 2013, IsActive = true };

                //--------------------------------------- Tariff Defination: No:1 , Year = 2012----------------------------------------------------------------------------
                tariffDefinitionGothenburg_NO1_2012 = new TariffDefinition { City = gothenburgCity, TariffNO = 1, StartTariffYear = 2012, IsActive = false };

                //--------------------------------------- Tariff Defination: No:1 , Year = 2012----------------------------------------------------------------------------
                tariffDefinitionGothenburg_NO2_2012 = new TariffDefinition { City = gothenburgCity, TariffNO = 2, StartTariffYear = 2012, IsActive = false };

                //--------------------------------------- Tariff Defination: No:1 , Year = 2013----------------------------------------------------------------------------
                tariffDefinitionLondon_NO1_2013 = new TariffDefinition { City = londonCity, TariffNO = 1, StartTariffYear = 2013, IsActive = true };

                //---------------------------------------Gothenburg City----------------------------------------------------------------------------
                await congestionTaxContext.TariffDefinitions.AddAsync(tariffDefinitionGothenburg_NO1_2013); await congestionTaxContext.TariffDefinitions.AddAsync(tariffDefinitionGothenburg_NO1_2012); await congestionTaxContext.TariffDefinitions.AddAsync(tariffDefinitionGothenburg_NO2_2012);

                //---------------------------------------London City----------------------------------------------------------------------------
                await congestionTaxContext.TariffDefinitions.AddAsync(tariffDefinitionLondon_NO1_2013);

                await congestionTaxContext.SaveChangesAsync();
                logger.LogInformation($"Seed TariffDefinitions- Database associated with context {typeof(CongestionTaxContextSeed).Name}");
            }
            else
            {
                tariffDefinitionGothenburg_NO1_2013 = congestionTaxContext.TariffDefinitions.Where(x => x.City.Name==gothenburgCity.Name && x.StartTariffYear==2013 && x.TariffNO==1 && x.IsActive).Single();
                congestionTaxContext.Entry(tariffDefinitionGothenburg_NO1_2013).State = EntityState.Unchanged;

                tariffDefinitionLondon_NO1_2013 = congestionTaxContext.TariffDefinitions.Where(x => x.City.Name == londonCity.Name && x.StartTariffYear == 2013 && x.TariffNO == 1 && x.IsActive).Single();
                congestionTaxContext.Entry(tariffDefinitionLondon_NO1_2013).State = EntityState.Unchanged;
            }


            #endregion

            #region TariffCost  
            TariffCost tariffCost_NO1_2013_1; TariffCost tariffCost_NO1_2013_2; TariffCost tariffCost_NO1_2013_3; TariffCost tariffCost_NO1_2013_4; TariffCost tariffCost_NO1_2013_5; TariffCost tariffCost_NO1_2013_6; TariffCost tariffCost_NO1_2013_7; TariffCost tariffCost_NO1_2013_8; TariffCost tariffCost_NO1_2013_9; TariffCost tariffCost_NO1_2013_10; TariffCost tariffCost_NO1_2013_11;
            TariffCost tariffLondonCost_NO1_2013_1; TariffCost tariffLondonCost_NO1_2013_2; TariffCost tariffLondonCost_NO1_2013_3; TariffCost tariffLondonCost_NO1_2013_4; TariffCost tariffLondonCost_NO1_2013_5; TariffCost tariffLondonCost_NO1_2013_6; TariffCost tariffLondonCost_NO1_2013_7; TariffCost tariffLondonCost_NO1_2013_8; TariffCost tariffLondonCost_NO1_2013_9; TariffCost tariffLondonCost_NO1_2013_10; TariffCost tariffLondonCost_NO1_2013_11;
            List<TariffCost> tariffCosts_NO1_2013List;
            List<TariffCost> tariffLondonCosts_NO1_2013List;

            if (!(await congestionTaxContext.TariffCosts.AnyAsync()))
            {
                //------------------------------------------TariffCost: Gothenburg , No: 1 , Year = 2013 , IsActive ---------------------------------------
                tariffCost_NO1_2013_1 = new TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(0, 0, 0), ToTime = new TimeSpan(5, 59, 59), Amount = 0.00m };
                tariffCost_NO1_2013_2 = new TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(6, 0, 0), ToTime = new TimeSpan(6, 29, 59), Amount = 8.00m };
                tariffCost_NO1_2013_3 = new TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(6, 30, 0), ToTime = new TimeSpan(6, 59, 59), Amount = 13.00m };
                tariffCost_NO1_2013_4 = new TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(7, 0, 0), ToTime = new TimeSpan(7, 59, 59), Amount = 18.00m };
                tariffCost_NO1_2013_5 = new TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(8, 0, 0), ToTime = new TimeSpan(8, 29, 59), Amount = 13.00m };

                tariffCost_NO1_2013_6 = new TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(8, 30, 0), ToTime = new TimeSpan(14, 59, 59), Amount = 8.00m };
                tariffCost_NO1_2013_7 = new TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(15, 0, 0), ToTime = new TimeSpan(15, 29, 59), Amount = 13.00m };
                tariffCost_NO1_2013_8 = new TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(15, 30, 0), ToTime = new TimeSpan(16, 59, 59), Amount = 18.00m };
                tariffCost_NO1_2013_9 = new TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(17, 0, 0), ToTime = new TimeSpan(17, 59, 59), Amount = 13.00m };

                tariffCost_NO1_2013_10 = new TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(18, 0, 0), ToTime = new TimeSpan(18, 29, 59), Amount = 8.00m };
                tariffCost_NO1_2013_11 = new TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(18, 30, 0), ToTime = new TimeSpan(23, 59, 59), Amount = 0.00m };

                await congestionTaxContext.TariffCosts.AddAsync(tariffCost_NO1_2013_1); await congestionTaxContext.TariffCosts.AddAsync(tariffCost_NO1_2013_2); await congestionTaxContext.TariffCosts.AddAsync(tariffCost_NO1_2013_3);
                await congestionTaxContext.TariffCosts.AddAsync(tariffCost_NO1_2013_4); await congestionTaxContext.TariffCosts.AddAsync(tariffCost_NO1_2013_5); await congestionTaxContext.TariffCosts.AddAsync(tariffCost_NO1_2013_6);
                await congestionTaxContext.TariffCosts.AddAsync(tariffCost_NO1_2013_7); await congestionTaxContext.TariffCosts.AddAsync(tariffCost_NO1_2013_8); await congestionTaxContext.TariffCosts.AddAsync(tariffCost_NO1_2013_9);
                await congestionTaxContext.TariffCosts.AddAsync(tariffCost_NO1_2013_10); await congestionTaxContext.TariffCosts.AddAsync(tariffCost_NO1_2013_11);



                //------------------------------------------TariffCost: London , No: 1 , Year = 2013 , IsActive ---------------------------------------
                tariffLondonCost_NO1_2013_1 = new TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(0, 0, 0), ToTime = new TimeSpan(5, 59, 59), Amount = 0.00m };
                tariffLondonCost_NO1_2013_2 = new TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(6, 0, 0), ToTime = new TimeSpan(6, 29, 59), Amount = 18.00m };
                tariffLondonCost_NO1_2013_3 = new TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(6, 30, 0), ToTime = new TimeSpan(6, 59, 59), Amount = 20.00m };
                tariffLondonCost_NO1_2013_4 = new TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(7, 0, 0), ToTime = new TimeSpan(7, 59, 59), Amount = 20.00m };
                tariffLondonCost_NO1_2013_5 = new TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(8, 0, 0), ToTime = new TimeSpan(8, 29, 59), Amount = 40.00m };

                tariffLondonCost_NO1_2013_6 = new TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(8, 30, 0), ToTime = new TimeSpan(14, 59, 59), Amount = 8.00m };
                tariffLondonCost_NO1_2013_7 = new TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(15, 0, 0), ToTime = new TimeSpan(15, 29, 59), Amount = 13.00m };
                tariffLondonCost_NO1_2013_8 = new TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(15, 30, 0), ToTime = new TimeSpan(16, 59, 59), Amount = 20.00m };
                tariffLondonCost_NO1_2013_9 = new TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(17, 0, 0), ToTime = new TimeSpan(17, 59, 59), Amount = 40.00m };

                tariffLondonCost_NO1_2013_10 = new TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(18, 0, 0), ToTime = new TimeSpan(18, 29, 59), Amount = 8.00m };
                tariffLondonCost_NO1_2013_11 = new TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(18, 30, 0), ToTime = new TimeSpan(23, 59, 59), Amount = 0.00m };

                await congestionTaxContext.TariffCosts.AddAsync(tariffLondonCost_NO1_2013_1); await congestionTaxContext.TariffCosts.AddAsync(tariffLondonCost_NO1_2013_2); await congestionTaxContext.TariffCosts.AddAsync(tariffLondonCost_NO1_2013_3);
                await congestionTaxContext.TariffCosts.AddAsync(tariffLondonCost_NO1_2013_4); await congestionTaxContext.TariffCosts.AddAsync(tariffLondonCost_NO1_2013_5); await congestionTaxContext.TariffCosts.AddAsync(tariffLondonCost_NO1_2013_6);
                await congestionTaxContext.TariffCosts.AddAsync(tariffLondonCost_NO1_2013_7); await congestionTaxContext.TariffCosts.AddAsync(tariffLondonCost_NO1_2013_8); await congestionTaxContext.TariffCosts.AddAsync(tariffLondonCost_NO1_2013_9);
                await congestionTaxContext.TariffCosts.AddAsync(tariffLondonCost_NO1_2013_10); await congestionTaxContext.TariffCosts.AddAsync(tariffLondonCost_NO1_2013_11);


                await congestionTaxContext.SaveChangesAsync();
                logger.LogInformation($"Seed TariffCosts- Database associated with context {typeof(CongestionTaxContextSeed).Name}");
            }
            else
            {
                tariffCosts_NO1_2013List = congestionTaxContext.TariffCosts.Where(x => x.TariffDefinitionId == tariffDefinitionGothenburg_NO1_2013.Id).ToList();
                tariffLondonCosts_NO1_2013List = congestionTaxContext.TariffCosts.Where(x => x.TariffDefinitionId == tariffDefinitionLondon_NO1_2013.Id).ToList();
            }
            #endregion

            #region TariffSetting


            TariffSetting tariffSettingGothenburg_NO1_2013; 
            TariffSetting tariffSettingLondon_NO1_2013;

            if (!(await congestionTaxContext.TariffSettings.AnyAsync()))
            {

                //--------------------------------------- Tariff Setting: No:1 , Year = 2013 , IsACtive , Gothenburg----------------------------------------------------------------------------
                tariffSettingGothenburg_NO1_2013 = new TariffSetting { NumberTaxFreeDaysBeforeHoliday = 1, MaxTaxAmount = 60.00m, TaxFreeMonthCalender = MONTH.July, TariffDefinition = tariffDefinitionGothenburg_NO1_2013 };

                //--------------------------------------- Tariff Setting: No:1 , Year = 2013 , IsACtive , London----------------------------------------------------------------------------
                tariffSettingLondon_NO1_2013 = new TariffSetting { NumberTaxFreeDaysBeforeHoliday = 2, MaxTaxAmount = 60.00m, TaxFreeMonthCalender = MONTH.May, TariffDefinition = tariffDefinitionLondon_NO1_2013 };


                //---------------------------------------Gothenburg City----------------------------------------------------------------------------
                await congestionTaxContext.TariffSettings.AddAsync(tariffSettingGothenburg_NO1_2013); 

                //---------------------------------------London City----------------------------------------------------------------------------
                await congestionTaxContext.TariffSettings.AddAsync(tariffSettingLondon_NO1_2013);

                await congestionTaxContext.SaveChangesAsync();
                logger.LogInformation($"Seed TariffSettings- Database associated with context {typeof(CongestionTaxContextSeed).Name}");
            }
            else
            {


                tariffSettingGothenburg_NO1_2013 = congestionTaxContext.TariffSettings.Where(x => x.TariffDefinitionId == tariffDefinitionGothenburg_NO1_2013.Id).Single();
                congestionTaxContext.Entry(tariffSettingGothenburg_NO1_2013).State = EntityState.Unchanged;

                tariffSettingLondon_NO1_2013 = congestionTaxContext.TariffSettings.Where(x => x.TariffDefinitionId == tariffDefinitionLondon_NO1_2013.Id).Single();
                congestionTaxContext.Entry(tariffSettingLondon_NO1_2013).State = EntityState.Unchanged;
            }
            #endregion



            #region PublicHoliday

            if (!(await congestionTaxContext.PublicHolidays.AnyAsync()))
            {

                //--------------------------------------- PublicHoliday:  Gothenburg----------------------------------------------------------------------------
                await congestionTaxContext.PublicHolidays.AddAsync( new PublicHoliday { DateHoliday = new DateTime(2013,1,2), TariffSettingId= tariffSettingGothenburg_NO1_2013.Id });
                await congestionTaxContext.PublicHolidays.AddAsync(new PublicHoliday { DateHoliday = new DateTime(2013, 4, 7), TariffSettingId = tariffSettingGothenburg_NO1_2013.Id });
                await congestionTaxContext.PublicHolidays.AddAsync(new PublicHoliday { DateHoliday = new DateTime(2013, 4, 10), TariffSettingId = tariffSettingGothenburg_NO1_2013.Id });
                await congestionTaxContext.PublicHolidays.AddAsync(new PublicHoliday { DateHoliday = new DateTime(2013, 5, 10), TariffSettingId = tariffSettingGothenburg_NO1_2013.Id });

                //--------------------------------------- PublicHoliday:  London----------------------------------------------------------------------------
                await congestionTaxContext.PublicHolidays.AddAsync(new PublicHoliday { DateHoliday = new DateTime(2013, 1, 2), TariffSettingId = tariffSettingLondon_NO1_2013.Id });
                await congestionTaxContext.PublicHolidays.AddAsync(new PublicHoliday { DateHoliday = new DateTime(2013, 4, 7), TariffSettingId = tariffSettingLondon_NO1_2013.Id });

                await congestionTaxContext.SaveChangesAsync();
                logger.LogInformation($"Seed PublicHolidays- Database associated with context {typeof(CongestionTaxContextSeed).Name}");
            }

            #endregion

            #region WorkingDays

            if (!(await congestionTaxContext.WorkingDays.AnyAsync()))
            {

                //--------------------------------------- WorkingDay of Settings----------------------------------------------------------------------------
                await congestionTaxContext.WorkingDays.AddAsync(new WorkingDay { day = DAYS.Saturday, IsWeekend = true, TariffSettings = new List<TariffSetting>() { tariffSettingGothenburg_NO1_2013, tariffSettingLondon_NO1_2013 } });
                await congestionTaxContext.WorkingDays.AddAsync(new WorkingDay { day = DAYS.Sunday, IsWeekend = true, TariffSettings = new List<TariffSetting>() { tariffSettingGothenburg_NO1_2013, tariffSettingLondon_NO1_2013 } });

                await congestionTaxContext.WorkingDays.AddAsync(new WorkingDay { day = DAYS.Monday, IsWeekend = false, TariffSettings = new List<TariffSetting>() { tariffSettingGothenburg_NO1_2013, tariffSettingLondon_NO1_2013 } });
                await congestionTaxContext.WorkingDays.AddAsync(new WorkingDay { day = DAYS.Thursday, IsWeekend = false, TariffSettings = new List<TariffSetting>() { tariffSettingGothenburg_NO1_2013, tariffSettingLondon_NO1_2013 } });
                await congestionTaxContext.WorkingDays.AddAsync(new WorkingDay { day = DAYS.Wednesday, IsWeekend = false, TariffSettings = new List<TariffSetting>() { tariffSettingGothenburg_NO1_2013, tariffSettingLondon_NO1_2013 } });
                await congestionTaxContext.WorkingDays.AddAsync(new WorkingDay { day = DAYS.Tuesday, IsWeekend = false, TariffSettings = new List<TariffSetting>() { tariffSettingGothenburg_NO1_2013, tariffSettingLondon_NO1_2013 } });
                await congestionTaxContext.WorkingDays.AddAsync(new WorkingDay { day = DAYS.Friday, IsWeekend = false, TariffSettings = new List<TariffSetting>() { tariffSettingGothenburg_NO1_2013, tariffSettingLondon_NO1_2013 } });


                await congestionTaxContext.SaveChangesAsync();
                logger.LogInformation($"Seed WorkingDays- Database associated with context {typeof(CongestionTaxContextSeed).Name}");
            }

            #endregion
        }
    }


}
