using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FurnitureShopNew.Models
{
    public class FurnitureTypeCategory
    {
        [Key]
        public int FurnitureTypeCategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        [ForeignKey("RoomCategoryId")]
        public virtual RoomCategory RoomCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public FurnitureTypeCategory()
        {
            Products = new HashSet<Product>();
            RoomCategory = new RoomCategory();
        }
    }
}