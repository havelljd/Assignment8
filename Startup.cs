using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeAmazon.Models;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
using Microsoft.AspNetCore.Http;

namespace FakeAmazon
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //passing the connection string into the configuration, and the database context
            services.AddDbContext<FakeAmazonDbContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:FakeAmazonConnection"]);
           });

            services.AddScoped<IAmazonRepository, EFAmazonRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1");
                await next();
            });

            //Here is my user friendly url links! The category, the page number, or a combination of the two!

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage", "{category}/{pagenum:int}", new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page", "{pagenum:int}", new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("category", "{category}", new { Controller = "Home", action = "Index", pagenum = 1 });



                endpoints.MapControllerRoute(
                   "pagination",
                   "P{pagenum}",
                   new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });
            //calling seed class
            SeedData.EnsurePopulated(app);
        }
    }
}
