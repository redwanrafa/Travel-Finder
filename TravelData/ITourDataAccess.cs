using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelData
{
    public interface ITourDataAccess
    {

        ICollection<Tour> GetAll(bool includeGuide = false, bool includeGroup_Formed = false, bool includeGroup = false);
        Tour Get(int id, bool includeGuide = false, bool includeGroup_Formed = false, bool includeGroup = false);
        int Insert(Tour tour);
        int Update(Tour tour);
        ICollection<Tour> GetByGuide(int id);
        Tour GetByGroup(int id);
        Tour GetByGroupFormed(int id);
        Tour GetByGuideandGroup(int id, int? id2);
        Tour GetByGuideandGroupFormed(int id, int? id2);
        int Delete(int id);
    }
}

