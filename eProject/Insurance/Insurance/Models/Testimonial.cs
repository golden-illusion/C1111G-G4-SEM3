using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Insurance.Models
{
    [Table("Testimonials")]
    public class Testimonial
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TestimonialId { get; set; }

        //[ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Your Message")]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime TestimonialDate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}