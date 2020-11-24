using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Razor;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarAndGo.Data.Interfaces;
using CarAndGo.Data.mocks;
using Microsoft.Extensions.Configuration;
using CarAndGo.Data;
using Microsoft.EntityFrameworkCore;
using CarAndGo.Data.Repository;

namespace CarAndGo
{
    public class Startup
    {

        private IConfigurationRoot _confSting;
        public Startup(IWebHostEnvironment hostEnv)
        {
            _confSting = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.   
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        
        {
            /* Service Configuration */
            /* AddTransient leidzia susieti tam tikra interfeisa ir klase kuri realizuoja ji */
            /* ICarRepository realizuojasi klaseje ...... */

            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confSting.GetConnectionString("DefaultConnection")));
            services.AddTransient<ICarRepository, CarRepository>(); 
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            //Old Way
            // services.AddMvc();
            // New Ways
           services.AddRazorPages();
           services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage(); 
            app.UseStatusCodePages();/* 404, 200 .. */
            app.UseStaticFiles();


            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });


            /*     using (var scope = app.ApplicationServices.CreateScope()) *//* Startuojant mes visada kviesime ta funkcija *//*
                 {
                     AppDBContent content;  
                     content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                 } */

            DBObjects.Initial(app);
        }

    }
}
