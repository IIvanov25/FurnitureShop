using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureShopNew.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

        [NotMapped]
        public decimal TotalProductSum
        {
            get
            {
                return CartItems?.Sum(item => item.Product.Price * item.Quantity) ?? 0;
            }
        }
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }
    }
}

