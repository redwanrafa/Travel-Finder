using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelData
{
    class Group_FormedDataAccess : IGroup_FormedDataAccess
    {
        private TravelContext context;
        public Group_FormedDataAccess(TravelContext context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            Group_Formed grp = this.context.Group_Formed.SingleOrDefault(x => x.GroupFormedId == id);
            this.context.Group_Formed.Remove(grp);
            return this.context.SaveChanges();
        }

        public Group_Formed Get(int id, bool includeGroup_Request = false)
        {
            if (includeGroup_Request)
            {
                return this.context.Group_Formed.Include("Group_Request").SingleOrDefault(x => x.GroupFormedId == id);
            }
            else
            {
                return this.context.Group_Formed.SingleOrDefault(x => x.GroupFormedId == id);
            }
        }
        public Group_Formed Get(int? id, bool includeGroup_Request = false)
        {
            if (includeGroup_Request)
            {
                return this.context.Group_Formed.Include("Group_Request").SingleOrDefault(x => x.GroupFormedId == id);
            }
            else
            {
                return this.context.Group_Formed.SingleOrDefault(x => x.GroupFormedId == id);
            }
        }

        public Group_Formed GetByReqId(int id)
        {

            return this.context.Group_Formed.Include("Group_Request").SingleOrDefault(x => x.GroupReqId == id);

        }
        public Group_Formed GetByTouristId(int id)
        {

            return this.context.Group_Formed.Include("Group_Request").SingleOrDefault(x => x.TouristIdEx == id);

        }


        public ICollection<Group_Formed> GetAll(bool includeGroup_Request = false)
        {
            if (includeGroup_Request)
            {
                return this.context.Group_Formed.Include("Group_Request").ToList();
            }
            else
            {
                return this.context.Group_Formed.ToList();
            }
        }

        public int Insert(Group_Formed group_formed)
        {
            this.context.Group_Formed.Add(group_formed);
            return this.context.SaveChanges();
        }

        public int Update(Group_Formed group_formed)
        {
            Group_Formed grp = this.context.Group_Formed.SingleOrDefault(x => x.GroupFormedId == group_formed.GroupFormedId);
            grp.GroupReqId = group_formed.GroupReqId;
            grp.TouristIdEx = group_formed.TouristIdEx;
            return this.context.SaveChanges();

        }

        /*  public bool ValidateCredentials(Group_Formed group_formed)
          {
              Group_Formed grp = this.context.Group_Formed.SingleOrDefault(x => x.GroupFormedId == group_formed.GroupFormedId);
              if(grp==null)
              {
                  return false;
              }
              else
              {
                  group_formed.GroupFormedId = grp.GroupFormedId;
                  return true;
              }
          }*/
    }
}
