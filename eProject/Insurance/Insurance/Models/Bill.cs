using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Insurance.Models
{
    [Table("Billings")]
    public class Bill
    {
        [Key]
        public int BillNo { get; set; }

        //[ForeignKey("VehicleId")]
        public int VehicleId { get; set; }

        //[ForeignKey("PolicyId")]
        public int PolicyId { get; set; }

        [Required]
        [Display(Name = "Customer Prove")]
        public string CustomerAddProve { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        public virtual Policy Policy { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}