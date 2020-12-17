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
using CarAndGo.Data.Models;
using Microsoft.AspNetCore.Identity;

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
            services.AddIdentity<IdentityUser, IdentityRole>(options => {
            }).AddEntityFrameworkStores <AppDBContent>();

            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confSting.GetConnectionString("DefaultConnection")));
            services.AddTransient<ICarRepository, CarRepository>(); 
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            //Old Way
            // services.AddMvc();
            // New Ways
            services.AddRazorPages();
           services.AddCors();

            services.AddMemoryCache();
            services.AddSession();/* Servisai nurodantys, kad mes usinam Sesijas ir Cache */

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();/* Servisas leidziantis dirbti su sesijom */
            services.AddScoped(sp => ShopCart.GetCart(sp));/* Jis leis jeigu 2 naudotojai uzeis i krepseli, tai 2 naudotojams bus skirtingas krepselis */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage(); 
            app.UseStatusCodePages();/* 404, 200 .. */
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseCors();

            app.UseAuthentication(); // UseIndentity();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("categoryFilter", "Cars/{action}/{category?}", defaults: new { Controller="Cars",action="List"}); /* Action tikrai zinome kad tai list bet tebune default 
                                                                                           category List(string category) 
                                                                                            ? nebutinas, nes kartais noresime visus tiesiog isvesti  */
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
