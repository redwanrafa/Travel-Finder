using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class TourModel
    {

        public int TourId { get; set; }
        public int? GuideId { get; set; }
        public int GroupFormedId { get; set; }
        public int? GroupId { get; set; }
        public double MoneyCal { get; set; }
        [Required(ErrorMessage = "Date Required")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public System.DateTime StartDate { get; set; }
        [Required(ErrorMessage = "No Of Days Required")]
        [Display(Name = "No Of Days")]
        public int NoOfDays { get; set; }
        [Required(ErrorMessage = "Area Required")]
        [Display(Name = "Area")]
        public string Area { get; set; }

    }
}