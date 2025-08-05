using Microsoft.AspNetCore.Mvc;
using System;
using WebShopMVC.Services;
using WebShopMVC.Services.Implementations;
using WebShopMVC.Data;
using WebShopMVC.Data.Repositories;
using WebShopMVC.Data.Repositories.Implementations;
using WebShopMVC.Data.Models;

namespace WebShopMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();

            builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddScoped<ReviewRepository>();
            builder.Services.AddScoped<IReviewService, ReviewService>();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
