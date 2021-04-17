using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelData;
using TravelEntity;

namespace TravelService
{
    class MoneyCalAdminService : IMoneyCalAdminService
    {
        private IMoneyCalAdminDataAccess data;

        public MoneyCalAdminService(IMoneyCalAdminDataAccess data)
        {
            this.data = data;
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }

        public MoneyCalAdmin Get(int id, bool includeTour = false)
        {
            return this.data.Get(id, includeTour);
        }

        public ICollection<MoneyCalAdmin> GetAll(bool includeTour = false)
        {
            return this.data.GetAll(includeTour);
        }

        public int Insert(MoneyCalAdmin mcal)
        {
            return this.data.Insert(mcal);
        }
    }
}
