using InventoryControl.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryControl.Api.Data
{
    public class ICDbContext : DbContext
    {
        public ICDbContext(DbContextOptions<ICDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Caneta BIC Preta",
                Price = 5.89
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Notebook Mac Pro",
                Price = 8999.90
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Samsung S20+",
                Price = 4999.90
            });
        }
    }
}
