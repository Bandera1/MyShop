using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstASP.NETapplication.Data.EFContext;
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


            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<IProducer, ProducerRepository>();
            services.AddTransient<IProduct, ProductRepository>();
            services.AddTransient<IProductRating, ProductRatingRepository>();
            services.AddTransient<IShopingCart, ShopingCartRepository>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "HomeRoute",
                    template: "Home/Products/{page}/{category?}/{producer?}/{size?}/{colors?}/{gender?}/{rating?}",
                    defaults: new { Controller = "Home", action = "Products" });
            });
        }
    }
}
