using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelService
{
    public interface IGroup_FormedService
    {
        ICollection<Group_Formed> GetAll(bool includeGroup_Request = false);
        Group_Formed Get(int id, bool includeGroup_Request = false);
        Group_Formed Get(int? id, bool includeGroup_Request = false);
        Group_Formed GetByReqId(int id);
        Group_Formed GetByTouristId(int id);
        int Insert(Group_Formed group_formed);
        int Update(Group_Formed group_formed);
        int Delete(int id);

    }
}
