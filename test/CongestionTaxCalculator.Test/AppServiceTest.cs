using Xunit;
using System;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using CongestionTaxCalculator.Application;
using CongestionTaxCalculator.EFCore.Data;
using CongestionTaxCalculator.Application.Contracts;
using Moq;
using AutoFixture;
using Moq.EntityFrameworkCore;
using Model = CongestionTaxCalculator.Domain.Model;
using System.Collections.Generic;
using CongestionTaxCalculator.Domain.Persistence.InterfaceRepository;
using Persistence = CongestionTaxCalculator.Domain.Persistence;
using CongestionTaxCalculator.Domain.Common;
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;
using Microsoft.VisualBasic;

//https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices

namespace CongestionTaxCalculator.Test
{

    public class AppServiceTest : IDisposable
    {
        private static readonly CultureInfo  provider = new CultureInfo("en-GB");
        private static readonly Fixture Fixture = new Fixture();


        //private readonly DbContextOptions<CongestionTaxContext> _options;
        //private readonly ITariffAppService _congestionTaxAppService;
        //private readonly CongestionTaxContext _context;


        public AppServiceTest()
        {
            
            //repoCity = new Mock<ICityRepository>();

            //_options = new DbContextOptionsBuilder<_context>()
            //    .UseSqlServer("Data Source=.;Initial Catalog=CongestionTaxDb;Integrated Security=True;TrustServerCertificate=True;")
            //    .Options;

            //_options = new DbContextOptionsBuilder<CongestionTaxContext>()
            //        .UseInMemoryDatabase(databaseName: "temp_db")
            //        .Options;

            //_context = new CongestionTaxContext(_options);
            //_congestionTaxAppService = new CongestionTaxAppService(_context);

        }

        public async void Dispose()
        {
            //if (_context != null)
            //    await _context.Database.EnsureDeletedAsync();
        }





        [Theory]
        [InlineData("Gothenburg", "Gothenburg")]
        [InlineData("gothenburg", "Gothenburg")]
        [InlineData("London", "London")]
        public void When_Exist_City_Return(string input, string expected)
        {
            
            // Arrange
            var datalist = TariffDefinitionSample.GetPersistenceTariffDefinations().Select(x => x.City).ToList();
            var mockContext = new Mock<CongestionTaxContext>();
            mockContext.Setup(p => p.Cities).Returns(DbContextMock.GetQueryableMockDbSet<Persistence.City>(datalist));


            ITariffAppService congestionTaxAppService = new TariffAppService(mockContext.Object);

            // Act
            var actual = congestionTaxAppService.GetACity(input).Name;


            // Assert
            Assert.Equal(expected, actual);

        }


        [Theory]
        [InlineData("ABC", null)]
        public void When_NotExist_City_Return(string input, string expected)
        {

            // Arrange
            var datalist = TariffDefinitionSample.GetPersistenceTariffDefinations().Select(x => x.City).ToList();
            var mockContext = new Mock<CongestionTaxContext>();
            mockContext.Setup(p => p.Cities).Returns(DbContextMock.GetQueryableMockDbSet<Persistence.City>(datalist));


            ITariffAppService congestionTaxAppService = new TariffAppService(mockContext.Object);

            // Act
            var actual = congestionTaxAppService.GetACity(input).Name;

            // Assert
            Assert.Null(actual);

        }

