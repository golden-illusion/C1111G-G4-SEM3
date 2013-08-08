using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Insurance.Models
{
    [Table("Bills")]
    public class Bill
    {
        [Key]
        public int BillNo { get; set; }

        [Required]
        [Display(Name = "Customer Prove")]
        [StringLength(100)]
        public string CustomerAddProve { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public int CustPolicyId { get; set; }

        public virtual CustomerPolicy CustomerPolicy { get; set; }
    }
}