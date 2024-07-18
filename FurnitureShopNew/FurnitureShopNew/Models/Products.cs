using System.ComponentModel.DataAnnotations;

namespace FurnitureShopNew.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int StockQuantity { get; set; }
    }
}