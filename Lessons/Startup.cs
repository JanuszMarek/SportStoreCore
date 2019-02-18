using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lessons.Infrastructure;
using Microsoft.AspNetCore.Routing;

namespace Lessons
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //add possibility to use Inline Custom Constraint 
            services.Configure<RouteOptions>(options =>
                options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint)));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //For using Route attributes
            //default:   {controller}/{action}/{id?} 
            app.UseMvcWithDefaultRoute();

            /*
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "MyRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" },
                    constraints: new { id = new WeekDayConstraint() });
                //lub Inline Custom Constraint 
                routes.MapRoute(name: "MyRoute",
                      template: "{controller=Home}/{action=Index}/{id:weekday?}");

                /*
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}/{*catchall}",
                    defaults: new { controller = "Home", action = "Index" });

                
                  routes.MapRoute(name: "MyRoute",
                      template: "{controller=Home}/{action=Index}/{id:range(10,20)?}");  
                 * 
                routes.MapRoute(name: "MyRoute",
                   template: "{controller:regex(^H.*)=Home}/{action:regex(^Index$|^About$)=Index}/{id?}");

                 routes.MapRoute(name: "MyRoute",
                      template: "{controller=Home}/{action=Index}/{id:alpha:minlength(6)?}");
               

            });
             */
        }
    }
}
