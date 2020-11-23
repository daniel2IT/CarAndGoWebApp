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

namespace CarAndGo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.   
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /* Service Configuration */
            /* AddTransient leidzia susieti tam tikra interfeisa ir klase kuri realizuoja ji */
            /* ICarRepository realizuojasi klaseje MockCarRepository */
            services.AddTransient<ICarRepository, MockCarRepository>();
            services.AddTransient<ICategoryRepository, MockCategoryRepository>();

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
        }

    }
}
