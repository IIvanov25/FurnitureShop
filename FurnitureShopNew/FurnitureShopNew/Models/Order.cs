using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [Required]
    public int CartId { get; set; }

    [ForeignKey("CartId")]
    public virtual Cart Cart { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal DeliveryPrice { get; set; }

    [Required]
    [MaxLength(255)]
    public string Address { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    public Order()
    {
    }
}