        public static IEnumerable<object[]> CompleteTariffDefinition =>
        new List<object[]> {
                // Complete Tariff
                 new object[] {
                    //input
                     new Persistence.TariffDefinition
                    {
                        City = new Persistence.City { Name = "Gothenburg" },
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
                            SingleCharegeInterval = 60,
                            PublicHolidays = new List<Persistence.PublicHoliday>()
                                                        {
                                                            new Persistence.PublicHoliday { DateHoliday = new DateTime(2013,1,2) },
                                                            new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 4, 7) },
                                                            new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 4, 10) },
                                                            new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 5, 10) },
                                                        },
                            WorkingDays = new List<Persistence.WorkingDay>() {
                                                            new Persistence.WorkingDay { day = DayOfWeek.Saturday, IsWeekend = true},
                                                            new Persistence.WorkingDay { day = DayOfWeek.Sunday, IsWeekend = true},
                                                            new Persistence.WorkingDay { day = DayOfWeek.Monday, IsWeekend = false},
                                                            new Persistence.WorkingDay { day = DayOfWeek.Tuesday, IsWeekend = false},
                                                            new Persistence.WorkingDay { day = DayOfWeek.Wednesday, IsWeekend = false},
                                                            new Persistence.WorkingDay { day = DayOfWeek.Thursday, IsWeekend = false},
                                                            new Persistence.WorkingDay { day = DayOfWeek.Friday, IsWeekend = false},

                                                        }
                        },
                    },
                     //expected
                     new Model.TariffDefinition(
                                                    tariffNO:1,
                                                    startTariffYear:2013,
                                                    isActive:true,
                                                    city:new Model.City(name:"Gothenburg"),
                                                    exemptVehicles:new Model.ExemptVehicle[] {
                                                                new Model.ExemptVehicle(vehicleType:"Emergency"),
                                                                new Model.ExemptVehicle(vehicleType:"Bus"),
                                                                new Model.ExemptVehicle(vehicleType:"Diplomat"),
                                                                new Model.ExemptVehicle(vehicleType:"Motorcycles"),
                                                                new Model.ExemptVehicle(vehicleType:"Foreign"),
                                                                },
                                                    tariffCosts:new Model.TariffCost[]
                                                    {

                                                        new Model.TariffCost( fromTime : new TimeSpan(0, 0, 0), toTime : new TimeSpan(5, 59, 59), amount : 0.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(6, 0, 0), toTime : new TimeSpan(6, 29, 59), amount : 8.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(6, 30, 0), toTime : new TimeSpan(6, 59, 59), amount : 13.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(7, 0, 0), toTime : new TimeSpan(7, 59, 59), amount : 18.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(8, 0, 0), toTime : new TimeSpan(8, 29, 59), amount : 13.00m ),

                                                        new Model.TariffCost( fromTime : new TimeSpan(8, 30, 0), toTime : new TimeSpan(14, 59, 59), amount : 8.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(15, 0, 0), toTime : new TimeSpan(15, 29, 59), amount : 13.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(15, 30, 0), toTime : new TimeSpan(16, 59, 59), amount : 18.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(17, 0, 0), toTime : new TimeSpan(17, 59, 59), amount : 13.00m ),

                                                        new Model.TariffCost( fromTime : new TimeSpan(18, 0, 0), toTime : new TimeSpan(18, 29, 59), amount : 8.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(18, 30, 0), toTime : new TimeSpan(23, 59, 59), amount : 0.00m )
                                                    },
                                                    tariffSetting:new Model.TariffSetting(
                                                            numberTaxFreeDaysBeforeHoliday : 1,
                                                            maxTaxAmount : 60.00m,
                                                            taxFreeMonthCalender : MONTH.July,
                                                            singleCharegeInterval:60,
                                                            publicHolidays: new Model.PublicHoliday[] {
                                                                new Model.PublicHoliday( dateHoliday : new DateTime(2013,1,2) ),
                                                                new Model.PublicHoliday( dateHoliday : new DateTime(2013, 4, 7) ),
                                                                new Model.PublicHoliday( dateHoliday : new DateTime(2013, 4, 10) ),
                                                                new Model.PublicHoliday( dateHoliday : new DateTime(2013, 5, 10) ),
                                                            },
                                                            weekendDays: new DayOfWeek[] {
                                                                DayOfWeek.Saturday,
                                                                DayOfWeek.Sunday
                                                            }
                                                        )
                                                )
                },
        
                 // Another Complete Tariff
                 new object[] {
                    //input
                     new Persistence.TariffDefinition
                    {
                        City = new Persistence.City { Name = "Tehran" },
                        TariffNO = 1,
                        StartTariffYear = 2013,
                        IsActive = true,
                        ExemptVehicles = new List<Persistence.ExemptVehicle>
                        {
                            new Persistence.ExemptVehicle { VehicleType = "Emergency" },
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
                            NumberTaxFreeDaysBeforeHoliday = 0,
                            MaxTaxAmount = 60.00m,
                            TaxFreeMonthCalender = MONTH.May,
                            SingleCharegeInterval = 60,
                            PublicHolidays = new List<Persistence.PublicHoliday>()
                                                        {
                                                            new Persistence.PublicHoliday { DateHoliday = new DateTime(2013,1,2) },
                                                            new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 4, 7) },
                                                        },
                            WorkingDays = new List<Persistence.WorkingDay>() {
                                                            new Persistence.WorkingDay { day = DayOfWeek.Saturday, IsWeekend = false},
                                                            new Persistence.WorkingDay { day = DayOfWeek.Sunday, IsWeekend = false},
                                                            new Persistence.WorkingDay { day = DayOfWeek.Monday, IsWeekend = false},
                                                             new Persistence.WorkingDay { day = DayOfWeek.Tuesday, IsWeekend = false},                                                            
                                                            new Persistence.WorkingDay { day = DayOfWeek.Wednesday, IsWeekend = false},
                                                            new Persistence.WorkingDay { day = DayOfWeek.Thursday, IsWeekend = true},
                                                            new Persistence.WorkingDay { day = DayOfWeek.Friday, IsWeekend = true},

                                                        }
                        },
                    },
                     //expected
                     new Model.TariffDefinition(
                                                    tariffNO:1,
                                                    startTariffYear:2013,
                                                    isActive:true,
                                                    city:new Model.City(name:"Tehran"),
                                                    exemptVehicles:new Model.ExemptVehicle[] {
                                                                new Model.ExemptVehicle(vehicleType:"Emergency"),
                                                                },
                                                    tariffCosts:new Model.TariffCost[]
                                                    {

                                                        new Model.TariffCost( fromTime : new TimeSpan(0, 0, 0), toTime : new TimeSpan(5, 59, 59), amount : 0.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(6, 0, 0), toTime : new TimeSpan(6, 29, 59), amount : 8.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(6, 30, 0), toTime : new TimeSpan(6, 59, 59), amount : 13.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(7, 0, 0), toTime : new TimeSpan(7, 59, 59), amount : 18.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(8, 0, 0), toTime : new TimeSpan(8, 29, 59), amount : 13.00m ),

                                                        new Model.TariffCost( fromTime : new TimeSpan(8, 30, 0), toTime : new TimeSpan(14, 59, 59), amount : 8.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(15, 0, 0), toTime : new TimeSpan(15, 29, 59), amount : 13.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(15, 30, 0), toTime : new TimeSpan(16, 59, 59), amount : 18.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(17, 0, 0), toTime : new TimeSpan(17, 59, 59), amount : 13.00m ),

                                                        new Model.TariffCost( fromTime : new TimeSpan(18, 0, 0), toTime : new TimeSpan(18, 29, 59), amount : 8.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(18, 30, 0), toTime : new TimeSpan(23, 59, 59), amount : 0.00m )
                                                    },
                                                    tariffSetting:new Model.TariffSetting(
                                                            numberTaxFreeDaysBeforeHoliday : 0,
                                                            maxTaxAmount : 60.00m,
                                                            taxFreeMonthCalender : MONTH.May,
                                                            singleCharegeInterval : 60,
                                                            publicHolidays: new Model.PublicHoliday[] {
                                                                new Model.PublicHoliday( dateHoliday : new DateTime(2013,1,2) ),
                                                                new Model.PublicHoliday( dateHoliday : new DateTime(2013, 4, 7) ),
                                                            },
                                                            weekendDays: new DayOfWeek[] {
                                                                DayOfWeek.Thursday,
                                                                DayOfWeek.Friday
                                                            }
                                                        )
                                                )
                }


        };


        [Theory]
        [MemberData(nameof(CompleteTariffDefinition))]
        public void Test_Read_CompleteTariffDefination_Return_Model_TariffDefination(Persistence.TariffDefinition input, Model.TariffDefinition expected)
        {

            // Arrange
            //var inputQueryable = new List<Persistence.TariffDefinition>() { input }.AsQueryable();
            var inputTariff = new List<Persistence.TariffDefinition>() { input };
            var inputCity = new List<Persistence.City>() { input.City };
            var inputVehicle = input.ExemptVehicles?.ToList();

            var request = Fixture.Build<CongestionTaxRequestDto>()
                .With(x => x.CityName, input.City.Name).Create();

            var mockContext = new Mock<CongestionTaxContext>();
            if (inputTariff is not null) mockContext.Setup(p => p.TariffDefinitions).Returns(DbContextMock.GetQueryableMockDbSet<Persistence.TariffDefinition>(inputTariff));
            if(inputVehicle is not null) mockContext.Setup(p => p.ExemptVehicles).Returns(DbContextMock.GetQueryableMockDbSet<Persistence.ExemptVehicle>(inputVehicle));
            if (inputCity is not null) mockContext.Setup(p => p.Cities).Returns(DbContextMock.GetQueryableMockDbSet<Persistence.City>(inputCity));

            ITariffAppService congestionTaxAppService = new TariffAppService(mockContext.Object);

            // Act
            Model.TariffDefinition actual = congestionTaxAppService.GenrateTariffDefination(request);


            // Assert
            Assert.Equal(actual, expected, Comparer.Get<Model.TariffDefinition>((param1, param2) =>
                   param1.IsActive == param2.IsActive &&
                   param1.TariffNO == param2.TariffNO &&
                   param1.StartTariffYear == param2.StartTariffYear &&
                   param1.City == param2.City &&
                   param1.TariffSetting == param2.TariffSetting)
                );

            Assert.Equal(actual.GetExemptVehicles().ToList().Count, expected.GetExemptVehicles().ToList().Count);
            foreach (var item in actual.GetExemptVehicles().ToList())
            {
                if (!expected.GetExemptVehicles().ToList().Contains(item))
                    Assert.Equal(1, 0);
            }
            Assert.Equal(actual.GetTariffCosts().ToList().Count, expected.GetTariffCosts().ToList().Count);
            foreach (var item in actual.GetTariffCosts().ToList())
            {
                if (!expected.GetTariffCosts().ToList().Contains(item))
                    Assert.Equal(1, 0);
            }


        }


        public static IEnumerable<object[]> TrueRequest =>
        new List<object[]> {
                // Request1
                 new object[] {
                    //input                     
                     new CongestionTaxRequestDto()
                     {
                         CityName="Gothenburg",
                         StartTariffYear=2013,
                         TariffNO=1,
                         VehicleType="Bus",
                         TrafficTimeSequence = new List<DateTime>()
                         {
                                DateTime.ParseExact("2013-01-14 06:00:00", "yyyy-MM-dd HH:mm:ss", provider),
                                DateTime.ParseExact("2013-01-15 08:10:00", "yyyy-MM-dd HH:mm:ss", provider),
                         }
                     },
                     new Model.TariffDefinition(
                                                    tariffNO:1,
                                                    startTariffYear:2013,
                                                    isActive:true,
                                                    city:new Model.City(name:"Gothenburg"),
                                                    exemptVehicles:new Model.ExemptVehicle[] {
                                                                new Model.ExemptVehicle(vehicleType:"Emergency"),
                                                                new Model.ExemptVehicle(vehicleType:"Bus"),
                                                                new Model.ExemptVehicle(vehicleType:"Diplomat"),
                                                                new Model.ExemptVehicle(vehicleType:"Motorcycles"),
                                                                new Model.ExemptVehicle(vehicleType:"Foreign"),
                                                                },
                                                    tariffCosts:new Model.TariffCost[]
                                                    {

                                                        new Model.TariffCost( fromTime : new TimeSpan(0, 0, 0), toTime : new TimeSpan(5, 59, 59), amount : 0.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(6, 0, 0), toTime : new TimeSpan(6, 29, 59), amount : 8.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(6, 30, 0), toTime : new TimeSpan(6, 59, 59), amount : 13.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(7, 0, 0), toTime : new TimeSpan(7, 59, 59), amount : 18.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(8, 0, 0), toTime : new TimeSpan(8, 29, 59), amount : 13.00m ),

                                                        new Model.TariffCost( fromTime : new TimeSpan(8, 30, 0), toTime : new TimeSpan(14, 59, 59), amount : 8.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(15, 0, 0), toTime : new TimeSpan(15, 29, 59), amount : 13.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(15, 30, 0), toTime : new TimeSpan(16, 59, 59), amount : 18.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(17, 0, 0), toTime : new TimeSpan(17, 59, 59), amount : 13.00m ),

                                                        new Model.TariffCost( fromTime : new TimeSpan(18, 0, 0), toTime : new TimeSpan(18, 29, 59), amount : 8.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(18, 30, 0), toTime : new TimeSpan(23, 59, 59), amount : 0.00m )
                                                    },
                                                    tariffSetting:new Model.TariffSetting(
                                                            numberTaxFreeDaysBeforeHoliday : 1,
                                                            maxTaxAmount : 60.00m,
                                                            taxFreeMonthCalender : MONTH.July,
                                                            singleCharegeInterval:60,
                                                            publicHolidays: new Model.PublicHoliday[] {
                                                                new Model.PublicHoliday( dateHoliday : new DateTime(2013,1,2) ),
                                                                new Model.PublicHoliday( dateHoliday : new DateTime(2013, 4, 7) ),
                                                                new Model.PublicHoliday( dateHoliday : new DateTime(2013, 4, 10) ),
                                                                new Model.PublicHoliday( dateHoliday : new DateTime(2013, 5, 10) ),
                                                            },
                                                            weekendDays: new DayOfWeek[] {
                                                                DayOfWeek.Saturday,
                                                                DayOfWeek.Sunday
                                                            }
                                                        )
                                                ),
                     //expected
                     new Decimal(0)
                },
        
                 // // Request1
                 new object[] {
                     new CongestionTaxRequestDto()
                     {
                         CityName="Gothenburg",
                         StartTariffYear=2013,
                         TariffNO=1,
                         VehicleType="Car",
                         TrafficTimeSequence = new List<DateTime>()
                         {
                                DateTime.ParseExact("2013-01-14 21:00:00", "yyyy-MM-dd HH:mm:ss", provider),
                                DateTime.ParseExact("2013-01-15 21:00:00", "yyyy-MM-dd HH:mm:ss", provider),
                                DateTime.ParseExact("2013-02-07 06:23:27", "yyyy-MM-dd HH:mm:ss", provider),
                                DateTime.ParseExact("2013-02-07 15:27:00", "yyyy-MM-dd HH:mm:ss", provider),
                                DateTime.ParseExact("2013-02-08 06:27:00", "yyyy-MM-dd HH:mm:ss", provider),
                                DateTime.ParseExact("2013-02-08 06:20:27", "yyyy-MM-dd HH:mm:ss", provider),
                                DateTime.ParseExact("2013-02-08 14:35:00", "yyyy-MM-dd HH:mm:ss", provider),
                                DateTime.ParseExact("2013-02-08 15:29:00", "yyyy-MM-dd HH:mm:ss", provider),
                                DateTime.ParseExact("2013-02-08 15:47:00", "yyyy-MM-dd HH:mm:ss", provider),
                                DateTime.ParseExact("2013-02-08 16:01:00", "yyyy-MM-dd HH:mm:ss", provider),
                                DateTime.ParseExact("2013-02-08 16:48:00", "yyyy-MM-dd HH:mm:ss", provider),
                                DateTime.ParseExact("2013-02-08 17:49:00", "yyyy-MM-dd HH:mm:ss", provider),
                                DateTime.ParseExact("2013-02-08 18:29:00", "yyyy-MM-dd HH:mm:ss", provider),
                                DateTime.ParseExact("2013-02-08 18:35:00", "yyyy-MM-dd HH:mm:ss", provider),
                                DateTime.ParseExact("2013-03-26 14:25:00", "yyyy-MM-dd HH:mm:ss", provider),
                                DateTime.ParseExact("2013-03-28 14:07:27", "yyyy-MM-dd HH:mm:ss", provider),
                         }
                     },
                     new Model.TariffDefinition(
                                                    tariffNO:1,
                                                    startTariffYear:2013,
                                                    isActive:true,
                                                    city:new Model.City(name:"Gothenburg"),
                                                    exemptVehicles:new Model.ExemptVehicle[] {
                                                                new Model.ExemptVehicle(vehicleType:"Emergency"),
                                                                new Model.ExemptVehicle(vehicleType:"Bus"),
                                                                new Model.ExemptVehicle(vehicleType:"Diplomat"),
                                                                new Model.ExemptVehicle(vehicleType:"Motorcycles"),
                                                                new Model.ExemptVehicle(vehicleType:"Foreign"),
                                                                },
                                                    tariffCosts:new Model.TariffCost[]
                                                    {

                                                        new Model.TariffCost( fromTime : new TimeSpan(0, 0, 0), toTime : new TimeSpan(5, 59, 59), amount : 0.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(6, 0, 0), toTime : new TimeSpan(6, 29, 59), amount : 8.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(6, 30, 0), toTime : new TimeSpan(6, 59, 59), amount : 13.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(7, 0, 0), toTime : new TimeSpan(7, 59, 59), amount : 18.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(8, 0, 0), toTime : new TimeSpan(8, 29, 59), amount : 13.00m ),

                                                        new Model.TariffCost( fromTime : new TimeSpan(8, 30, 0), toTime : new TimeSpan(14, 59, 59), amount : 8.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(15, 0, 0), toTime : new TimeSpan(15, 29, 59), amount : 13.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(15, 30, 0), toTime : new TimeSpan(16, 59, 59), amount : 18.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(17, 0, 0), toTime : new TimeSpan(17, 59, 59), amount : 13.00m ),

                                                        new Model.TariffCost( fromTime : new TimeSpan(18, 0, 0), toTime : new TimeSpan(18, 29, 59), amount : 8.00m ),
                                                        new Model.TariffCost( fromTime : new TimeSpan(18, 30, 0), toTime : new TimeSpan(23, 59, 59), amount : 0.00m )
                                                    },
                                                    tariffSetting:new Model.TariffSetting(
                                                            numberTaxFreeDaysBeforeHoliday : 1,
                                                            maxTaxAmount : 60.00m,
                                                            taxFreeMonthCalender : MONTH.July,
                                                            singleCharegeInterval:60,
                                                            publicHolidays: new Model.PublicHoliday[] {
                                                                new Model.PublicHoliday( dateHoliday : new DateTime(2013,1,2) ),
                                                                new Model.PublicHoliday( dateHoliday : new DateTime(2013,1,14) ),
                                                                new Model.PublicHoliday( dateHoliday : new DateTime(2013, 4, 7) ),
                                                                new Model.PublicHoliday( dateHoliday : new DateTime(2013, 4, 10) ),
                                                                new Model.PublicHoliday( dateHoliday : new DateTime(2013, 5, 10) ),
                                                            },
                                                            weekendDays: new DayOfWeek[] {
                                                                DayOfWeek.Saturday,
                                                                DayOfWeek.Sunday
                                                            }
                                                        )
                                                ),
                     //expected
                     new Decimal(18)
                }


        };
        [Theory]
        [MemberData(nameof(TrueRequest))]
        public void Test_GetTax_ValidRequest_CompleteTariffDefination_Rturn_Fee(CongestionTaxRequestDto inputRequest, Model.TariffDefinition inputTariffDefinition, Decimal expected)
        {
            //Arrange
            ICongestionTaxAppService congestionTaxAppService = new CongestionTaxAppService(inputTariffDefinition);

            //Act
            Decimal actual = congestionTaxAppService.GetTax(inputRequest);

            //Asserts
            Assert.Equal(actual, expected);
        }


        private void TestCongestionTaxInitData()
        {

        }

        /*private void GenerateCompleteCongestionTaxInitData11()
        {


            #region Cities 
            var gothenburgCity = new Persistence.City { Name = "Gothenburg" };
            var londonCity = new Persistence.City { Name = "London" };
            _context.Cities.Add(gothenburgCity);
            #endregion

            #region TariffDefinition            
            //---------------------------------------Gothenburg City Tariff Defination: No:1 , Year = 2013----------------------------------------------------------------------------
            var tariffDefinitionGothenburg_NO1_2013 = new Persistence.TariffDefinition { City = gothenburgCity, TariffNO = 1, StartTariffYear = 2013, IsActive = true };
            _context.TariffDefinitions.Add(tariffDefinitionGothenburg_NO1_2013);
            //---------------------------------------London City Tariff Defination: No:1 , Year = 2013----------------------------------------------------------------------------
            var tariffDefinitionLondon_NO1_2013 = new Persistence.TariffDefinition { City = londonCity, TariffNO = 1, StartTariffYear = 2013, IsActive = true };
            _context.TariffDefinitions.Add(tariffDefinitionLondon_NO1_2013);

            #region ExemptVehicles 
            _context.ExemptVehicles.AddRange(new List<Persistence.ExemptVehicle>
                {
                    new Persistence.ExemptVehicle { VehicleType = "Emergency", TariffDefinition = tariffDefinitionGothenburg_NO1_2013 },
                    new Persistence.ExemptVehicle { VehicleType = "Bus", TariffDefinition = tariffDefinitionGothenburg_NO1_2013 },
                    new Persistence.ExemptVehicle { VehicleType = "Diplomat", TariffDefinition = tariffDefinitionGothenburg_NO1_2013 },
                    new Persistence.ExemptVehicle { VehicleType = "Motorcycles", TariffDefinition = tariffDefinitionGothenburg_NO1_2013 },
                    new Persistence.ExemptVehicle { VehicleType = "Foreign", TariffDefinition = tariffDefinitionGothenburg_NO1_2013 },
                });

            _context.ExemptVehicles.AddRange(new List<Persistence.ExemptVehicle>
                {
                    new Persistence.ExemptVehicle { VehicleType = "Emergency", TariffDefinition = tariffDefinitionLondon_NO1_2013 },
                    new Persistence.ExemptVehicle { VehicleType = "Diplomat", TariffDefinition = tariffDefinitionLondon_NO1_2013 },
                    new Persistence.ExemptVehicle { VehicleType = "Foreign", TariffDefinition = tariffDefinitionLondon_NO1_2013 },
                });
            #endregion

            #region Persistence.TariffCost  
            //------------------------------------------TariffCost: Gothenburg , No: 1 , Year = 2013 , IsActive ---------------------------------------
            _context.TariffCosts.AddRange(new List<Persistence.TariffCost>
            {
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(0, 0, 0), ToTime = new TimeSpan(5, 59, 59), Amount = 0.00m },
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(6, 0, 0), ToTime = new TimeSpan(6, 29, 59), Amount = 8.00m },
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(6, 30, 0), ToTime = new TimeSpan(6, 59, 59), Amount = 13.00m },
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(7, 0, 0), ToTime = new TimeSpan(7, 59, 59), Amount = 18.00m },
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(8, 0, 0), ToTime = new TimeSpan(8, 29, 59), Amount = 13.00m },

                new Persistence.TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(8, 30, 0), ToTime = new TimeSpan(14, 59, 59), Amount = 8.00m },
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(15, 0, 0), ToTime = new TimeSpan(15, 29, 59), Amount = 13.00m },
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(15, 30, 0), ToTime = new TimeSpan(16, 59, 59), Amount = 18.00m },
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(17, 0, 0), ToTime = new TimeSpan(17, 59, 59), Amount = 13.00m },

                new Persistence.TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(18, 0, 0), ToTime = new TimeSpan(18, 29, 59), Amount = 8.00m },
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionGothenburg_NO1_2013, FromTime = new TimeSpan(18, 30, 0), ToTime = new TimeSpan(23, 59, 59), Amount = 0.00m },
            });



            //------------------------------------------TariffCost: London , No: 1 , Year = 2013 , IsActive ---------------------------------------

            _context.TariffCosts.AddRange(new List<Persistence.TariffCost>(){
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(0, 0, 0), ToTime = new TimeSpan(5, 59, 59), Amount = 0.00m },
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(6, 0, 0), ToTime = new TimeSpan(6, 29, 59), Amount = 18.00m },
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(6, 30, 0), ToTime = new TimeSpan(6, 59, 59), Amount = 20.00m },
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(7, 0, 0), ToTime = new TimeSpan(7, 59, 59), Amount = 20.00m },
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(8, 0, 0), ToTime = new TimeSpan(8, 29, 59), Amount = 40.00m },

                new Persistence.TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(8, 30, 0), ToTime = new TimeSpan(14, 59, 59), Amount = 8.00m },
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(15, 0, 0), ToTime = new TimeSpan(15, 29, 59), Amount = 13.00m },
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(15, 30, 0), ToTime = new TimeSpan(16, 59, 59), Amount = 20.00m },
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(17, 0, 0), ToTime = new TimeSpan(17, 59, 59), Amount = 40.00m },

                new Persistence.TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(18, 0, 0), ToTime = new TimeSpan(18, 29, 59), Amount = 8.00m },
                new Persistence.TariffCost { TariffDefinition = tariffDefinitionLondon_NO1_2013, FromTime = new TimeSpan(18, 30, 0), ToTime = new TimeSpan(23, 59, 59), Amount = 0.00m },
            });

            #endregion

            #region TariffSetting

            //--------------------------------------- Tariff Setting: No:1 , Year = 2013 , IsACtive , Gothenburg----------------------------------------------------------------------------
            var tariffSettingGothenburg_NO1_2013 = new Persistence.TariffSetting { NumberTaxFreeDaysBeforeHoliday = 1, MaxTaxAmount = 60.00m, TaxFreeMonthCalender = MONTH.July, SingleCharegeInterval = 60, TariffDefinition = tariffDefinitionGothenburg_NO1_2013 };

            //--------------------------------------- Tariff Setting: No:1 , Year = 2013 , IsACtive , London----------------------------------------------------------------------------
            var tariffSettingLondon_NO1_2013 = new Persistence.TariffSetting { NumberTaxFreeDaysBeforeHoliday = 2, MaxTaxAmount = 60.00m, TaxFreeMonthCalender = MONTH.May, SingleCharegeInterval = 60, TariffDefinition = tariffDefinitionLondon_NO1_2013 };


            //---------------------------------------Gothenburg City----------------------------------------------------------------------------
            _context.TariffSettings.Add(tariffSettingGothenburg_NO1_2013);

            //---------------------------------------London City----------------------------------------------------------------------------
            _context.TariffSettings.Add(tariffSettingLondon_NO1_2013);
            #endregion

            #region PublicHoliday



            //--------------------------------------- PublicHoliday:  Gothenburg----------------------------------------------------------------------------
            _context.PublicHolidays.Add(new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 1, 2), TariffSettingId = tariffSettingGothenburg_NO1_2013.Id });
            _context.PublicHolidays.Add(new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 4, 7), TariffSettingId = tariffSettingGothenburg_NO1_2013.Id });
            _context.PublicHolidays.Add(new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 4, 10), TariffSettingId = tariffSettingGothenburg_NO1_2013.Id });
            _context.PublicHolidays.Add(new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 5, 10), TariffSettingId = tariffSettingGothenburg_NO1_2013.Id });

            //--------------------------------------- Persistence.PublicHoliday:  London----------------------------------------------------------------------------
            _context.PublicHolidays.Add(new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 1, 2), TariffSettingId = tariffSettingLondon_NO1_2013.Id });
            _context.PublicHolidays.Add(new Persistence.PublicHoliday { DateHoliday = new DateTime(2013, 4, 7), TariffSettingId = tariffSettingLondon_NO1_2013.Id });




            #endregion

            #region WorkingDays



            //--------------------------------------- WorkingDay of Settings----------------------------------------------------------------------------
            _context.WorkingDays.Add(new Persistence.WorkingDay { day = DayOfWeek.Saturday, IsWeekend = true, TariffSettings = new List<Persistence.TariffSetting>() { tariffSettingGothenburg_NO1_2013, tariffSettingLondon_NO1_2013 } });
            _context.WorkingDays.Add(new Persistence.WorkingDay { day = DayOfWeek.Sunday, IsWeekend = true, TariffSettings = new List<Persistence.TariffSetting>() { tariffSettingGothenburg_NO1_2013, tariffSettingLondon_NO1_2013 } });

            _context.WorkingDays.Add(new Persistence.WorkingDay { day = DayOfWeek.Monday, IsWeekend = false, TariffSettings = new List<Persistence.TariffSetting>() { tariffSettingGothenburg_NO1_2013, tariffSettingLondon_NO1_2013 } });
            _context.WorkingDays.Add(new Persistence.WorkingDay { day = DayOfWeek.Thursday, IsWeekend = false, TariffSettings = new List<Persistence.TariffSetting>() { tariffSettingGothenburg_NO1_2013, tariffSettingLondon_NO1_2013 } });
            _context.WorkingDays.Add(new Persistence.WorkingDay { day = DayOfWeek.Wednesday, IsWeekend = false, TariffSettings = new List<Persistence.TariffSetting>() { tariffSettingGothenburg_NO1_2013, tariffSettingLondon_NO1_2013 } });
            _context.WorkingDays.Add(new Persistence.WorkingDay { day = DayOfWeek.Tuesday, IsWeekend = false, TariffSettings = new List<Persistence.TariffSetting>() { tariffSettingGothenburg_NO1_2013, tariffSettingLondon_NO1_2013 } });
            _context.WorkingDays.Add(new Persistence.WorkingDay { day = DayOfWeek.Friday, IsWeekend = false, TariffSettings = new List<Persistence.TariffSetting>() { tariffSettingGothenburg_NO1_2013, tariffSettingLondon_NO1_2013 } });
            #endregion

            #endregion
            _context.SaveChanges();

        }*/

        private IList<CongestionTaxRequestDto> GenerateRequest()
        {

            IList<CongestionTaxRequestDto> congestionTaxRequests = new List<CongestionTaxRequestDto>() {
                 Fixture.Build<CongestionTaxRequestDto>()
                .With(x => x.CityName, "Gothenburg")
                .With(x => x.VehicleType, "Motorcycles")
                .With(x => x.TrafficTimeSequence, new List<DateTime> {
                        new DateTime(2013,1,14,21,0,0) , new DateTime(2013,1,15,21,0,0) ,new DateTime(2013,2,7,6,23,27) ,new DateTime(2013,2,7,15,27,0)
                }).Create(),

                 Fixture.Build<CongestionTaxRequestDto>()
                .With(x => x.CityName, "Gothenburg")
                .With(x => x.VehicleType, "Car")
                .With(x => x.TrafficTimeSequence, new List<DateTime> {
                        new DateTime(2013,1,14,21,0,0) , new DateTime(2013,1,15,21,0,0) ,new DateTime(2013,2,7,6,23,27) ,new DateTime(2013,2,7,15,27,0)
                }).Create()

            };
            return congestionTaxRequests;
        }


    }//class
}