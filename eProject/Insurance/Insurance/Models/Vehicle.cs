using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Insurance.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }

        [Required]
        [Display(Name = "Vehicle")]
        public string VehicleName { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string VehicleModel { get; set; }

        [Required]
        [Display(Name = "Version")]
        public int VehicleVersion { get; set; }

        [Required]
        [Display(Name = "Rate")]
        [RegularExpression("^\\d\\.\\d$")]
        [Range(0.0, 5.0)]
        public double VehicleRate { get; set; }

        [Required]
        [Display(Name = "Body Number")]
        public string VehicleBodyNumber { get; set; }

        [Required]
        [Display(Name = "Engine Number")]
        public string VehicleEngineNumber { get; set; }

        [Required]
        [Display(Name = "Warranty")]
        public string VehicleWarranty { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

    }
}