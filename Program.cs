using Microsoft.EntityFrameworkCore;
using WebShopMVC.Data;
using WebShopMVC.Filters;
using WebShopMVC.Services;
using WebShopMVC.Services.Implementations;

namespace WebShopMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                string? connectionString = builder.Configuration.GetConnectionString("Default");

                if (string.IsNullOrWhiteSpace(connectionString))
                    throw new MissingFieldException("Failed to get Default connection string");

                options.UseSqlServer(connectionString);
            });

            builder.Services.AddSession();

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<CurrentUserFilter>();
            });

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseSession();

            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
