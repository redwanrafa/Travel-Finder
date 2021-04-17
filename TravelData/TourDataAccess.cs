using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelData
{

    class TourDataAccess : ITourDataAccess
    {
        private TravelContext context;
        public TourDataAccess(TravelContext context)
        {
            this.context = context;
            ICollection<Tour> tour = GetAll();
            if (tour != null)
            {
                foreach (var item in tour)
                {
                    if (item.StartDate.AddDays(item.NoOfDays) < DateTime.Now)
                    {
                        Delete(item.TourId);
                    }
                }

            }

        }

        public int Delete(int id)
        {
            Tour tour = this.context.Tours.SingleOrDefault(x => x.TourId == id);
            this.context.Tours.Remove(tour);
            return this.context.SaveChanges();
        }

        public Tour Get(int id, bool includeGuide = false, bool includeGroup_Formed = false, bool includeGroup = false)
        {
            if (includeGuide)
            {
                return this.context.Tours.Include("Guide").SingleOrDefault(x => x.TourId == id);
            }
            else if (includeGroup_Formed)
            {
                return this.context.Tours.Include("Group_Formed").SingleOrDefault(x => x.TourId == id);
            }
            else if (includeGroup)
            {
                return this.context.Tours.Include("Group").SingleOrDefault(x => x.TourId == id);
            }

            else
            {
                return this.context.Tours.SingleOrDefault(x => x.TourId == id);
            }
        }
        public ICollection<Tour> GetByGuide(int id)
        {

            return this.context.Tours.Where(x => x.GuideId == id).ToList();

        }
        public Tour GetByGuideandGroup(int id, int? id2)
        {

            return this.context.Tours.SingleOrDefault(x => x.GuideId == id && x.GroupId == id2);

        }
        public Tour GetByGuideandGroupFormed(int id, int? id2)
        {

            return this.context.Tours.SingleOrDefault(x => x.GuideId == id && x.GroupFormedId == id2);

        }
        public Tour GetByGroup(int id)
        {

            return this.context.Tours.SingleOrDefault(x => x.GroupId == id);

        }
        public Tour GetByGroupFormed(int id)
        {

            return this.context.Tours.SingleOrDefault(x => x.GroupFormedId == id);

        }

        public ICollection<Tour> GetAll(bool includeGuide = false, bool includeGroup_Formed = false, bool includeGroup = false)
        {

            if (includeGuide)
            {
                return this.context.Tours.Include("Guide").ToList();
            }
            else if (includeGroup_Formed)
            {
                return this.context.Tours.Include("Group_Formed").ToList();
            }
            else if (includeGroup)
            {
                return this.context.Tours.Include("Group").ToList();
            }

            else
            {
                return this.context.Tours.ToList();
            }


        }

        public int Insert(Tour tour)
        {

            this.context.Tours.Add(tour);
            return this.context.SaveChanges();



        }

        public int Update(Tour tour)
        {
            Tour tr = this.context.Tours.SingleOrDefault(x => x.TourId == tour.TourId);
            // tr.GuideId = tour.GuideId;
            tr.GroupFormedId = tour.GroupFormedId;
            tr.GroupId = tour.GroupId;
            tr.MoneyCal = tour.MoneyCal;
            tr.StartDate = tour.StartDate;
            tr.NoOfDays = tr.NoOfDays;
            tr.Area = tr.Area;
            return this.context.SaveChanges();

        }
    }


}
