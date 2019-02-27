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
using Lessons.Areas.API.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Razor;
using Lessons.Areas.ViewLesson.Infrastructure;
using Lessons.Areas.UsingViewComponents.Models;
using Lessons.Areas.UsingTagHelpers.Models;
using Lessons.Areas.ModelBinding.Models;
using Lessons.Areas.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Lessons.Areas.Identity.Infrastructure;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Lessons
{
    public class Startup
    {
        private IHostingEnvironment env;
        IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment hostEnv)
        {
            env = hostEnv;
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();
        }



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

            //API
            services.AddSingleton<IReservRepository, ReservMemoryRepository>();
            

            //AREAs
            services.AddSingleton<IProductCompRepository, MemoryProductCompRepository>();
            services.AddSingleton<ICityRepository, MemoryCityRepository>();
            services.AddSingleton<ITagRepository, MemoryTagRepository>();
            services.AddSingleton<IBindRepository, MemoryBindRepository>();

            //filtry
            services.AddScoped<IFilterDiagnostics, DefaultFilterDiagnostics>();
            services.AddScoped<TimeFilter>();
            services.AddScoped<ViewResultDiagnostics>();
            services.AddScoped<DiagnosticsFilter>();


            //IDENTITY

            //  Registering a Custom Password Validator
            services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordValidator2>();
            //  Registering a Custom User Validator
            services.AddTransient<IUserValidator<AppUser>, CustomUserValidator2>();
            //  Creating Custom Policy Requirements 
            services.AddTransient<IAuthorizationHandler, BlockUsersHandler>();
            //  Creating the Resource Authorization Policy and Handler 
            services.AddTransient<IAuthorizationHandler, DocumentAuthorizationHandler>();

            services.AddAuthorization(opts => {
                opts.AddPolicy("JoeUsers", policy => 
                {
                    policy.RequireUserName("Joe");
                    policy.RequireRole("Users");
                    //policy.RequireClaim(ClaimTypes.StateOrProvince, "DC");
                });

                opts.AddPolicy("NotBob", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.AddRequirements(new BlockUsersRequirement(new[] { "Bob" }));
                });

                opts.AddPolicy("AuthorsAndEditors", policy => 
                {
                    policy.AddRequirements(new DocumentAuthorizationRequirement
                    {
                        AllowAuthors = true,
                        AllowEditors = true
                    });
                });

            });


            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration["Data:SportStoreIdentity:ConnectionString"]));
            services.AddIdentity<AppUser, IdentityRole>(
                opts =>
                {
                    //opts.Cookies.ApplicationCookie.LoginPath = "Indentity/Account/Login";

                    opts.User.RequireUniqueEmail = true;
                    //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";

                    opts.Password.RequiredLength = 6;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = false;
                }).AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddXmlDataContractSerializerFormatters()   //server can send data i XML
                .AddMvcOptions(options =>
                {
                    //GLOBALS FILTERS
                    //options.Filters.AddService(typeof(ViewResultDiagnostics));
                    //options.Filters.AddService(typeof(DiagnosticsFilter));

                   // options.ModelBindingMessageProvider.ValueMustNotBeNullAccessor("Please enter a value");
                });

            //CHANGING DEFAULT LOCATION OF VIEWS
            /*
            services.Configure<RazorViewEngineOptions>(options => {
                options.ViewLocationExpanders.Add(new SimpleExpander());
                options.ViewLocationExpanders.Add(new ColorExpander());
            });
            */

            //AddMemoryCache  and  AddSession  methods create services that are required for session management
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<AppUser> userManager)
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
            
            app.UseIdentity();
            //app.UseClaimsTransformation(LocationClaimsProvider.AddClaims);


            //For using Route attributes
            //default:   {controller}/{action}/{id?} 
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "Login",
                    template: "/Account/{action}/",
                    defaults: new { area = "Identity",controller = "Account", action="Login"}
                    );

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

            //AppIdentityDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
        }
    }
}
