using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.Models
{
    public class GuideModel
    {
        public int GuideId { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [Display(Name = "Name")]
        public string GuideName { get; set; }
        [Required(ErrorMessage = "NID Required")]
        [Display(Name = "National ID")]
        public string GuideNID { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(254)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string GuideEmail { get; set; }
        [Required(ErrorMessage = "Date of Birth Required")]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public System.DateTime GuideDOB { get; set; }
        [Required(ErrorMessage = "Address Required")]
        [Display(Name = "Address")]
        public string GuideAddress { get; set; }
        [Required(ErrorMessage = "Contact Required")]
        [Display(Name = "Contact No")]
        public string GuideContact { get; set; }
        [Required(ErrorMessage = "Gender Required")]
        [Display(Name = "Gender")]
        public string GuideGender { get; set; }
        [Required(ErrorMessage = "Language Required")]
        [Display(Name = "Known Languages")]
        public string GuideLanguages { get; set; }
        public int NoOfTour { get; set; }
        public string GuideStatus { get; set; }
        public int GuideRating { get; set; }
        [Required(ErrorMessage = "Area Required")]
        [Display(Name = "Preferable Area")]
        public string GuideArea { get; set; }
        [Required(ErrorMessage = "User name Required")]
        [Display(Name = "User Name")]
        public string GuideUserName { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string GuidePassword { get; set; }
        [Required(ErrorMessage = "Confirm Password Required")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("GuidePassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string GuideCPassword { get; set; }
      
        public List<SelectListItem> getAreas { get; set; }
        public List<SelectListItem> getAllAreaList()
        {
            List<SelectListItem> myList = new List<SelectListItem>();
            var data = new[]{
                 new SelectListItem{ Value="CoxsBazar",Text="CoxsBazar"},
                 new SelectListItem{ Value="Sajek",Text="Sajek"},
                 new SelectListItem{ Value="Gazipur",Text="Gazipur"},
                 new SelectListItem{ Value="BogaLake",Text="Bokalake"},
                 new SelectListItem{ Value="Khagrachori",Text="Khagrachori"},
                 new SelectListItem{ Value="Srimongol",Text="Srimongol"},
                
             };
            myList = data.ToList();
            return myList;
        }
    }
}