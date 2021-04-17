using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelData;
using TravelEntity;

namespace TravelService
{
    class AdminService : IAdminService
    {
        private IAdminDataAccess data;

        public AdminService(IAdminDataAccess data)
        {
            this.data = data;
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }

        public Admin Get(int id)
        {
            return this.data.Get(id);
        }

        public ICollection<Admin> GetAll()
        {
            return this.data.GetAll();
        }

        public Admin GetUserName(string e)
        {
            return this.data.GetUserName(e);
        }

        public int Insert(Admin admin)
        {
            return this.data.Insert(admin);
        }

        public int Update(Admin admin)
        {
            return this.data.Update(admin);
        }

        public bool ValidateCredentials(Admin admin)
        {
            return this.data.ValidateCredentials(admin);
        }
    }
}
