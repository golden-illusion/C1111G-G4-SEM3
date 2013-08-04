using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Insurance.Models
{
    [Table("Policies")]
    public class Policy
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PolicyId { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string PolicyType { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public int PolicyDuration { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal PolicyPrice { get; set; }

        public virtual ICollection<CustomerPolicy> CustomerPolicies { get; set; }
    }
}