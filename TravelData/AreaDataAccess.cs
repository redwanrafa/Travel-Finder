using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelData
{
    class AreaDataAccess:IAreaDataAccess
    {
        private TravelContext context;
        public AreaDataAccess(TravelContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            Area area = this.context.Areas.SingleOrDefault(x => x.AreaId == id);
            this.context.Areas.Remove(area);
            return this.context.SaveChanges();
        }

        public Area Get(int id)
        {
            return this.context.Areas.SingleOrDefault(x => x.AreaId == id);
        }

        public ICollection<Area> GetAll()
        {
            return this.context.Areas.ToList();
        }

        public int Insert(Area area)
        {
            this.context.Areas.Add(area);
            return this.context.SaveChanges();
        }

        public int Update(Area area)
        {
            Area ar = this.context.Areas.SingleOrDefault(x => x.AreaId == area.AreaId);
            ar.AreaName = area.AreaName;
            ar.MoneyCal = area.MoneyCal;
            return this.context.SaveChanges();

        }
    }
}
