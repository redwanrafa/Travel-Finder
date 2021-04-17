using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelEntity
{
   public class Group_Formed
    {
        
        [Key]
        public int GroupFormedId { get; set; }
        public int GroupReqId { get; set; }
        public int TouristIdEx { get; set; }
        public  Group_Request Group_Request { get; set; }
        public  ICollection<Tour> Tours { get; set; }
        
    }
}
