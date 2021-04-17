using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelEntity
{
   public class Guide
    {
        [Key]
        public int GuideId { get; set; }
        public string GuideName { get; set; }
        public string GuideNID { get; set; }
        public string GuideEmail { get; set; }
        public System.DateTime GuideDOB { get; set; }
        public string GuideAddress { get; set; }
        public string GuideContact { get; set; }
        public string GuideGender { get; set; }
        public string GuideLanguages { get; set; }
        public int NoOfTour { get; set; }
        public string GuideStatus { get; set; }
        public int GuideRating { get; set; }
        public string GuideArea { get; set; }
        public string GuideUserName { get; set; }
        public string GuidePassword { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Tour> Tours { get; set; }
    }
}
