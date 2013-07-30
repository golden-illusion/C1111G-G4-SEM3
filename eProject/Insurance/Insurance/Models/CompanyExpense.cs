using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Insurance.Models
{
    [Table("CompanyExpenses")]
    public class CompanyExpense
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ExpenseID { get; set; }

        [Required]
        [Display(Name = "Expense Type")]
        public string ExpenseType { get; set; }

        [Required]
        [Display(Name = "Expense Date")]
        [DataType(DataType.Date)]
        public DateTime ExpenseDate { get; set; }

        [Required]
        [Display(Name = "Expense Amount")]
        [DataType(DataType.Currency)]
        public decimal ExpenseAmount { get; set; }
    }
}