using System.ComponentModel.DataAnnotations;

namespace FurnitureShopNew.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        public virtual ICollection<RoomCategory> RoomCategories { get; set; }
        public virtual ICollection<FurnitureTypeCategory> FurnitureTypeCategories { get; set; }

        public Product()
        {
            RoomCategories = new HashSet<RoomCategory>();
            FurnitureTypeCategories = new HashSet<FurnitureTypeCategory>();
        }
    }
}