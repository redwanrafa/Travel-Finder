using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "User Name Required")]
        [Display(Name = "User Name")]
        public string UserUserName { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}