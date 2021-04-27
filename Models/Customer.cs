using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCourseWork.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer Name Required")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name = "Customer Phone No.")]
        public int CustomerPhone { get; set; }
        [Required(ErrorMessage = "Email Address Required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }
        [Required]
        [Display(Name = "Customer Address")]
        public string CustomerAddress { get; set; }
        [Required]
        public string MemberType { get; set; }
    }
}
