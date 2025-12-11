using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Services.Database
{
    public class CartEventIB180079
    {
        [Key]
        public int Id { get; set; }
        
        // FK to Cart (optional)
        public int? CartId { get; set; }
        
        [ForeignKey("CartId")]
        public Cart? Cart { get; set; }
        
        // FK to CartItem (optional)
        public int? CartItemId { get; set; }
        
        [ForeignKey("CartItemId")]
        public CartItem? CartItem { get; set; }
        
        // FK to User
        [Required]
        public int UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
        
        // Type of event (adding, removing, quantity change, clearing, checkout)
        [Required]
        [MaxLength(100)]
        public string Type { get; set; } = string.Empty;
        
        // CreatedAt defaults to DateTime.Now
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        // FK to Product
        public int? ProductId { get; set; }
        
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        
        // OldQuantity and NewQuantity for future quantity updates
        public int? OldQuantity { get; set; }
        
        public int? NewQuantity { get; set; }
    }
}

