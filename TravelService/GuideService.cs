using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelData;
using TravelEntity;

namespace TravelService
{
    class GuideService : IGuideService
    {
        private IGuideDataAccess data;

        public GuideService(IGuideDataAccess data)
        {
            this.data = data;
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }
        public ICollection<Guide> GetByArea(string area, string status)
        {
            return this.data.GetByArea(area,  status);
        }

        public Guide Get(int id)
        {
            return this.data.Get(id);
        }
       
        public Guide Get(string email)
        {
            return this.data.Get(email);
        }
        public Guide GetContact(string e)
        {
            return this.data.GetContact(e);
        }
        public Guide GetNID(string e)
        {
            return this.data.GetNID(e);
        }
        public Guide GetUserName(string e)
        {
            return this.data.GetUserName(e);
        }

        public ICollection<Guide> GetAll()
        {
            return this.data.GetAll();
        }

        public int Insert(Guide guide)
        {
            return this.data.Insert(guide);
        }

        public int Update(Guide guide)
        {
            return this.data.Update(guide);
        }

        public bool ValidateCredentials(Guide guide)
        {
            return this.data.ValidateCredentials(guide);
        }
    }
}
