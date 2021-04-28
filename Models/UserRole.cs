using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCourseWork.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Rol")]
        [Display(Name = "Role Id")]
        public int RoleId { get; set; }
        [ForeignKey("User")]
        [Display(Name = "User Id")]
        public int UserId { get; set; }
        public virtual Role Rol { get; set; }
        public virtual User User { get; set; }
    }
}
