using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;
using FurnitureShopNew.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace FurnitureShopNew
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container
            services.AddControllersWithViews();

            // Configure the DbContext with a connection string
            services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Data Source=MONI;Initial Catalog=FurnitureShop;Integrated Security=True;Encrypt=True;Trust Server Certificate=True")));

            // Register repositories and services for dependency injection
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartRepo, CartRepo>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrdersRepo, OrdersRepo>();
            services.AddScoped<IOrdersService, OrdersService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
