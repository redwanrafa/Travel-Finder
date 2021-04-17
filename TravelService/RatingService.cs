using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelData;
using TravelEntity;

namespace TravelService
{
    class RatingService : IRatingService
    {
        private IRatingDataAccess data;

        public RatingService(IRatingDataAccess data)
        {
            this.data = data;
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }

        public Rating Get(int id, bool includeGuide = false)
        {
            return this.data.Get(id, includeGuide);
        }

        public ICollection<Rating> GetAll(bool includeGuide = false)
        {
            return this.data.GetAll(includeGuide);
        }

        public int Insert(Rating rating)
        {
            return this.data.Insert(rating);
        }

        public int Update(Rating rating)
        {
            return this.data.Update(rating);
        }
    }
}
