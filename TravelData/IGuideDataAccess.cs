using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelData
{
   public interface IGuideDataAccess
    {
        ICollection<Guide> GetAll();
        Guide Get(int id);
        Guide Get(string email);
        Guide GetContact(string contact);
        Guide GetNID(string nid);
        ICollection<Guide> GetByArea(string area, string status);
        Guide GetUserName(string username);
        int Insert(Guide guide);
        int Update(Guide guide);
        int Delete(int id);
        bool ValidateCredentials(Guide guide);
    }
}
