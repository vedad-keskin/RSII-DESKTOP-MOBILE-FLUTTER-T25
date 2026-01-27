using System;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Model.Responses
{
    public class FavouritesResponse
    {
        [Key]
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        public int ProductId { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}
