using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class AdminModel
    {
        public int AdminId { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [Display(Name = "Name")]
        public string AdminName { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [StringLength(254)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string AdminEmail { get; set; }
        [Required(ErrorMessage = "User Name Required")]
        [Display(Name = "User Name")]
        public string AdminUserName { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }
        [Required(ErrorMessage = "Confirm Password Required")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("AdminPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string AdminCPassword { get; set; }
    }
}