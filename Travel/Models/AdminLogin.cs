using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class AdminLogin
    {
        [Required(ErrorMessage = "User Name Required")]
        [Display(Name = "User Name")]
        public string AdminUserName { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }
    }
}