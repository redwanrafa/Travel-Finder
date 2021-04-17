using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelData;

namespace TravelService
{
    public abstract class ServiceFactory
    { 
        public static IAdminService GetAdminService()
        {
            return new AdminService(DataAccessFactory.GetAdminDataAccess());
        }
        public static IAreaService GetAreaService()
    {
        return new AreaService(DataAccessFactory.GetAreaDataAccess());
    } 
    
        public static IGroupService GetGroupService()
        {
            return new GroupService(DataAccessFactory.GetGroupDataAccess());
        }
        public static IGroup_FormedService GetGroup_FormedService()
        {
            return new Group_FormedService(DataAccessFactory.GetGroup_FormedDataAccess());
        }
        public static IGroup_RequestService GetGroup_RequestService()
        {
            return new Group_RequestService(DataAccessFactory.GetGroup_RequestDataAccess());
        }
        public static IGuideService GetGuideService()
        {
            return new GuideService(DataAccessFactory.GetGuideDataAccess());
        }
        public static IMoneyCalAdminService GetMoneyCalAdminService()
        {
            return new MoneyCalAdminService(DataAccessFactory.GetMoneyCalAdminDataAccess());
        }
        public static IMoneyCalGuideService GetMoneyCalGuideService()
        {
            return new MoneyCalGuideService(DataAccessFactory.GetMoneyCalGuideDataAccess());
        }
        public static IRatingService GetRatingService()
        {
            return new RatingService(DataAccessFactory.GetRatingDataAccess());
        }
        public static ITourService GetTourService()
        {
            return new TourService(DataAccessFactory.GetTourDataAccess());
        }
        public static ITouristService GetTouristService()
        {
            return new TouristService(DataAccessFactory.GetTouristDataAccess());
        }

    }
}
