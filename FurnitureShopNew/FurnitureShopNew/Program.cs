using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;
using FurnitureShopNew.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FurnitureShopNew
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllers(); // Register API controllers

            //builder.Services.AddDbContext<ShopDbContext>(options =>
            //   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging() 
           .LogTo(Console.WriteLine, LogLevel.Information));

            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IOrdersRepo, OrdersRepo>();
            builder.Services.AddScoped<IOrdersService, OrdersService>();
            builder.Services.AddScoped<ICartRepo, CartRepo>();
            builder.Services.AddScoped<ICartService, CartService>();
            //add all the other shit you are using 

            // Add CORS services
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Use CORS policy
            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers(); // Map API controllers

            app.Run();
        }
    }
}