using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelData;
using TravelEntity;

namespace TravelService
{
    class MoneyCalGuideService : IMoneyCalGuideService
    {
        private IMoneyCalGuideDataAccess data;

        public MoneyCalGuideService(IMoneyCalGuideDataAccess data)
        {
            this.data = data;
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }

        public MoneyCalGuide Get(int id, bool includeTour = false)
        {
            return this.data.Get(id, includeTour);
        }

        public ICollection<MoneyCalGuide> GetAll(bool includeTour = false)
        {
            return this.data.GetAll(includeTour);
        }

        public int Insert(MoneyCalGuide mcal)
        {
            return this.data.Insert(mcal);
        }
    }
}
