using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelData
{
    class Group_RequestDataAccess : IGroup_RequestDataAccess
    {
        private TravelContext context;
        public Group_RequestDataAccess(TravelContext context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            Group_Request grp = this.context.Group_Request.SingleOrDefault(x => x.GroupReqId == id);
            this.context.Group_Request.Remove(grp);
            return this.context.SaveChanges();
        }


        public Group_Request Get(int id, bool includeGroup = false)
        {
            if (includeGroup)
            {
                return this.context.Group_Request.Include("Group").SingleOrDefault(x => x.GroupReqId == id);
            }

            else
            {
                return this.context.Group_Request.SingleOrDefault(x => x.GroupReqId == id);
            }
        }
        public Group_Request Get(int? id, bool includeGroup = false)
        {
            if (includeGroup)
            {
                return this.context.Group_Request.Include("Group").SingleOrDefault(x => x.GroupReqId == id);
            }

            else
            {
                return this.context.Group_Request.SingleOrDefault(x => x.GroupReqId == id);
            }
        }
        public ICollection<Group_Request> GetByTouristId(int id)
        {

            return this.context.Group_Request.Include("Group").Where(x => x.TouristIdEx == id).ToList();

        }

        public ICollection<Group_Request> GetGroupID(int id, int touristid)
        {

            return this.context.Group_Request.Include("Group").Where(x => x.GroupId == id && x.TouristIdEx == touristid).ToList();




        }
        public ICollection<Group_Request> GetByGroupID(int id)
        {

            return this.context.Group_Request.Include("Group").Where(x => x.GroupId == id).ToList();




        }
        public ICollection<Group_Request> GetByGroupID(int? id)
        {

            return this.context.Group_Request.Include("Group").Where(x => x.GroupId == id).ToList();




        }
        public ICollection<Group_Request> GetGroupRequestByGroupID(int id, bool includeGroup = false)
        {
            if (includeGroup)
            {
                return this.context.Group_Request.Include("Group").Where(x => x.GroupId == id).ToList();
            }

            else
            {
                return this.context.Group_Request.Where(x => x.GroupId == id).ToList();
            }
        }

        public ICollection<Group_Request> GetAll(bool includeGroup = false)
        {
            if (includeGroup)
            {
                return this.context.Group_Request.Include("Group").ToList();
            }

            else
            {
                return this.context.Group_Request.ToList();
            }
        }

        public int Insert(Group_Request group_req)
        {
            this.context.Group_Request.Add(group_req);
            return this.context.SaveChanges();
        }

        public int Update(Group_Request group_req)
        {
            Group_Request grp = this.context.Group_Request.SingleOrDefault(x => x.GroupReqId == group_req.GroupReqId);
            grp.GroupId = grp.GroupId;
            grp.TouristIdEx = group_req.TouristIdEx;
            return this.context.SaveChanges();
        }

        /* public bool ValidateCredentials(Group_Request group_req)
         {
             Group_Request grp = this.context.Group_Request.SingleOrDefault(x => x.GroupReqId == group_req.GroupReqId);
             if (grp == null)
             {
                 return false;
             }
             else
             {
                 group_req.GroupReqId = grp.GroupReqId;
                 return true;
             }
         }*/
    }
}
