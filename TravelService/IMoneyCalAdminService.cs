using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelService
{
    public interface IMoneyCalAdminService
    {
        ICollection<MoneyCalAdmin> GetAll(bool includeTour = false);
        MoneyCalAdmin Get(int id, bool includeTour = false);
        int Insert(MoneyCalAdmin mcal);
        int Delete(int id);
    }
}
