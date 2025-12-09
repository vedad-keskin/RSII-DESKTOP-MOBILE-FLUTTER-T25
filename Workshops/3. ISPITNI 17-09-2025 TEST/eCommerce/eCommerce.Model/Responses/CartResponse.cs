using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Model.Responses
{
    public class CartResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<CartItemResponse> Items { get; set; } = new List<CartItemResponse>();

    }
}
