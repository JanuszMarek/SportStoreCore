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
using Lessons.Areas.DependencyInjection.Models;
using Lessons.Areas.DependencyInjection.Infrastructure;
using Lessons.Areas.Filters.Infrastructure;
using Microsoft.AspNetCore.Routing;


namespace Lessons
{
    public class Startup
    {
        private IHostingEnvironment env;

        public Startup(IHostingEnvironment hostEnv)
        {
            env = hostEnv;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                //options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //add possibility to use Inline Custom Constraint 
            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint));
                options.LowercaseUrls = true;   //change URL to low case
                options.AppendTrailingSlash = true; //add "/" to end of URL
                });

            //DI - set AlternateRepo
            TypeBroker.SetRepositoryType<AlternateRepository>();
            //using ASP.NET DI
            //Transient - tells the service provider to create a new instance of the implementation type whenever it needs to resolve a dependency

            /* Diff Repo depends of Envairoment
            services.AddTransient<IRepository>(provider => {
                if (env.IsDevelopment())
                {
                    var x = provider.GetService<MemoryRepository>();
                    return x;
                }
                else
                {
                    return new AlternateRepository();
                }
            });
            services.AddTransient<MemoryRepository>();
            */

            //AddScoped  method ensures that both objects’ dependencies are resolved with a single MemoryRepository object.
            //services.AddScoped<IRepository, MemoryRepository>();

            //The AddSingleton  method creates a new instance of the  MemoryRepository  class the first time that it
            //has to resolve a dependency on the IRepository  interface and then reuses that instance for any subsequent
            //dependencies, even if they are associated with different HTTP requests
            services.AddSingleton<IRepository, MemoryRepository>();

            services.AddTransient<IModelStorage, DictionaryStorage>();
            services.AddTransient<ProductTotalizer>();

            //filtry
            services.AddScoped<IFilterDiagnostics, DefaultFilterDiagnostics>();
            services.AddScoped<TimeFilter>();
            services.AddScoped<ViewResultDiagnostics>();
            services.AddScoped<DiagnosticsFilter>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddMvcOptions(options =>
            {
                //GLOBALS FILTERS
                //options.Filters.AddService(typeof(ViewResultDiagnostics));
                //options.Filters.AddService(typeof(DiagnosticsFilter));
            });

            //AddMemoryCache  and  AddSession  methods create services that are required for session management
            services.AddMemoryCache();
            services.AddSession();
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

            /*
                The UseSession  method adds a middleware component to the pipeline that associates session
                data with requests and adds cookies to responses to ensure that future requests can be identified.The
                UseSession  method must be called before the  UseMvc method so that the session component can intercept
                requests before they reach MVC middleware and can modify responses after they have been generated.
            */
            app.UseSession();
            //app.UseCookiePolicy();


            //For using Route attributes
            //default:   {controller}/{action}/{id?} 
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


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
