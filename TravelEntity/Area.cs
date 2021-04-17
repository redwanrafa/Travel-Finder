using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TravelEntity
{
   public class Area
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public double MoneyCal { get; set; }
    }
}
