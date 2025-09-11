using System;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Model.Requests
{
    public class ActivityUpsertRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }



    }
} 