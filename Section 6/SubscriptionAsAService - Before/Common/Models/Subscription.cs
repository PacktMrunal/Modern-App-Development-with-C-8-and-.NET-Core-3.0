using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Subscription
    {
        [Required]
        public int Id { get; set; }

        public Plan Plan { get; set; }

        [Required]
        public int PlanId { get; set; }

        public string Coupon { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string HolderName { get; set; }

        [Required]
        public string ExpirationDate { get; set; }

        [Required]
        public string Cvv { get; set; }

        [Required]
        public int UserId { get; set; }


    }
}
