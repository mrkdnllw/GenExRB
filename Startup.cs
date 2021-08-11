using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenExRB.Models;
using GenExRB.Models.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GenExRB
{
    public class Startup
    {
        private IConfiguration _config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("PropertyDBConnection")));

            services.AddMvc(options => options.EnableEndpointRouting = false);
            //services.AddSingleton<IPropertyRepository, MockPropertyRepository>();
            services.AddScoped<IPropertyRepository, SQLPropertyRepository>();
            services.AddScoped<PhotoService>();
            services.AddScoped<LocationService>();
            services.AddScoped<FeatureDataService>();
           

            services.AddScoped<FeatureDataService>();
            services.AddScoped<FeatureOptionService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseRouting();

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });*/

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync("wala ni exist ang page so mao ni ang default");

            });*/

        }
    }
}
