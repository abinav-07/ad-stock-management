using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCourseWork.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Type")]
        public String RoleType { get; set; }
        [Display(Name = "Discription")]
        public String RoleDescription { get; set; }

    }
}
