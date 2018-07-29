using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
            Configuration["Data:BookStoreProducts:ConnectionString"]));

            //Configure the Identity database 
            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(
            Configuration["Data:BookStoreIdentity:ConnectionString"]));

            //Registering service for Identity
            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();

            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));   //Registering service for Cart and SessionCart
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();  //Registering order repository service
            services.AddMvc();
            services.AddMemoryCache();      //Enabling storing session state in memory
            services.AddSession();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseSession();          //Enabling session
            app.UseAuthentication();       //Set up components that will intercept requests and responses to implement the security policy

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List"}
                        );

                routes.MapRoute(
                    name: null,
                    template: "Page{productPage:int}",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                        productPage = 1
                    });

                routes.MapRoute(
                
                    name: null,
                    template: "{category}",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                        productPage = 1
                    });

                routes.MapRoute(
                
                    name: null,
                    template: "",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                        productPage = 1
                    });

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");

            });

            SeedData.EnsurePopulated(app);
        }
    }
}
