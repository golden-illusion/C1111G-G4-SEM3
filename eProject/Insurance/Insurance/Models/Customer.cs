using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Insurance.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Customer")]
        [StringLength(40, ErrorMessage = "The {0} have must be at least {2} characters",MinimumLength = 2)]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Customer Add")]
        public string CustomerAdd { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string CustomerPhone { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}