using System.ComponentModel.DataAnnotations;

namespace FurnitureShopNew.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
