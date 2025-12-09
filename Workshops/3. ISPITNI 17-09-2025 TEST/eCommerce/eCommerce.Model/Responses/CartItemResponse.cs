using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Model.Responses
{
    public class CartItemResponse
    {
        public ProductResponse Product { get; set; }
        public int Count { get; set; }

    }
}
