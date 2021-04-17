using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelData;
using TravelEntity;

namespace TravelService
{
    class AreaService:IAreaService
    {
        private IAreaDataAccess data;

        public AreaService(IAreaDataAccess data)
        {
            this.data = data;
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }

        public Area Get(int id)
        {
            return this.data.Get(id);
        }

        public ICollection<Area> GetAll()
        {
            return this.data.GetAll();
        }

        public int Insert(Area area)
        {
            return this.data.Insert(area);
        }

        public int Update(Area area)
        {
            return this.data.Update(area);
        }
    }
}
