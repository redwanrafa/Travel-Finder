using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelService
{
  public interface IGuideService
    {
        ICollection<Guide> GetAll();
        Guide Get(int id);
        Guide Get(string email);
        Guide GetContact(string e);
        Guide GetNID(string e);
        Guide GetUserName(string e);
        int Insert(Guide guide);
        int Update(Guide guide);
        ICollection<Guide> GetByArea(string area, string status);
        int Delete(int id);
        bool ValidateCredentials(Guide guide);
    }
}
