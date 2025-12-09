using System;
using eCommerce.Model.Responses;

namespace eCommerce.Model.Responses
{
    public class CartItemResponse
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedAt { get; set; }
        public ProductResponse Product { get; set; } = null!;
    }
}

