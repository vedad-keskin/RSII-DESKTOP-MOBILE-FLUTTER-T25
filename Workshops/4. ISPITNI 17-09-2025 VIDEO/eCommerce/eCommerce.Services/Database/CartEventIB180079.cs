using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{
    public class CartEventIB180079
    {
        [Key]
        public int Id { get; set; }

        public int? CartId { get; set; }

        [ForeignKey("CartId")]
        public Cart? Cart { get; set; }

        public int? CartItemId { get; set; }

        [ForeignKey("CartItemId")]
        public CartItem? CartItem { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }


        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(100)]
        public string Type { get; set; } = string.Empty;

        public int? OldQuantity { get; set; }
        public int? NewQuantity { get; set; }


    }
}
