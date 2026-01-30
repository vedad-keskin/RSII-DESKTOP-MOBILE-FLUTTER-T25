using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{
    public class ProductDiscount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }


        [Required]
        [Column(TypeName = "decimal(5,2)")] // 100.00 , 
        public decimal Discount { get; set; }

        [Required]
        public DateTime DateFrom { get; set; } 

        [Required]
        public DateTime DateTo { get; set; } 


    }
}
