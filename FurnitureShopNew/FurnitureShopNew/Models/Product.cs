using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // Foreign Key
        [Required]
        public int FurnitureTypeCategoryId { get; set; }

        // Navigation Property
        public virtual FurnitureTypeCategory FurnitureTypeCategory { get; set; }

        public Product()
        {
        }
    }
}
