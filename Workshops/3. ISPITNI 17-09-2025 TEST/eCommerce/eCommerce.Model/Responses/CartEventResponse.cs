using System;

namespace eCommerce.Model.Responses
{
    public class CartEventResponse
    {
        public string FullName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}

