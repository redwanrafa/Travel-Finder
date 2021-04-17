using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelService
{
   public interface IAreaService
    {
        ICollection<Area> GetAll();
        Area Get(int id);
        int Insert(Area area);
        int Update(Area area);
        int Delete(int id);
    }
}
