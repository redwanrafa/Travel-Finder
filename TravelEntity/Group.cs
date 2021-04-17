using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelEntity
{
   public class Group
    {
        [Key]
        public int GroupId { get; set; }
        public int NoOfMale { get; set; }
        public int NoofFemale { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public string Area { get; set; }
        public System.DateTime Date { get; set; }
        public int TouristId { get; set; }
        public  ICollection<Group_Request> Group_Request { get; set; }
        public ICollection<Tour> Tours { get; set; }
        public Tourist Tourist { get; set; }
        

    }
}
