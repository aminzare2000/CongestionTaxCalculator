using Xunit;
using System;
using Microsoft.EntityFrameworkCore;
using CongestionTaxCalculator.Application;
using CongestionTaxCalculator.EFCore.Data;
using CongestionTaxCalculator.Application.Contracts;
using Moq;
using AutoFixture;
using Moq.EntityFrameworkCore;
using CongestionTaxCalculator.Domain.Model;
using System.Collections.Generic;

//https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices

namespace CongestionTaxCalculator.Test
{
    public class AppServiceTest : IDisposable
    {

        private static readonly Fixture Fixture = new Fixture();

        private readonly DbContextOptions<CongestionTaxContext> _options;
        private readonly ICongestionTaxAppService _congestionTaxAppService;
        private readonly CongestionTaxContext _context;

        public AppServiceTest()
        {
            //_options = new DbContextOptionsBuilder<CongestionTaxContext>()
            //    .UseSqlServer("Data Source=.;Initial Catalog=CongestionTaxDb;Integrated Security=True;TrustServerCertificate=True;")
            //    .Options;

            _options = new DbContextOptionsBuilder<CongestionTaxContext>()
                    .UseInMemoryDatabase(databaseName: "temp_db")
                    .Options;

            _context = new CongestionTaxContext(_options);            
            _congestionTaxAppService = new CongestionTaxAppService(_context);
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


            // Act
            var actual = _congestionTaxAppService.GetACity(input).Name;


            // Assert
            Assert.Equal(expected, actual);

        }


        [Theory]
        [InlineData("ABC", null)]
        public void When_NotExist_City_Return(string input, string expected)
        {

            // Arrange


            // Act
            var actual = _congestionTaxAppService.GetACity(input).Name;


            // Assert
            Assert.Null(actual);

        }

        private static void GenerateCompleteCongestionTaxRule()
        {

        }

            private static CongestionTaxRequestDto GenerateRequest()
        {


            var temp = Fixture.Build<CongestionTaxRequestDto>()
                .With(x => x.CityName, "Gothenburg")
                .With(x=>x.VehicleType, "Motorcycles")
                .With(x=>x.TrafficTimeSequence, new List<DateTime> { 
                        new DateTime(2013,1,14,21,0,0) , new DateTime(2013,1,15,21,0,0) ,new DateTime(2013,2,7,6,23,27) ,new DateTime(2013,2,7,15,27,0) 
                }).Create();

            return temp;
        }


    }
}