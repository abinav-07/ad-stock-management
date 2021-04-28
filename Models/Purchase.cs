using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCourseWork.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Date is Required")]
        [Display(Name = "Product Date")]
        public DateTime PurchaseDate { get; set; }
        [Required(ErrorMessage = "Vendor Name is Required")]
        [Display(Name = "Vendor Name")]
        public String VendorName { get; set; }
        [Required(ErrorMessage = "Bill No. is Required")]
        [Display(Name = "Bill Number")]
        public int BillNo { get; set; }
        [Required(ErrorMessage = "Manufacture date is Required")]
        [Display(Name = "Manufacture Date")]
        public DateTime ManufactureDate { get; set; }
        [Required(ErrorMessage = "Expiry date is Required")]
        [Display(Name = "Expiry Date")]
        public DateTime ExpiryDate { get; set; }
        [Required(ErrorMessage = "Vendor Address is Required")]
        [Display(Name = "Vendor Address")]
        public String VendorAddress { get; set; }


    }
}
