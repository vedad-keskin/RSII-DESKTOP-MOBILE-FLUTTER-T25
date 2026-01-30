using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Model.Requests
{
    public class ProductDiscountUpsertRequest
    {
        [Required]
        public int? ProductId { get; set; }


        [Required]
        [Column(TypeName = "decimal(5,2)")] // 100.00 , 
        public decimal Discount { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }
    }
} 