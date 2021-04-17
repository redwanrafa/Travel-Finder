using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelData;
using TravelEntity;

namespace TravelService
{
    class TourService : ITourService
    {
        private ITourDataAccess data;

        public TourService(ITourDataAccess data)
        {
            this.data = data;
        }
        public Tour GetByGuideandGroup(int id, int? id2)
        {
            return this.data.GetByGuideandGroup(id, id2);
        }
        public Tour GetByGuideandGroupFormed(int id, int? id2)
        {
            return this.data.GetByGuideandGroupFormed(id, id2);
        }
        public ICollection<Tour> GetByGuide(int id)
        {
            return this.data.GetByGuide(id);
        }
        public Tour GetByGroup(int id)
        {
            return this.data.GetByGroup(id);
        }

        public Tour GetByGroupFormed(int id)
        {
            return this.data.GetByGroupFormed(id);

        }
        public int Delete(int id)
        {
            return this.data.Delete(id);
        }

        public Tour Get(int id, bool includeGuide = false, bool includeGroup_Formed = false, bool includeGroup = false)
        {
            return this.data.Get(id, includeGuide, includeGroup_Formed, includeGroup);
        }

        public ICollection<Tour> GetAll(bool includeGuide = false, bool includeGroup_Formed = false, bool includeGroup = false)
        {
            return this.data.GetAll(includeGuide, includeGroup_Formed, includeGroup);
        }

        public int Insert(Tour tour)
        {
            return this.data.Insert(tour);
        }

        public int Update(Tour tour)
        {
            return this.data.Update(tour);
        }
    }
}
