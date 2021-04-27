using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCourseWork.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Enter Password")]
        [MinLength(6, ErrorMessage = "Password should atleast be 6 character.")]
        public string Password { get; set; }

    }
}
