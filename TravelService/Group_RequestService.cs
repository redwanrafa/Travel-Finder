using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelData;
using TravelEntity;

namespace TravelService
{
    class Group_RequestService : IGroup_RequestService
    {
        private IGroup_RequestDataAccess data;

        public Group_RequestService(IGroup_RequestDataAccess data)
        {
            this.data = data;
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }
        public ICollection<Group_Request> GetByTouristId(int id)
        {
            return this.data.GetByTouristId(id);
        }
        public Group_Request Get(int id, bool includeGroup = false)
        {
            return this.data.Get(id, includeGroup);
        }
        public ICollection<Group_Request> GetGroupID(int id, int touristid)
        {
            return this.data.GetGroupID(id, touristid);
        }
        public ICollection<Group_Request> GetByGroupID(int id)
        {
            return this.data.GetByGroupID(id);
        }
        public ICollection<Group_Request> GetByGroupID(int? id)
        {
            return this.data.GetByGroupID(id);
        }
        public ICollection<Group_Request> GetGroupRequestByGroupID(int id, bool includeGroup = false)
        {
            return this.data.GetGroupRequestByGroupID(id, includeGroup);
        }
        public ICollection<Group_Request> GetAll(bool includeGroup = false)
        {
            return this.data.GetAll(includeGroup);
        }

        public int Insert(Group_Request group_req)
        {
            return this.data.Insert(group_req);
        }

        public int Update(Group_Request group_req)
        {
            return this.data.Update(group_req);
        }
    }
}
