using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class TouristModel
    {
        public int TouristId { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [Display(Name = "Name")]
        public string TouristName { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(254)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string TouristEmail { get; set; }
        [Required(ErrorMessage = "Contact Required")]
        [Display(Name = "Contact No")]
        public string TouristContactNo { get; set; }
        [Required(ErrorMessage = "Gender Required")]
        [Display(Name = "Gender")]
        public string TouristGender { get; set; }
        [Required(ErrorMessage = "Date of Birth Required")]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public System.DateTime TouristDOB { get; set; }
        [Required(ErrorMessage = "Address Required")]
        [Display(Name = "Address")]
        public string TouristAddress { get; set; }
        [Required(ErrorMessage = "User name Required")]
        [Display(Name = "User Name")]
        public string TouristUserName { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string TouristPassword { get; set; }
        [Required(ErrorMessage = "Confirm Password Required")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("TouristPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string TouristCPassword { get; set; }
        public GroupModel Group { get; set; }
        // public ICollection<Group> Groups { get; set; }
    }
}