using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Insurance.Models;
namespace Insurance.Areas.Admin.Models
{
    [Table("Admins")]
    public class Admin
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class CustomerEdit
    {
        public Customer Customer { get; set; }

        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm new Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Password mismatch.")]
        public string ConfirmPassword { get; set; }
    }
}