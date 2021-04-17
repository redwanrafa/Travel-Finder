using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelEntity
{
    public class Tourist
    {

        [Key]
        public int TouristId { get; set; }
        public string TouristName { get; set; }
        public string TouristEmail { get; set; }
        public string TouristContactNo { get; set; }
        public string TouristGender { get; set; }
        public System.DateTime TouristDOB { get; set; }
        public string TouristAddress { get; set; }
        public string TouristUserName { get; set; }
        public string TouristPassword { get; set; }
        public  ICollection<Group> Groups { get; set; }
    }
}
