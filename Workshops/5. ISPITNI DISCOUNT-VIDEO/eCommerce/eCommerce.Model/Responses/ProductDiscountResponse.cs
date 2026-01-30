using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Model.Responses
{
    public class ProductDiscountResponse
    {
        [Key]
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;


        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }

        [Column(TypeName = "decimal(5,2)")] // 100.00 , 
        public decimal Discount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal NewPrice { get; set; }


        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public ICollection<AssetResponse> Assets { get; set; } = new List<AssetResponse>();

    }
} 