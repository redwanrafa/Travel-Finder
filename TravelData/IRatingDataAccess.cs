using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelData
{
   public interface IRatingDataAccess
    {
        ICollection<Rating> GetAll(bool includeGuide = false);
        Rating Get(int id, bool includeGuide = false);
        int Insert(Rating rating);
        int Update(Rating rating);
        int Delete(int id);
    }
}
