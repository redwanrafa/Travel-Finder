using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelData;
using TravelEntity;

namespace TravelService
{
    class Group_FormedService : IGroup_FormedService
    {
        private IGroup_FormedDataAccess data;

        public Group_FormedService(IGroup_FormedDataAccess data)
        {
            this.data = data;
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }

        public Group_Formed Get(int id, bool includeGroup_Request = false)
        {
            return this.data.Get(id, includeGroup_Request);
        }
        public Group_Formed Get(int? id, bool includeGroup_Request = false)
        {
            return this.data.Get(id, includeGroup_Request);
        }
        public Group_Formed GetByReqId(int id)
        {
            return this.data.GetByReqId(id);
        }
        public Group_Formed GetByTouristId(int id)
        {
            return this.data.GetByTouristId(id);
        }
        public ICollection<Group_Formed> GetAll(bool includeGroup_Request = false)
        {
            return this.data.GetAll(includeGroup_Request);
        }

        public int Insert(Group_Formed group_formed)
        {
            return this.data.Insert(group_formed);
        }

        public int Update(Group_Formed group_formed)
        {
            return this.data.Update(group_formed);
        }
    }
}
