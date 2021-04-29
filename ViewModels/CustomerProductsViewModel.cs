using GroupCourseWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCourseWork.ViewModels
{
    public class CustomerProductsViewModel
    {
        public string ProductName { get; set; }
        
        public int Quantity { get; set; }
        public DateTime SalesDate { get; set; }
        public int Price { get; set; }

    }
}
