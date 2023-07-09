using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using CongestionTaxCalculator.DbMigrator.Data;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.DbMigrator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<CongestionTaxContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnectionString")));
            //options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnectionString")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

        }
    }
}
