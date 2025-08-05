using Microsoft.EntityFrameworkCore;
using WebShopMVC.Data.Models;

namespace WebShopMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .Property(p => p.Price)
                        .HasPrecision(9, 2);

            modelBuilder.Entity<User>()
                        .HasIndex(u => u.Email)
                        .IsUnique();
        }
    }
}
