using System.ComponentModel.DataAnnotations;

namespace FurnitureShopNew.Models
{
    public class OrdersDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        [Required]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}