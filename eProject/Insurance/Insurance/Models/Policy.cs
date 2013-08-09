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
        [Display(Name = "Policy Type")]
        [StringLength(50)]
        public string PolicyType { get; set; }

        [Required]
        [Display(Name = "Duration")]
        [Range(10, int.MaxValue)]
        public int PolicyDuration { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Policy Fee")]
        [DataType(DataType.Currency)]
        public decimal PolicyPrice { get; set; }

        public virtual ICollection<CustomerPolicy> CustomerPolicies { get; set; }
    }
}