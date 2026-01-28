using System;

namespace eCommerce.Model.Responses
{
    public class UserActivityResponse
    {
        public string UserFullName { get; set; } = string.Empty;
        public string ActivityName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public int NumberOfPoints { get; set; }

    }
} 