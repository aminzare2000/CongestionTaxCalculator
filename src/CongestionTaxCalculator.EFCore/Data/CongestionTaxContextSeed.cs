using Microsoft.EntityFrameworkCore;
using CongestionTaxCalculator.Domain.Persistence;
using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.EFCore.Repository;


namespace CongestionTaxCalculator.EFCore.Data
{
    public class CongestionTaxContextSeed
    {
        public static async Task SeedAsync(CongestionTaxContext congestionTaxContext, ILogger<CongestionTaxContextSeed> logger)
        {
            var gothenburgCity = new City { Name = "Gothenburg" };
            var londonCity = new City { Name = "London" };
            if (!(await congestionTaxContext.TariffDefinitions.AnyAsync()))
            {
                //---------------------------------------Gothenburg City Tariff Defination: No:1 , Year = 2013 , IsActive = true----------------------------------------------------------------------------
                congestionTaxContext.TariffDefinitions.Add(new TariffDefinition
                {
                    City = gothenburgCity,
                    TariffNO = 1,
                    StartTariffYear = 2013,
                    IsActive = true,
                    ExemptVehicles = new List<ExemptVehicle>
                    {
                        new ExemptVehicle { VehicleType = "Emergency" },
                        new ExemptVehicle { VehicleType = "Bus" },
                        new ExemptVehicle { VehicleType = "Diplomat" },
                        new ExemptVehicle { VehicleType = "Motorcycles" },
                        new ExemptVehicle { VehicleType = "Foreign" },
                    },
                    TariffCosts = new List<TariffCost>
                    {
                        new TariffCost { FromTime = new TimeSpan(0, 0, 0), ToTime = new TimeSpan(5, 59, 59), Amount = 0.00m },
                        new TariffCost { FromTime = new TimeSpan(6, 0, 0), ToTime = new TimeSpan(6, 29, 59), Amount = 8.00m },
                        new TariffCost { FromTime = new TimeSpan(6, 30, 0), ToTime = new TimeSpan(6, 59, 59), Amount = 13.00m },
                        new TariffCost { FromTime = new TimeSpan(7, 0, 0), ToTime = new TimeSpan(7, 59, 59), Amount = 18.00m },
                        new TariffCost { FromTime = new TimeSpan(8, 0, 0), ToTime = new TimeSpan(8, 29, 59), Amount = 13.00m },

                        new TariffCost { FromTime = new TimeSpan(8, 30, 0), ToTime = new TimeSpan(14, 59, 59), Amount = 8.00m },
                        new TariffCost { FromTime = new TimeSpan(15, 0, 0), ToTime = new TimeSpan(15, 29, 59), Amount = 13.00m },
                        new TariffCost { FromTime = new TimeSpan(15, 30, 0), ToTime = new TimeSpan(16, 59, 59), Amount = 18.00m },
                        new TariffCost { FromTime = new TimeSpan(17, 0, 0), ToTime = new TimeSpan(17, 59, 59), Amount = 13.00m },

                        new TariffCost { FromTime = new TimeSpan(18, 0, 0), ToTime = new TimeSpan(18, 29, 59), Amount = 8.00m },
                        new TariffCost { FromTime = new TimeSpan(18, 30, 0), ToTime = new TimeSpan(23, 59, 59), Amount = 0.00m },
                    },
                    TariffSetting = new TariffSetting
                    {
                        NumberTaxFreeDaysBeforeHoliday = 1,
                        MaxTaxAmount = 60.00m,
                        TaxFreeMonthCalender = MONTH.July,
                        PublicHolidays = new List<PublicHoliday>()
                                                    {
                                                        new PublicHoliday { DateHoliday = new DateTime(2013,1,2) },
                                                        new PublicHoliday { DateHoliday = new DateTime(2013, 4, 7) },
                                                        new PublicHoliday { DateHoliday = new DateTime(2013, 4, 10) },
                                                        new PublicHoliday { DateHoliday = new DateTime(2013, 5, 10) },
                                                    },
                        WorkingDays = new List<WorkingDay>() {
                                                        new WorkingDay { day = DAYS.Saturday, IsWeekend = true},
                                                        new WorkingDay { day = DAYS.Sunday, IsWeekend = true},
                                                        new WorkingDay { day = DAYS.Monday, IsWeekend = false},
                                                        new WorkingDay { day = DAYS.Thursday, IsWeekend = false},
                                                        new WorkingDay { day = DAYS.Wednesday, IsWeekend = false},
                                                        new WorkingDay { day = DAYS.Tuesday, IsWeekend = false},
                                                        new WorkingDay { day = DAYS.Friday, IsWeekend = false},

                                                    }
                    },
                });

                //---------------------------------------Gothenburg City Tariff Defination: No:2 , Year = 2013 , IsActive = false----------------------------------------------------------------------------
                congestionTaxContext.TariffDefinitions.Add(new TariffDefinition
                {
                    City = gothenburgCity,
                    TariffNO = 2,
                    StartTariffYear = 2013,
                    IsActive = false,
                    ExemptVehicles = new List<ExemptVehicle>
                    {
                        new ExemptVehicle { VehicleType = "Emergency" },
                        new ExemptVehicle { VehicleType = "Bus" },
                        new ExemptVehicle { VehicleType = "MiniBus" },
                        new ExemptVehicle { VehicleType = "Diplomat" },
                        new ExemptVehicle { VehicleType = "Motorcycles" },
                        new ExemptVehicle { VehicleType = "Foreign" },
                    },
                    TariffCosts = new List<TariffCost>
                    {
                        new TariffCost { FromTime = new TimeSpan(0, 0, 0), ToTime = new TimeSpan(5, 59, 59), Amount = 0.00m },
                        new TariffCost { FromTime = new TimeSpan(6, 0, 0), ToTime = new TimeSpan(6, 29, 59), Amount = 5.00m },
                        new TariffCost { FromTime = new TimeSpan(6, 30, 0), ToTime = new TimeSpan(6, 59, 59), Amount = 10.00m },
                        new TariffCost { FromTime = new TimeSpan(7, 0, 0), ToTime = new TimeSpan(7, 59, 59), Amount = 12.00m },
                        new TariffCost { FromTime = new TimeSpan(8, 0, 0), ToTime = new TimeSpan(8, 29, 59), Amount = 10.00m },

                        new TariffCost { FromTime = new TimeSpan(8, 30, 0), ToTime = new TimeSpan(14, 59, 59), Amount = 5.00m },
                        new TariffCost { FromTime = new TimeSpan(15, 0, 0), ToTime = new TimeSpan(15, 29, 59), Amount = 10.00m },
                        new TariffCost { FromTime = new TimeSpan(15, 30, 0), ToTime = new TimeSpan(16, 59, 59), Amount = 12.00m },
                        new TariffCost { FromTime = new TimeSpan(17, 0, 0), ToTime = new TimeSpan(17, 59, 59), Amount = 10.00m },

                        new TariffCost { FromTime = new TimeSpan(18, 0, 0), ToTime = new TimeSpan(18, 29, 59), Amount = 5.00m },
                        new TariffCost { FromTime = new TimeSpan(18, 30, 0), ToTime = new TimeSpan(23, 59, 59), Amount = 0.00m },
                    },
                    TariffSetting = new TariffSetting
                    {
                        NumberTaxFreeDaysBeforeHoliday = 1,
                        MaxTaxAmount = 60.00m,
                        TaxFreeMonthCalender = MONTH.July,
                        PublicHolidays = new List<PublicHoliday>()
                                                    {
                                                        new PublicHoliday { DateHoliday = new DateTime(2013,1,2) },
                                                        new PublicHoliday { DateHoliday = new DateTime(2013, 4, 7) },
                                                        new PublicHoliday { DateHoliday = new DateTime(2013, 4, 10) },
                                                        new PublicHoliday { DateHoliday = new DateTime(2013, 5, 10) },
                                                    },
                        WorkingDays = new List<WorkingDay>() {
                                                        new WorkingDay { day = DAYS.Saturday, IsWeekend = true},
                                                        new WorkingDay { day = DAYS.Sunday, IsWeekend = true},
                                                        new WorkingDay { day = DAYS.Monday, IsWeekend = false},
                                                        new WorkingDay { day = DAYS.Thursday, IsWeekend = false},
                                                        new WorkingDay { day = DAYS.Wednesday, IsWeekend = false},
                                                        new WorkingDay { day = DAYS.Tuesday, IsWeekend = false},
                                                        new WorkingDay { day = DAYS.Friday, IsWeekend = false},

                                                    }
                    },
                });
                //---------------------------------------Gothenburg City Tariff Defination: No:1 , Year = 2010 , IsActive = false----------------------------------------------------------------------------
                congestionTaxContext.TariffDefinitions.Add(new TariffDefinition
                {
                    City = gothenburgCity,
                    TariffNO = 1,
                    StartTariffYear = 2010,
                    IsActive = false,
                    ExemptVehicles = new List<ExemptVehicle>
                    {
                        new ExemptVehicle { VehicleType = "Emergency" },
                        new ExemptVehicle { VehicleType = "Bus" },
                        new ExemptVehicle { VehicleType = "MiniBus" },
                        new ExemptVehicle { VehicleType = "Diplomat" },
                        new ExemptVehicle { VehicleType = "Motorcycles" },
                        new ExemptVehicle { VehicleType = "Foreign" },
                        new ExemptVehicle { VehicleType = "Van" },
                    },
                    TariffCosts = new List<TariffCost>
                    {
                        new TariffCost { FromTime = new TimeSpan(0, 0, 0), ToTime = new TimeSpan(5, 59, 59), Amount = 0.00m },
                        new TariffCost { FromTime = new TimeSpan(6, 0, 0), ToTime = new TimeSpan(6, 29, 59), Amount = 0.00m },
                        new TariffCost { FromTime = new TimeSpan(6, 30, 0), ToTime = new TimeSpan(6, 59, 59), Amount = 10.00m },
                        new TariffCost { FromTime = new TimeSpan(7, 0, 0), ToTime = new TimeSpan(7, 59, 59), Amount = 0.00m },
                        new TariffCost { FromTime = new TimeSpan(8, 0, 0), ToTime = new TimeSpan(8, 29, 59), Amount = 10.00m },

                        new TariffCost { FromTime = new TimeSpan(8, 30, 0), ToTime = new TimeSpan(14, 59, 59), Amount = 0.00m },
                        new TariffCost { FromTime = new TimeSpan(15, 0, 0), ToTime = new TimeSpan(15, 29, 59), Amount = 10.00m },
                        new TariffCost { FromTime = new TimeSpan(15, 30, 0), ToTime = new TimeSpan(16, 59, 59), Amount = 0.00m },
                        new TariffCost { FromTime = new TimeSpan(17, 0, 0), ToTime = new TimeSpan(17, 59, 59), Amount = 10.00m },

                        new TariffCost { FromTime = new TimeSpan(18, 0, 0), ToTime = new TimeSpan(18, 29, 59), Amount = 5.00m },
                        new TariffCost { FromTime = new TimeSpan(18, 30, 0), ToTime = new TimeSpan(23, 59, 59), Amount = 0.00m },
                    },
                    TariffSetting = new TariffSetting
                    {
                        NumberTaxFreeDaysBeforeHoliday = 1,
                        MaxTaxAmount = 60.00m,
                        TaxFreeMonthCalender = MONTH.July,
                        PublicHolidays = new List<PublicHoliday>()
                                                    {
                                                        new PublicHoliday { DateHoliday = new DateTime(2013,1,2) },
                                                        new PublicHoliday { DateHoliday = new DateTime(2013, 4, 7) },
                                                        new PublicHoliday { DateHoliday = new DateTime(2013, 4, 10) },
                                                        new PublicHoliday { DateHoliday = new DateTime(2013, 5, 10) },
                                                    },
                        WorkingDays = new List<WorkingDay>() {
                                                        new WorkingDay { day = DAYS.Saturday, IsWeekend = true},
                                                        new WorkingDay { day = DAYS.Sunday, IsWeekend = true},
                                                        new WorkingDay { day = DAYS.Monday, IsWeekend = false},
                                                        new WorkingDay { day = DAYS.Thursday, IsWeekend = false},
                                                        new WorkingDay { day = DAYS.Wednesday, IsWeekend = false},
                                                        new WorkingDay { day = DAYS.Tuesday, IsWeekend = false},
                                                        new WorkingDay { day = DAYS.Friday, IsWeekend = false},

                                                    }
                    },
                });

                //---------------------------------------London City Tariff Defination: No:1 , Year = 2013 , IsActive = true----------------------------------------------------------------------------
                congestionTaxContext.TariffDefinitions.Add(new TariffDefinition
                {
                    City = londonCity,
                    TariffNO = 1,
                    StartTariffYear = 2013,
                    IsActive = true,
                    ExemptVehicles = new List<ExemptVehicle>
                    {
                        new ExemptVehicle { VehicleType = "Emergency" },
                        new ExemptVehicle { VehicleType = "Bus" },
                        new ExemptVehicle { VehicleType = "Diplomat" },
                        new ExemptVehicle { VehicleType = "Foreign" },
                    },
                    TariffCosts = new List<TariffCost>
                    {
                        new TariffCost { FromTime = new TimeSpan(0, 0, 0), ToTime = new TimeSpan(5, 59, 59), Amount = 0.00m },
                        new TariffCost { FromTime = new TimeSpan(6, 0, 0), ToTime = new TimeSpan(6, 29, 59), Amount = 18.00m },
                        new TariffCost { FromTime = new TimeSpan(6, 30, 0), ToTime = new TimeSpan(6, 59, 59), Amount = 23.00m },
                        new TariffCost { FromTime = new TimeSpan(7, 0, 0), ToTime = new TimeSpan(7, 59, 59), Amount = 38.00m },
                        new TariffCost { FromTime = new TimeSpan(8, 0, 0), ToTime = new TimeSpan(8, 29, 59), Amount = 23.00m },

                        new TariffCost { FromTime = new TimeSpan(8, 30, 0), ToTime = new TimeSpan(14, 59, 59), Amount = 18.00m },
                        new TariffCost { FromTime = new TimeSpan(15, 0, 0), ToTime = new TimeSpan(15, 29, 59), Amount = 23.00m },
                        new TariffCost { FromTime = new TimeSpan(15, 30, 0), ToTime = new TimeSpan(16, 59, 59), Amount = 38.00m },
                        new TariffCost { FromTime = new TimeSpan(17, 0, 0), ToTime = new TimeSpan(17, 59, 59), Amount = 23.00m },

                        new TariffCost { FromTime = new TimeSpan(18, 0, 0), ToTime = new TimeSpan(18, 29, 59), Amount = 18.00m },
                        new TariffCost { FromTime = new TimeSpan(18, 30, 0), ToTime = new TimeSpan(23, 59, 59), Amount = 0.00m },
                    },
                    TariffSetting = new TariffSetting
                    {
                        NumberTaxFreeDaysBeforeHoliday = 1,
                        MaxTaxAmount = 60.00m,
                        TaxFreeMonthCalender = MONTH.July,
                        PublicHolidays = new List<PublicHoliday>()
                                                    {
                                                        new PublicHoliday { DateHoliday = new DateTime(2013,1,2) },
                                                        new PublicHoliday { DateHoliday = new DateTime(2013, 4, 7) },
                                                        new PublicHoliday { DateHoliday = new DateTime(2013, 4, 10) },
                                                        new PublicHoliday { DateHoliday = new DateTime(2013, 5, 10) },
                                                    },
                        WorkingDays = new List<WorkingDay>() {
                                                        new WorkingDay { day = DAYS.Saturday, IsWeekend = true},
                                                        new WorkingDay { day = DAYS.Sunday, IsWeekend = true},
                                                        new WorkingDay { day = DAYS.Monday, IsWeekend = false},
                                                        new WorkingDay { day = DAYS.Thursday, IsWeekend = false},
                                                        new WorkingDay { day = DAYS.Wednesday, IsWeekend = false},
                                                        new WorkingDay { day = DAYS.Tuesday, IsWeekend = false},
                                                        new WorkingDay { day = DAYS.Friday, IsWeekend = false},

                                                    }
                    },
                });


                await congestionTaxContext.SaveChangesAsync();
            }



        }
    }


}
