using FurnitureShopNew.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureShopNew
{
    public class FurnitureShopDBContext : DbContext
    {
        public FurnitureShopDBContext(DbContextOptions<FurnitureShopDBContext> options)
            :base(options) { }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<OrdersDetail> OrdersDetail { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
