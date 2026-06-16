using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProductsAPI.Models
{
    // IdentityDbContext'e int tipini geçerek hatayı çözdük
    public class ProductsContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed verileri
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Iphone 14", Price = 60000, IsActive = true },
                new Product { ProductId = 2, ProductName = "Iphone 15", Price = 75000, IsActive = true },
                new Product { ProductId = 3, ProductName = "Iphone 16", Price = 90000, IsActive = false },
                new Product { ProductId = 4, ProductName = "Iphone 16 Pro", Price = 110000, IsActive = true },
                new Product { ProductId = 5, ProductName = "Iphone 17 Pro", Price = 120000, IsActive = true }
            );
        }

        public DbSet<Product> Products { get; set; }
    }
}