using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelData
{
    class AdminDataAccess : IAdminDataAccess
    {
        private TravelContext context;
        public AdminDataAccess(TravelContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            Admin admin = this.context.Admins.SingleOrDefault(x => x.AdminId == id);
            this.context.Admins.Remove(admin);
            return this.context.SaveChanges();
        }

        public Admin Get(int id)
        {
            return this.context.Admins.SingleOrDefault(x => x.AdminId == id);
        }
        public Admin GetUserName(string e)
        {
            return this.context.Admins.SingleOrDefault(x => x.AdminUserName == e);
        }

        public ICollection<Admin> GetAll()
        {
            return this.context.Admins.ToList();
        }

        public int Insert(Admin admin)
        {
            this.context.Admins.Add(admin);
            return this.context.SaveChanges();
        }

        public int Update(Admin admin)
        {
            Admin ad = this.context.Admins.SingleOrDefault(x => x.AdminId == admin.AdminId);
            ad.AdminPassword = admin.AdminPassword;
            return this.context.SaveChanges();
        }

        public bool ValidateCredentials(Admin admin)
        {
            Admin usr = this.context.Admins.SingleOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            if (usr == null)
            {
                return false;
            }
            else
            {
                admin.AdminId = usr.AdminId;
                return true;
            }
        }
    }
}
