using System;
using System.Collections.Generic;

namespace eCommerce.Model.Responses
{
    public class CartResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CartItemResponse> CartItems { get; set; } = new List<CartItemResponse>();
    }
}

