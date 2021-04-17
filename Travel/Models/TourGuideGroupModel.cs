using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class TourGuideGroupModel
    {
        public int TourId { get; set; }
        public int GuideId { get; set; }
        public string GuideName { get; set;}
        public double MoneyCal { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime StartDate { get; set; }
        public int NoOfDays { get; set; }
        public string Area { get; set; }
    }
}