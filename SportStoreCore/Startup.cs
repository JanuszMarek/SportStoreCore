using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsStoreCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SportsStoreCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace SportsStoreCore
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
            services.AddSingleton<UptimeService>();


            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                    Configuration["ProductConnection:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(
                options => options.UseSqlServer(
                    Configuration["IdentityConnection:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            //PRODUCTS
            //services.AddTransient<IProductRepository, FakeProductRepository>();
            services.AddTransient<IProductRepository, EFProductRepository>();

            /*  The AddScoped  method specifies that the same object should be used to satisfy related requests for  Cart
                instances. How requests are related can be configured, but by default it means that any  Cart  required by
                components handling the same HTTP request will receive the same object. 
             */
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));

            /*  tells MVC to use the  HttpContextAccessor  class when
            implementations of the  IHttpContextAccessor  interface are required.
            */
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //ORDERS
            services.AddTransient<IOrderRepository, EFOrderRepository>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
            loggerFactory.AddDebug(LogLevel.Debug);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                // app.UseExceptionHandler("/Error");
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //MIDLEWARE
            app.UseMiddleware<ErrorMiddleware>();
            app.UseMiddleware<BrowserTypeMiddleware>();
            app.UseMiddleware<ShortCircuitMiddleware>();
            app.UseMiddleware<ContentMiddleware>();


            
            app.UseStaticFiles();
            app.UseSession();
            app.UseIdentity();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "Error", 
                    template: "Error",
                    defaults: new { controller = "Error", action = "Error" }
                );

                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{page:int}",
                    defaults: new { controller = "Product", action = "List" }
                );
                routes.MapRoute(
                    name: null,
                    template: "Page{page:int}",
                    defaults: new { controller = "Product", action = "List", page = 1 }
                );
                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { controller = "Product", action = "List", page = 1 }
                );
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Product", action = "List", page = 1 });

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");

            });

            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
