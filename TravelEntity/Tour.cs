using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelEntity
{
    public class Tour
    {

        [Key]
        public int TourId { get; set; }
        public int GuideId { get; set; }
        public Nullable<int> GroupFormedId { get; set; }
        public Nullable<int> GroupId { get; set; }
        public double MoneyCal { get; set; }
        public System.DateTime StartDate { get; set; }
        public int NoOfDays { get; set; }
        public string Area { get; set; }
        public virtual Group Group { get; set; }
        public virtual Group_Formed Group_Formed { get; set; }
        public virtual Guide Guide { get; set; }
        public virtual ICollection<MoneyCalAdmin> MoneyCalAdmins { get; set; }
        public virtual ICollection<MoneyCalGuide> MoneyCalGuides { get; set; }
    }
}
