using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Model.Requests
{
    public class RewardRuleUpsertRequest
    {

        [Required]
        public int ActivityId { get; set; }

        //public string RewardTitle { get; set; } = string.Empty;

        //public int MaxDaysToComplete { get; set; } = 0;

        public int NumberOfPoints { get; set; }



    }
} 