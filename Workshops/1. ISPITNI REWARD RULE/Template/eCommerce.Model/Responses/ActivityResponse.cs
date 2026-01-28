using System;

namespace eCommerce.Model.Responses
{
    public class ActivityResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }

    }
} 