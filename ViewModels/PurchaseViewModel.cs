using GroupCourseWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCourseWork.ViewModels
{
    public class PurchaseViewModel
    {
        public Purchase Purchase { get; set; }
        public List<PurchaseDetail> PurchaseDetailList { get; set; }
    }
}
