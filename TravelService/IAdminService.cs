using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelService
{
  public interface IAdminService
    {
        ICollection<Admin> GetAll();
        Admin Get(int id);
        Admin GetUserName(string e);
        int Insert(Admin admin);
        int Update(Admin admin);
        int Delete(int id);
        bool ValidateCredentials(Admin admin);
    }
}
