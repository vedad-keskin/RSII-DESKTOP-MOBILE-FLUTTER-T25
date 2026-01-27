using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Model.Requests
{
    public class UserActivityUpsertRequest
    {
        [Required]

        public int UserId { get; set; }

        [Required]

        public int ActivityId { get; set; }

        public string? Note { get; set; }

    }
} 