using System.ComponentModel.DataAnnotations;

namespace FurnitureShopNew.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
