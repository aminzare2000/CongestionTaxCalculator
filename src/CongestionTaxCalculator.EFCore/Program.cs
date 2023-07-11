using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using CongestionTaxCalculator.EFCore.Extensions;
using CongestionTaxCalculator.EFCore.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace CongestionTaxCalculator.EFCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()
                                                .MigrateDatabase<CongestionTaxContext>((context, services) =>
                                                {
                                                    var logger = services.GetService<ILogger<CongestionTaxContextSeed>>();
                                                    CongestionTaxContextSeed
                                                    .SeedAsync(context, logger)
                                                    .Wait();
                                                })
                .Start();
           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
