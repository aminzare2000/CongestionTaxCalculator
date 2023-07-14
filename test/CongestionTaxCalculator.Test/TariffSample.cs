
using System;
using Model = CongestionTaxCalculator.Domain.Model;
using System.Collections.Generic;
using Persistence = CongestionTaxCalculator.Domain.Persistence;
using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Test
{
    public class TariffDefinitionSample
    {





        public static List<Persistence.TariffDefinition> GetPersistenceTariffDefinations()
        {

            var gothenburgCity = new Persistence.City { Name = "Gothenburg" };
            var londonCity = new Persistence.City { Name = "London" };

            //---------------------------------------Gothenburg City Tariff Defination: No:1 , Year = 2013 , IsActive = true----------------------------------------------------------------------------
            var tariffs = new List<Persistence.TariffDefinition>() {
            new Persistence.TariffDefinition
            {
                City = gothenburgCity,
                TariffNO = 1,
                StartTariffYear = 2013,
                IsActive = true,
                ExemptVehicles = new List<Persistence.ExemptVehicle>
                    {
                        new Persistence.ExemptVehicle { VehicleType = "Emergency" },
                        new Persistence.ExemptVehicle { VehicleType = "Bus" },
                        new Persistence.ExemptVehicle { VehicleType = "Diplomat" },
                        new Persistence.ExemptVehicle { VehicleType = "Motorcycles" },
                        new Persistence.ExemptVehicle { VehicleType = "Foreign" },
                    },
                TariffCosts = new List<Persistence.TariffCost>
                    {
                        new Persistence.TariffCost { FromTime = new TimeSpan(0, 0, 0), ToTime = new TimeSpan(5, 59, 59), Amount = 0.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(6, 0, 0), ToTime = new TimeSpan(6, 29, 59), Amount = 8.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(6, 30, 0), ToTime = new TimeSpan(6, 59, 59), Amount = 13.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(7, 0, 0), ToTime = new TimeSpan(7, 59, 59), Amount = 18.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(8, 0, 0), ToTime = new TimeSpan(8, 29, 59), Amount = 13.00m },

                        new Persistence.TariffCost { FromTime = new TimeSpan(8, 30, 0), ToTime = new TimeSpan(14, 59, 59), Amount = 8.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(15, 0, 0), ToTime = new TimeSpan(15, 29, 59), Amount = 13.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(15, 30, 0), ToTime = new TimeSpan(16, 59, 59), Amount = 18.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(17, 0, 0), ToTime = new TimeSpan(17, 59, 59), Amount = 13.00m },

                        new Persistence.TariffCost { FromTime = new TimeSpan(18, 0, 0), ToTime = new TimeSpan(18, 29, 59), Amount = 8.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(18, 30, 0), ToTime = new TimeSpan(23, 59, 59), Amount = 0.00m },
                    },
                TariffSetting = new Persistence.TariffSetting
                {
                    NumberTaxFreeDaysBeforeHoliday = 1,
                    MaxTaxAmount = 60.00m,
                    TaxFreeMonthCalender = MONTH.July,
                    PublicHolidays = new List<Persistence.PublicHoliday>()
                                                    {
                                                        new Persistence.PublicHoliday { DateHoliday = new DateTime(2013,1,2) },
                                                        new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 4, 7) },
                                                        new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 4, 10) },
                                                        new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 5, 10) },
                                                    },
                    WorkingDays = new List<Persistence.WorkingDay>() {
                                                        new Persistence.WorkingDay { day = DAYS.Saturday, IsWeekend = true},
                                                        new Persistence.WorkingDay { day = DAYS.Sunday, IsWeekend = true},
                                                        new Persistence.WorkingDay { day = DAYS.Monday, IsWeekend = false},
                                                        new Persistence.WorkingDay { day = DAYS.Tuesday, IsWeekend = false},
                                                        new Persistence.WorkingDay { day = DAYS.Wednesday, IsWeekend = false},
                                                        new Persistence.WorkingDay { day = DAYS.Thursday, IsWeekend = false},
                                                        new Persistence.WorkingDay { day = DAYS.Friday, IsWeekend = false},

                                                    }
                },
            },
            //---------------------------------------Gothenburg City Tariff Defination: No:2 , Year = 2013 , IsActive = false----------------------------------------------------------------------------
            new Persistence.TariffDefinition
            {
                City = gothenburgCity,
                TariffNO = 2,
                StartTariffYear = 2013,
                IsActive = false,
                ExemptVehicles = new List<Persistence.ExemptVehicle>
                    {
                        new Persistence.ExemptVehicle { VehicleType = "Emergency" },
                        new Persistence.ExemptVehicle { VehicleType = "Bus" },
                        new Persistence.ExemptVehicle { VehicleType = "MiniBus" },
                        new Persistence.ExemptVehicle { VehicleType = "Diplomat" },
                        new Persistence.ExemptVehicle { VehicleType = "Motorcycles" },
                        new Persistence.ExemptVehicle { VehicleType = "Foreign" },
                    },
                TariffCosts = new List<Persistence.TariffCost>
                    {
                        new Persistence.TariffCost { FromTime = new TimeSpan(0, 0, 0), ToTime = new TimeSpan(5, 59, 59), Amount = 0.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(6, 0, 0), ToTime = new TimeSpan(6, 29, 59), Amount = 5.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(6, 30, 0), ToTime = new TimeSpan(6, 59, 59), Amount = 10.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(7, 0, 0), ToTime = new TimeSpan(7, 59, 59), Amount = 12.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(8, 0, 0), ToTime = new TimeSpan(8, 29, 59), Amount = 10.00m },

                        new Persistence.TariffCost { FromTime = new TimeSpan(8, 30, 0), ToTime = new TimeSpan(14, 59, 59), Amount = 5.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(15, 0, 0), ToTime = new TimeSpan(15, 29, 59), Amount = 10.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(15, 30, 0), ToTime = new TimeSpan(16, 59, 59), Amount = 12.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(17, 0, 0), ToTime = new TimeSpan(17, 59, 59), Amount = 10.00m },

                        new Persistence.TariffCost { FromTime = new TimeSpan(18, 0, 0), ToTime = new TimeSpan(18, 29, 59), Amount = 5.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(18, 30, 0), ToTime = new TimeSpan(23, 59, 59), Amount = 0.00m },
                    },
                TariffSetting = new Persistence.TariffSetting
                {
                    NumberTaxFreeDaysBeforeHoliday = 1,
                    MaxTaxAmount = 60.00m,
                    TaxFreeMonthCalender = MONTH.July,
                    PublicHolidays = new List<Persistence.PublicHoliday>()
                                                    {
                                                        new Persistence.PublicHoliday { DateHoliday = new DateTime(2013,1,2) },
                                                        new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 4, 7) },
                                                        new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 4, 10) },
                                                        new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 5, 10) },
                                                    },
                    WorkingDays = new List<Persistence.WorkingDay>() {
                                                        new Persistence.WorkingDay { day = DAYS.Saturday, IsWeekend = true},
                                                        new Persistence.WorkingDay { day = DAYS.Sunday, IsWeekend = true},
                                                        new Persistence.WorkingDay { day = DAYS.Monday, IsWeekend = false},
                                                        new Persistence.WorkingDay { day = DAYS.Tuesday, IsWeekend = false},
                                                        new Persistence.WorkingDay { day = DAYS.Wednesday, IsWeekend = false},
                                                        new Persistence.WorkingDay { day = DAYS.Thursday, IsWeekend = false},
                                                        new Persistence.WorkingDay { day = DAYS.Friday, IsWeekend = false},

                                                    }
                },
            },
            //---------------------------------------Gothenburg City Tariff Defination: No:1 , Year = 2010 , IsActive = false----------------------------------------------------------------------------
            new Persistence.TariffDefinition
            {
                City = gothenburgCity,
                TariffNO = 1,
                StartTariffYear = 2010,
                IsActive = false,
                ExemptVehicles = new List<Persistence.ExemptVehicle>
                    {
                        new Persistence.ExemptVehicle { VehicleType = "Emergency" },
                        new Persistence.ExemptVehicle { VehicleType = "Bus" },
                        new Persistence.ExemptVehicle { VehicleType = "MiniBus" },
                        new Persistence.ExemptVehicle { VehicleType = "Diplomat" },
                        new Persistence.ExemptVehicle { VehicleType = "Motorcycles" },
                        new Persistence.ExemptVehicle { VehicleType = "Foreign" },
                        new Persistence.ExemptVehicle { VehicleType = "Van" },
                    },
                TariffCosts = new List<Persistence.TariffCost>
                    {
                        new Persistence.TariffCost { FromTime = new TimeSpan(0, 0, 0), ToTime = new TimeSpan(5, 59, 59), Amount = 0.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(6, 0, 0), ToTime = new TimeSpan(6, 29, 59), Amount = 0.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(6, 30, 0), ToTime = new TimeSpan(6, 59, 59), Amount = 10.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(7, 0, 0), ToTime = new TimeSpan(7, 59, 59), Amount = 0.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(8, 0, 0), ToTime = new TimeSpan(8, 29, 59), Amount = 10.00m },

                        new Persistence.TariffCost { FromTime = new TimeSpan(8, 30, 0), ToTime = new TimeSpan(14, 59, 59), Amount = 0.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(15, 0, 0), ToTime = new TimeSpan(15, 29, 59), Amount = 10.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(15, 30, 0), ToTime = new TimeSpan(16, 59, 59), Amount = 0.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(17, 0, 0), ToTime = new TimeSpan(17, 59, 59), Amount = 10.00m },

                        new Persistence.TariffCost { FromTime = new TimeSpan(18, 0, 0), ToTime = new TimeSpan(18, 29, 59), Amount = 5.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(18, 30, 0), ToTime = new TimeSpan(23, 59, 59), Amount = 0.00m },
                    },
                TariffSetting = new Persistence.TariffSetting
                {
                    NumberTaxFreeDaysBeforeHoliday = 1,
                    MaxTaxAmount = 60.00m,
                    TaxFreeMonthCalender = MONTH.July,
                    PublicHolidays = new List<Persistence.PublicHoliday>()
                                                    {
                                                        new Persistence.PublicHoliday { DateHoliday = new DateTime(2013,1,2) },
                                                        new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 4, 7) },
                                                        new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 4, 10) },
                                                        new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 5, 10) },
                                                    },
                    WorkingDays = new List<Persistence.WorkingDay>() {
                                                        new Persistence.WorkingDay { day = DAYS.Saturday, IsWeekend = true},
                                                        new Persistence.WorkingDay { day = DAYS.Sunday, IsWeekend = true},
                                                        new Persistence.WorkingDay { day = DAYS.Monday, IsWeekend = false},
                                                        new Persistence.WorkingDay { day = DAYS.Tuesday, IsWeekend = false},
                                                        new Persistence.WorkingDay { day = DAYS.Wednesday, IsWeekend = false},
                                                        new Persistence.WorkingDay { day = DAYS.Thursday, IsWeekend = false},
                                                        new Persistence.WorkingDay { day = DAYS.Friday, IsWeekend = false},

                                                    }
                },
            },
            //---------------------------------------London City Tariff Defination: No:1 , Year = 2013 , IsActive = true----------------------------------------------------------------------------
            new Persistence.TariffDefinition
            {
                City = londonCity,
                TariffNO = 1,
                StartTariffYear = 2013,
                IsActive = true,
                ExemptVehicles = new List<Persistence.ExemptVehicle>
                    {
                        new Persistence.ExemptVehicle { VehicleType = "Emergency" },
                        new Persistence.ExemptVehicle { VehicleType = "Bus" },
                        new Persistence.ExemptVehicle { VehicleType = "Diplomat" },
                        new Persistence.ExemptVehicle { VehicleType = "Foreign" },
                    },
                TariffCosts = new List<Persistence.TariffCost>
                    {
                        new Persistence.TariffCost { FromTime = new TimeSpan(0, 0, 0), ToTime = new TimeSpan(5, 59, 59), Amount = 0.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(6, 0, 0), ToTime = new TimeSpan(6, 29, 59), Amount = 18.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(6, 30, 0), ToTime = new TimeSpan(6, 59, 59), Amount = 23.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(7, 0, 0), ToTime = new TimeSpan(7, 59, 59), Amount = 38.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(8, 0, 0), ToTime = new TimeSpan(8, 29, 59), Amount = 23.00m },

                        new Persistence.TariffCost { FromTime = new TimeSpan(8, 30, 0), ToTime = new TimeSpan(14, 59, 59), Amount = 18.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(15, 0, 0), ToTime = new TimeSpan(15, 29, 59), Amount = 23.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(15, 30, 0), ToTime = new TimeSpan(16, 59, 59), Amount = 38.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(17, 0, 0), ToTime = new TimeSpan(17, 59, 59), Amount = 23.00m },

                        new Persistence.TariffCost { FromTime = new TimeSpan(18, 0, 0), ToTime = new TimeSpan(18, 29, 59), Amount = 18.00m },
                        new Persistence.TariffCost { FromTime = new TimeSpan(18, 30, 0), ToTime = new TimeSpan(23, 59, 59), Amount = 0.00m },
                    },
                TariffSetting = new Persistence.TariffSetting
                {
                    NumberTaxFreeDaysBeforeHoliday = 1,
                    MaxTaxAmount = 60.00m,
                    TaxFreeMonthCalender = MONTH.July,
                    PublicHolidays = new List<Persistence.PublicHoliday>()
                                                    {
                                                        new Persistence.PublicHoliday { DateHoliday = new DateTime(2013,1,2) },
                                                        new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 4, 7) },
                                                        new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 4, 10) },
                                                        new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 5, 10) },
                                                    },
                    WorkingDays = new List<Persistence.WorkingDay>() {
                                                        new Persistence.WorkingDay { day = DAYS.Saturday, IsWeekend = true},
                                                        new Persistence.WorkingDay { day = DAYS.Sunday, IsWeekend = true},
                                                        new Persistence.WorkingDay { day = DAYS.Monday, IsWeekend = false},
                                                        new Persistence.WorkingDay { day = DAYS.Tuesday, IsWeekend = false},
                                                        new Persistence.WorkingDay { day = DAYS.Wednesday, IsWeekend = false},
                                                        new Persistence.WorkingDay { day = DAYS.Thursday, IsWeekend = false},
                                                        new Persistence.WorkingDay { day = DAYS.Friday, IsWeekend = false},

                                                    }
                },

            }
            };
            return tariffs;
        }//func


    }



}
