using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FurnitureShopNew.Models
{
    public class FurnitureTypeCategory
    {
        [Key]
        public int FurnitureTypeCategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<RoomCategory> RoomCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public FurnitureTypeCategory()
        {
            Products = new HashSet<Product>();
            RoomCategories = new HashSet<RoomCategory>();
        }
    }
}
