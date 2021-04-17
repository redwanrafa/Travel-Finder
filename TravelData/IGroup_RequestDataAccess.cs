using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelData
{
    public interface IGroup_RequestDataAccess
    {
        ICollection<Group_Request> GetAll(bool includeGroup = false);
        Group_Request Get(int id, bool includeGroup = false);
        ICollection<Group_Request> GetGroupID(int id, int touristid);
        ICollection<Group_Request> GetGroupRequestByGroupID(int id, bool includeGroup = false);
        ICollection<Group_Request> GetByGroupID(int id);
        ICollection<Group_Request> GetByGroupID(int? id);
        int Insert(Group_Request group_req);
        int Update(Group_Request group_req);
        int Delete(int id);
        ICollection<Group_Request> GetByTouristId(int id);
        //  bool ValidateCredentials(Group_Request group_req);
    }
}
