using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelService
{
  public interface IMoneyCalGuideService
    {
        ICollection<MoneyCalGuide> GetAll(bool includeTour = false);
        MoneyCalGuide Get(int id, bool includeTour = false);
        int Insert(MoneyCalGuide mcal);
        int Delete(int id);
    }
}
