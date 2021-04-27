﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCourseWork.ViewModels
{
    public class ProductStockViewModel
    {        
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        
    }
}
