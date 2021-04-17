using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelData
{
    class RatingDataAccess : IRatingDataAccess
    {
        private TravelContext context;
        public RatingDataAccess(TravelContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            Rating rating = this.context.Ratings.SingleOrDefault(x => x.RatingId == id);
            this.context.Ratings.Remove(rating);
            return this.context.SaveChanges();
        }

        public Rating Get(int id, bool includeGuide = false)
        {
            if (includeGuide)
            {
                return this.context.Ratings.Include("Guide").SingleOrDefault(x => x.RatingId == id);
            }
            else
            {
                return this.context.Ratings.SingleOrDefault(x => x.RatingId == id);
            }
        }

        public ICollection<Rating> GetAll(bool includeGuide = false)
        {
            if (includeGuide)
            {
                return this.context.Ratings.Include("Guide").ToList();
            }
            else
            {
                return this.context.Ratings.ToList();
            }
        }

        public int Insert(Rating rating)
        {
            this.context.Ratings.Add(rating);
            return this.context.SaveChanges();
        }

        public int Update(Rating rating)
        {
            Rating rt = this.context.Ratings.SingleOrDefault(x => x.RatingId == rating.RatingId);
            rt.GuideId = rating.GuideId;
            rt.NoOfTour = rating.NoOfTour;
            rt.Bonus = rating.Bonus;
            return this.context.SaveChanges();
        }
    }
}
