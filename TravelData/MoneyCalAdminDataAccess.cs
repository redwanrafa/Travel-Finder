using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelData
{
    class MoneyCalAdminDataAccess : IMoneyCalAdminDataAccess
    {
        private TravelContext context;
        public MoneyCalAdminDataAccess(TravelContext context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            MoneyCalAdmin mcal = this.context.MoneyCalAdmins.SingleOrDefault(x => x.MoneyCalAdminId == id);
            this.context.MoneyCalAdmins.Remove(mcal);
            return this.context.SaveChanges();
        }

        public MoneyCalAdmin Get(int id, bool includeTour = false)
        {
            if (includeTour)
            {
                return this.context.MoneyCalAdmins.Include("Tour").SingleOrDefault(x => x.MoneyCalAdminId== id);
            }
            else
            {
                return this.context.MoneyCalAdmins.SingleOrDefault(x => x.MoneyCalAdminId == id);
            }
        }

        public ICollection<MoneyCalAdmin> GetAll(bool includeTour = false)
        {
            if (includeTour)
            {
                return this.context.MoneyCalAdmins.Include("Tour").ToList();
            }
            else
            {
                return this.context.MoneyCalAdmins.ToList();
            }
        }

        public int Insert(MoneyCalAdmin mcal)
        {
            this.context.MoneyCalAdmins.Add(mcal);
            return this.context.SaveChanges();
        }
    }
}
