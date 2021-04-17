using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEntity;

namespace TravelData
{
    class TouristDataAccess : ITouristDataAccess
    {
        private TravelContext context;
        public TouristDataAccess(TravelContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            Tourist tourist = this.context.Tourists.SingleOrDefault(x => x.TouristId == id);
            this.context.Tourists.Remove(tourist);
            return this.context.SaveChanges();
        }

        public Tourist Get(int id)
        {
            return this.context.Tourists.SingleOrDefault(x => x.TouristId == id);
        }
        public Tourist GetEmail(string e)
        {
            return this.context.Tourists.SingleOrDefault(x => x.TouristEmail == e);
        }
        public Tourist GetUserName(string e)
        {
            return this.context.Tourists.SingleOrDefault(x => x.TouristUserName == e);
        }
        public Tourist GetContact(string e)
        {
            return this.context.Tourists.SingleOrDefault(x => x.TouristContactNo == e);
        }
        public ICollection<Tourist> GetAll()
        {
            return this.context.Tourists.ToList();
        }

        public int Insert(Tourist tourist)
        {
            this.context.Tourists.Add(tourist);
            return this.context.SaveChanges();
        }

        public int Update(Tourist tourist)
        {
            Tourist trst = this.context.Tourists.SingleOrDefault(x => x.TouristId == tourist.TouristId);
            trst.TouristEmail = tourist.TouristEmail;
            trst.TouristAddress = tourist.TouristAddress;
            trst.TouristContactNo = tourist.TouristContactNo;
            trst.TouristPassword = tourist.TouristPassword;
            return this.context.SaveChanges();

        }

        public bool ValidateCredentials(Tourist tourist)
        {
            Tourist usr = this.context.Tourists.SingleOrDefault(x => x.TouristUserName == tourist.TouristUserName && x.TouristPassword == tourist.TouristPassword);
            if (usr == null)
            {
                return false;
            }
            else
            {
                tourist.TouristId = usr.TouristId;
                return true;
            }
        }
    }
}
