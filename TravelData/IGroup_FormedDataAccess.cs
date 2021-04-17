using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelData
{
    public interface IGroup_FormedDataAccess
    {
        ICollection<Group_Formed> GetAll(bool includeGroup_Request = false);
        Group_Formed Get(int id, bool includeGroup_Request = false);
        Group_Formed Get(int? id, bool includeGroup_Request = false);
        Group_Formed GetByTouristId(int id);
        Group_Formed GetByReqId(int id);
        int Insert(Group_Formed group_formed);
        int Update(Group_Formed group_formed);
        int Delete(int id);
        //  bool ValidateCredentials(Group_Formed group_formed);
    }
}
