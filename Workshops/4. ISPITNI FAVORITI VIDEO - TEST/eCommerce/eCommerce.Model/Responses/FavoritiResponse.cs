using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Model.Responses
{
    public class FavoritiResponse
    {
        [Key]
        public int Id { get; set; }

        public string UserFullName { get; set; } = string.Empty;
        
        public string ProductName { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        
    }
} 