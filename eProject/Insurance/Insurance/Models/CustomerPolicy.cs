using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Insurance.Models
{
    [Table("CustomerPolicies")]
    public class CustomerPolicy
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CustPolicyId { get; set; }

        //[ForeignKey("PolicyId")]
        public int PolicyId { get; set; }

        //[ForeignKey("VehicleId")]
        public int VehicleId { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Policy Policy { get; set; }
    }
}