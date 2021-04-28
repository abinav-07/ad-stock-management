using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCourseWork.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Cus")]
        [Display(Name = "Customer Name")]
        public int CustomerId { get; set; }
        [Display(Name = "Sales Date")]
        public DateTime SalesDate { get; set; }
        [Display(Name = "Bill Number")]
        public int BillNo { get; set; }
        public virtual Customer Cus { get; set; }
    }
}
