using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelData
{
    class MoneyCalGuideDataAccess : IMoneyCalGuideDataAccess
    {
        private TravelContext context;
        public MoneyCalGuideDataAccess(TravelContext context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            MoneyCalGuide mcal = this.context.MoneyCalGuides.SingleOrDefault(x => x.MoneyCalGuideId == id);
            this.context.MoneyCalGuides.Remove(mcal);
            return this.context.SaveChanges();
        }

        public MoneyCalGuide Get(int id, bool includeTour = false)
        {
            if (includeTour)
            {
                return this.context.MoneyCalGuides.Include("Tour").SingleOrDefault(x => x.MoneyCalGuideId == id);
            }
            else
            {
                return this.context.MoneyCalGuides.SingleOrDefault(x => x.MoneyCalGuideId == id);
            }
        }

        public ICollection<MoneyCalGuide> GetAll(bool includeTour = false)
        {
            if (includeTour)
            {
                return this.context.MoneyCalGuides.Include("Tour").ToList();
            }
            else
            {
                return this.context.MoneyCalGuides.ToList();
            }
        }

        public int Insert(MoneyCalGuide mcal)
        {
            this.context.MoneyCalGuides.Add(mcal);
            return this.context.SaveChanges();
        }
    }
}
