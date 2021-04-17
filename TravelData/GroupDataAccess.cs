using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelData
{
    class GroupDataAccess : IGroupDataAccess
    {
        private TravelContext context;
        public GroupDataAccess(TravelContext context)
        {
            this.context = context;
        }

        public ICollection<Group> GetAll(bool includeTourist = false)
        {
           if(includeTourist)
            {
                return this.context.Groups.Include("Tourist").ToList();
            }
           else
            {
                return this.context.Groups.ToList();
            }
        }

        public Group Get(int id, bool includeTourist = false)
        {
            if (includeTourist)
            {
                return this.context.Groups.Include("Tourist").SingleOrDefault(x => x.GroupId == id);
            }
            else
            {
                return this.context.Groups.SingleOrDefault(x => x.GroupId == id);
            }
        }
        public ICollection<Group> GetByArea(string area)
        {

            return this.context.Groups.Include("Tourist").Where(x => x.Area.StartsWith(area)).ToList();
        }
        public ICollection<Group> GetTouristId(int id, bool includeTourist = true)
        {

            return this.context.Groups.Include("Tourist").Where(x => x.TouristId == id).ToList();

        }

        public int Delete(int id)
        {
            Group grp = this.context.Groups.SingleOrDefault(x => x.GroupId == id);
            this.context.Groups.Remove(grp);
            return this.context.SaveChanges();
        }
        public int Delete(int? id)
        {
            Group grp = this.context.Groups.SingleOrDefault(x => x.GroupId == id);
            this.context.Groups.Remove(grp);
            return this.context.SaveChanges();
        }


        public int Insert(Group group)
        {
           this.context.Groups.Add(group);
           return  this.context.SaveChanges();
        }

        public int Update(Group group)
        {
            Group grp = this.context.Groups.SingleOrDefault(x => x.GroupId == group.GroupId);
            grp.NoOfMale = group.NoOfMale;
            grp.NoofFemale = group.NoofFemale;
            grp.AgeMin = group.AgeMin;
            grp.AgeMax = group.AgeMax;
            grp.Area = group.Area;
            grp.Date = group.Date;
            return this.context.SaveChanges();
        }

      /*  public bool ValidateCredentials(Group group)
        {
            Group grp = this.context.Groups.SingleOrDefault(x => x.GroupId == group.GroupId);
            if(grp==null)
            {
                return false;
            }
            else
            {
                group.GroupId = grp.GroupId;
                return true;
            }
        }*/

    }
}
