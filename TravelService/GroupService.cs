using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelData;
using TravelEntity;

namespace TravelService
{
    class GroupService : IGroupService
    {
        private IGroupDataAccess data;

        public GroupService(IGroupDataAccess data)
        {
            this.data = data;
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }
        public int Delete(int? id)
        {
            return this.data.Delete(id);
        }

        public Group Get(int id, bool includeTourist = false)
        {
            return this.data.Get(id, includeTourist);
        }
        public ICollection<Group>  GetTouristId(int id, bool includeTourist = false)
        {
            return this.data.GetTouristId(id,includeTourist);
        }
        
        public ICollection<Group> GetByArea(string area)
        {
            return this.data.GetByArea(area);
        }
        public ICollection<Group> GetAll(bool includeTourist = false)
        {
            return this.data.GetAll(includeTourist);
        }

        public int Insert(Group group)
        {
            return this.data.Insert(group);
        }

        public int Update(Group group)
        {
            return this.data.Update(group);
        }
    }
}
