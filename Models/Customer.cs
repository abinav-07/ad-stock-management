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
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public int CustomerPhone { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        [Required]
        public string MemberType { get; set; }
    }
}
