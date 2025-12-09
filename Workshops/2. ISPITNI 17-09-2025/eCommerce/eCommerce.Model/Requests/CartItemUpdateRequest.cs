using System.ComponentModel.DataAnnotations;

namespace eCommerce.Model.Requests
{
    public class CartItemUpdateRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}

