using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Insurance.Models
{
    [Table("Claims")]
    public class Claim
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ClaimId { get; set; }

        [Required]
        [Display(Name = "Accident Place")]
        public string AccidentPlace { get; set; }

        [Required]
        [Display(Name = "Accident Date")]
        public DateTime AccidentDate { get; set; }

        [Required]
        [Display(Name = "Insured Amount")]
        public decimal InsuredAmount { get; set; }

        [Required]
        [Display(Name = "Claimable Amount")]
        public decimal ClaimableAmount { get; set; }

        public int CustPolicyId { get; set; }

        public virtual CustomerPolicy CustomerPolicy { get; set; }
    }
}