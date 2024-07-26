using System.ComponentModel.DataAnnotations;

namespace FurnitureShopNew.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(255)]
        public string ProfilePicUrl { get; set; } = "default";

        [Required]
        public UserType Role { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
        public virtual Cart Cart { get; set; }

        public User()
        {
            Orders = new HashSet<Order>();
        }
    }
}