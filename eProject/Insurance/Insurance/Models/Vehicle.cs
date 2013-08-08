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
        [StringLength(50)]
        public string VehicleName { get; set; }

        [Required]
        [Display(Name = "License Plate")]
        [StringLength(15)]
        public string VehicleNumber { get; set; }

        [Required]
        [Display(Name = "Model")]
        [StringLength(20)]
        public string VehicleModel { get; set; }

        [Required]
        [Display(Name = "Version")]
        public int VehicleVersion { get; set; }

        [Required]
        [Display(Name = "Body Number")]
        [StringLength(20)]
        public string VehicleBodyNumber { get; set; }

        [Required]
        [Display(Name = "Engine Number")]
        [StringLength(20)]
        public string VehicleEngineNumber { get; set; }

        [Required]
        [Display(Name = "Warranty")]
        public bool VehicleWarranty { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

    }
}