using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{
    public class RewardRuleIB180079
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int ActivityId { get; set; }

        [ForeignKey("ActivityId")]
        public ActivityIB180079 Activity { get; set; } = null!;

        public string RewardTitle { get; set; } = string.Empty;

        public int MaxDaysToComplete { get; set; } = 0;

        public int NumberOfPoints { get; set; }



    }

}
