using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstASP.NETapplication.Data.EFContext;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop_MVC.Data.Interfaces;
using Shop_MVC.Data.Repository;

namespace Shop_MVC
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

            services.AddDbContext<EFDbContext>(options =>
           options.UseSqlServer(
             Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<DbUser, DbRole>(options => options.Stores.MaxLengthForKeys = 128)
                .AddEntityFrameworkStores<EFDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                   options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
               });

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });



            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<ICategoryType, CategoryTypeRepository>();
            services.AddTransient<IProducer, ProducerRepository>();
            services.AddTransient<IProduct, ProductRepository>();
            services.AddTransient<IProductRating, ProductRatingRepository>();
            services.AddTransient<IShopingCart, ShopingCartRepository>();
            services.AddTransient<IUser, UserRepository>();


            services.AddMemoryCache();
            services.AddSession();
            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
                //routes.MapRoute(
                //    name: "HomeRoute",
                //    template: "Home/Products",
                //    defaults: new { Controller = "Home", action = "Products" });
                //routes.MapRoute(
                //    name:"MensRoute",
                //    template: "{controller}/{action}/{category?}/{producer?}/{size?}/{colors?}/{gender?}/{rating?}",
                //    defaults: new { Controller = "Mens",action = "Catalog" }
                //    );
                
                //----------------------Product routs--------------------------

                routes.MapRoute(
                    name: "MensRoute",
                    template: "{controller}/{action}/{filers?}",
                    defaults: new { Controller = "Mens", action = "Catalog" }
                    );
                routes.MapRoute(
                   name: "WomensRoute",
                   template: "{controller}/{action}/{filers?}",
                   defaults: new { Controller = "Womens", action = "Catalog" }
                   );
                routes.MapRoute(
                   name: "KidsRoute",
                   template: "{controller}/{action}/{filers?}",
                   defaults: new { Controller = "Kids", action = "Catalog" }
                   );                
                routes.MapRoute(
                   name:"SaleRoute",
                   template: "{controller}/{action}/{filtes?}",
                   defaults: new { Controller = "Sale", action = "Catalog" }
                   );
                routes.MapRoute(
                   name: "NewestRoute",
                   template: "{controller}/{action}/{filtes?}",
                   defaults: new { Controller = "Newest", action = "Catalog" }
                   );

                //----------------------Account----------------------------

                routes.MapRoute(
                  name: "LoginRoute",
                  template: "{controller}/{action}",
                  defaults: new { Controller = "Account", action = "Login" }
                  );
                routes.MapRoute(
                  name: "RegisterRoute",
                  template: "{controller}/{action}",
                  defaults: new { Controller = "Account", action = "Register" }
                  );


                //----------------------Others route-----------------------

                //routes.MapRoute(
                // name: "CategoryRoute",
                // template: "{controller}/{action}/{subCategory?}",
                // defaults: new { Controller = "Category", action = "Index" }
                // );
                routes.MapRoute(
                   name: "ContactRoute",
                   template: "{controller}/{action}",
                   defaults: new { Controller = "Information", action = "Contacts" }
                   );
            });
        }
    }
}
