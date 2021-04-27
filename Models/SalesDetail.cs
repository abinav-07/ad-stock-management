using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCourseWork.Models
{
    public class SalesDetail
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("SalId")]
        [Display(Name = "Sales")]
        public int SalesId { get; set; }
        [ForeignKey("ProId")]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is Required")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Price ")]
        public int Price { get; set; }
        public virtual Sales SalId { get; set; }
        public virtual Product ProId { get; set; }
    }
}
