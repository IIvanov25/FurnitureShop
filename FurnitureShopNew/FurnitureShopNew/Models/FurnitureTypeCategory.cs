using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FurnitureShopNew.Models
{
    public class FurnitureTypeCategory
    {
        [Key]
        public int FurnitureTypeCategoryId { get; set; }

        [Required]
        public string Name{ get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public FurnitureTypeCategory()
        {
            Products = new HashSet<Product>();
        }
    }
}
