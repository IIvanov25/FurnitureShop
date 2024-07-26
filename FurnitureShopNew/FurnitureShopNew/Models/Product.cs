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
        [Required]
        public int FurnitureTypeCategoryId { get; set; }
        [Required]
        public int RoomCategoryId { get; set; }

        public Product()
        {
        }
    }
}