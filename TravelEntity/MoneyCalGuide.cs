using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelEntity
{
   public class MoneyCalGuide
    {
        [Key]
        public int MoneyCalGuideId { get; set; }
        public int TourId { get; set; }
        public double Calculation { get; set; }
        public Tour Tour { get; set; }
    }
}
