using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelData
{
   public abstract class DataAccessFactory
    {
        public static IAdminDataAccess GetAdminDataAccess()
        {
            return new AdminDataAccess(new TravelContext());
        }
        public static IAreaDataAccess GetAreaDataAccess()
        {
            return new AreaDataAccess(new TravelContext());
        }
        public static IGroupDataAccess GetGroupDataAccess()
        {
            return new GroupDataAccess(new TravelContext());
        }
        public static IGroup_FormedDataAccess GetGroup_FormedDataAccess()
        {
            return new Group_FormedDataAccess(new TravelContext());
        }
        public static IGroup_RequestDataAccess GetGroup_RequestDataAccess()
        {
            return new Group_RequestDataAccess(new TravelContext());
        }
        public static IGuideDataAccess GetGuideDataAccess()
        {
            return new GuideDataAccess(new TravelContext());
        }
        public static IMoneyCalAdminDataAccess GetMoneyCalAdminDataAccess()
        {
            return new MoneyCalAdminDataAccess(new TravelContext());
        }
        public static IMoneyCalGuideDataAccess GetMoneyCalGuideDataAccess()
        {
            return new MoneyCalGuideDataAccess(new TravelContext());
        }
        public static IRatingDataAccess GetRatingDataAccess()
        {
            return new RatingDataAccess(new TravelContext());
        }
        public static ITourDataAccess GetTourDataAccess()
        {
            return new TourDataAccess(new TravelContext());
        }
        public static ITouristDataAccess GetTouristDataAccess()
        {
            return new TouristDataAccess(new TravelContext());
        }
    }
}
