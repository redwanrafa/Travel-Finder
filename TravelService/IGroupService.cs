using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelService
{
   public interface IGroupService
    {
        ICollection<Group> GetByArea(string area);
        ICollection<Group> GetAll(bool includeTourist = false);
        Group Get(int id, bool includeTourist = false);

        ICollection<Group> GetTouristId(int id, bool includeTourist = false);
        int Insert(Group group);
        int Update(Group group);
        int Delete(int id);
        int Delete(int? id);
    }
}
