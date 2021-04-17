using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models;
using TravelEntity;
using TravelService;

namespace Travel.Controllers
{
    public class SeeRequestController : Controller
    {
        // GET: SeeRequest
        public ActionResult Index()
        {
            IGroup_FormedService serviceg = ServiceFactory.GetGroup_FormedService();
            IGroup_RequestService service = ServiceFactory.GetGroup_RequestService();
            Group_Formed groupformed = new Group_Formed();
            Group_Formed groupformed2 = new Group_Formed();
            groupformed = serviceg.GetByTouristId(Convert.ToInt32(Session["TouristId"]));
           
            if (groupformed != null )
            {
                groupformed2 = serviceg.GetByReqId(groupformed.GroupReqId);
                if(groupformed != null && groupformed2 != null)
                {
                    return View("Error");
                }
                return View("Error");
            }
            
            int groupId = Convert.ToInt32(Session["TouristId"]);
            IGroupService groupservice1 = ServiceFactory.GetGroupService();
            Group gp = groupservice1.Get(groupId);
            if (gp==null)
            {
                return View("Error");

            }
            
           
            ICollection<Group_Request> grouprequest = service.GetGroupRequestByGroupID(groupId);
            //List<GroupRequestModel> grouprequestmodel = new List<GroupRequestModel>();
            List<GroupModel> gd = new List<GroupModel>();
            if (grouprequest!= null)
            {
                foreach (var item in grouprequest)
                {
                    int touristid = item.TouristIdEx;
                    IGroupService groupservice = ServiceFactory.GetGroupService();
                    Group g = groupservice.Get(touristid, true);
                    GroupModel gd1 = new GroupModel();
                    gd1.AgeMax = g.AgeMax;
                    gd1.AgeMin = g.AgeMin;
                    gd1.Area = g.Area;
                    gd1.Date = g.Date;
                    gd1.NoofFemale = g.NoofFemale;
                    gd1.NoOfMale = g.NoOfMale;
                    gd1.GroupId = g.GroupId;
                    gd1.TouristId = g.TouristId;
                    gd1.GroupRequestId = item.GroupReqId;
                    gd.Add(gd1);
                }
                ICollection<GroupModel> collection = gd;
                return View(collection);
            }
            return View();
        }
        [HttpGet]
        public ActionResult Details(int id , int reqid)
        {
            IGroupService service = ServiceFactory.GetGroupService();
            Group group = service.Get(id, true);
            GroupModel g = new GroupModel();
            TouristModel tourist = new TouristModel();
            g.NoofFemale = group.NoofFemale;
            g.NoOfMale = group.NoOfMale;
            g.AgeMax = group.AgeMax;
            g.AgeMin = group.AgeMin;
            g.Area = group.Area;
            g.Date = group.Date;
            g.GroupId = id;
            g.TouristId = group.TouristId;
            g.GroupRequestId = reqid;
            ITouristService service1 = ServiceFactory.GetTouristService();
            Tourist t = service1.Get(group.TouristId);
            tourist.TouristContactNo = t.TouristContactNo;
            tourist.TouristEmail = t.TouristEmail;
            tourist.TouristName = t.TouristName;
            tourist.TouristPassword = t.TouristPassword;
            tourist.TouristDOB = t.TouristDOB;
            tourist.TouristGender = t.TouristGender;
            tourist.TouristAddress = t.TouristAddress;
            tourist.TouristUserName = t.TouristUserName;
            tourist.Group = g;

            return View(tourist);

        }
        [HttpPost]
        public ActionResult Details()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id,int reqid)
        {
            IGroup_RequestService service = ServiceFactory.GetGroup_RequestService();
            service.Delete(reqid);
            return View("Success");
        }
        [HttpPost]
        public ActionResult Delete(GroupModel group)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Accept(int id, int reqid)
        {
          
            IGroup_FormedService service = ServiceFactory.GetGroup_FormedService();
            Group_Formed groupformed = new Group_Formed();
            groupformed = service.GetByReqId(reqid);
            if (groupformed != null)
            {
                return View("Error2");
            }
            Group_Formed newgroupformed = new Group_Formed();
            
            newgroupformed.GroupReqId = reqid;
            newgroupformed.TouristIdEx = Convert.ToInt32(Session["TouristId"]);
            service.Insert(newgroupformed);
          /*  IGroup_RequestService service1 = ServiceFactory.GetGroup_RequestService();
            service1.Delete(reqid);
            IGroupService groupservice = ServiceFactory.GetGroupService();
            groupservice.Delete(id);
            groupservice.Delete(Convert.ToInt32(Session["TouristId"]));*/
           
            return View("Success");
        }
           
        [HttpPost]
        public ActionResult Accept(GroupModel group)
        {
            return View();
        }
    }
}