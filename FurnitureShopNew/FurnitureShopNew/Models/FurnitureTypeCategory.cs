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
        public virtual ICollection<Product> Products { get; set; }
        public FurnitureTypeCategory()
        {
            Products = new HashSet<Product>();
        }
    }
}