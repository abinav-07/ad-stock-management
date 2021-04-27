using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCourseWork.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Cat")]
        public int CategoryId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Product Name is Required")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public string Remarks { get; set; }
        public virtual Category Cat { get; set; }
        public virtual User User { get; set; }

    }
}
