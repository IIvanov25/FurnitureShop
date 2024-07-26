using Microsoft.EntityFrameworkCore;

namespace FurnitureShopNew.Models
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FurnitureTypeCategory> FurnitureTypeCategories { get; set; }
        public DbSet<RoomCategory> RoomCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<int>();

            // Configure Cart entity
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId);

            // Configure Order entity
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Cart)
                .WithMany()
                .HasForeignKey(o => o.CartId);

            // Configure CartItem entity
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId);

            modelBuilder.Entity<Product>()
               .HasMany(p => p.FurnitureTypeCategories)
               .WithMany(f => f.Products)
               .UsingEntity<Dictionary<string, object>>(
                  "ProductFurnitureTypeCategory",
             j => j
               .HasOne<FurnitureTypeCategory>()
               .WithMany()
               .HasForeignKey("FurnitureTypeCategoryId")
               .OnDelete(DeleteBehavior.Cascade),
            j => j
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey("ProductId")
                .OnDelete(DeleteBehavior.Cascade));

            // Configure many-to-many relationship between FurnitureTypeCategory and RoomCategory
            modelBuilder.Entity<FurnitureTypeCategory>()
                .HasMany(f => f.RoomCategories)
                .WithMany(r => r.FurnitureTypeCategories)
                .UsingEntity<Dictionary<string, object>>(
                    "FurnitureTypeCategoryRoomCategory",
                    j => j
                        .HasOne<RoomCategory>()
                        .WithMany()
                        .HasForeignKey("RoomCategoryId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<FurnitureTypeCategory>()
                        .WithMany()
                        .HasForeignKey("FurnitureTypeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade));

            //configure RoomCategory entity
            //modelBuilder.Entity<RoomCategory>()
        }
    }
}