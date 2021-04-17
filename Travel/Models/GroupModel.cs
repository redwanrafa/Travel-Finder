using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.Models
{
    public class GroupModel
    {
        public int GroupId { get; set; }
        [Required(ErrorMessage = "No Of Male Required")]
        [Display(Name = "No Of Male")]
        public int NoOfMale { get; set; }
        [Required(ErrorMessage = "No Of FeMale Required")]
        [Display(Name = "No Of Fe-Male")]
        public int NoofFemale { get; set; }
        [Required(ErrorMessage = "Age Min Required")]
        [Display(Name = "Min Age")]
        public int AgeMin { get; set; }
        [Required(ErrorMessage = "Age Max Required")]
        [Display(Name = "Max Age")]
        public int AgeMax { get; set; }
        [Required(ErrorMessage = "Area Required")]
        [Display(Name = "Area")]
        public string Area { get; set; }
        [Required(ErrorMessage = "Search Required")]
        [Display(Name = "Search")]
        public string search { get; set; }
        public int TouristId { get; set; }
        public int GroupRequestId { get; set; }
        [Required(ErrorMessage = "Date Required")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }
        public string GroupFormed { set; get; }
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