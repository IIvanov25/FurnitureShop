using System.ComponentModel.DataAnnotations;

namespace FurnitureShopNew.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}