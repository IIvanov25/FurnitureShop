using System.ComponentModel.DataAnnotations;

namespace FurnitureShopNew.Models
{
    public class RoomCategory
    {
        [Key]
        public int RoomCategoryId { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public RoomCategory()
        {
            Products = new HashSet<Product>();
        }
    }
}
