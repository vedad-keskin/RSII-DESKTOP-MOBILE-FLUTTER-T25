using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{
    public class UserActivityIB180079
    {
        [Key]
        public int Id { get; set; }

        // User
        [Required]

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        [Required]

        public int ActivityId { get; set; }

        [ForeignKey("ActivityId")]
        public ActivityIB180079 Activity { get; set; } = null!;

        [Required]

        public DateTime DateAssigned { get; set; } = DateTime.Now;

        [Required]
        public string Status { get; set; } // moguće  - vrijednosti:
                                           // Assigned/InProgress/Completed/Cancelled

        public string? Note { get; set; }

        public DateTime? CompletedAt { get; set; }

        public string? RewardTitle { get; set; }

        public DateTime? RewardedAt { get; set; }



    }
}
