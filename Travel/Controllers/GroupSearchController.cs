using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models;
using TravelEntity;
using TravelService;

namespace Travel.Controllers
{
    public class GroupSearchController : Controller
    {
        // GET: GroupSearch
       
        public ActionResult Index(string list)
        {

            // preselect item in selectlist by CompanyID param


          
            IGroupService service = ServiceFactory.GetGroupService();
            ICollection<Group> g1 = service.GetByArea(list);
            
            List<GroupModel> gd = new List<GroupModel>();
            if (g1 != null)
            {
                foreach (var item in g1)
                {
                    GroupModel gd1 = new GroupModel();
                    gd1.AgeMax = item.AgeMax;
                    gd1.AgeMin = item.AgeMin;
                    gd1.Area = item.Area;
                    gd1.Date = item.Date;
                    gd1.NoofFemale = item.NoofFemale;
                    gd1.NoOfMale = item.NoOfMale;
                    gd1.GroupId = item.GroupId;
                    Session["GroupId"] = gd1.GroupId;
                    gd.Add(gd1);
                }
                ICollection<GroupModel> collection = gd;
                return View(collection);
            }

           
            return View();
        }
        [HttpGet]
       public ActionResult Details(int id)
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
        public ActionResult SentRequest(int id)
        {
            int groupId = Convert.ToInt32(Session["TouristId"]);
            IGroupService groupservice1 = ServiceFactory.GetGroupService();
            Group gp = groupservice1.Get(groupId);
            if (gp == null)
            {
                return RedirectToAction("GroupRegister","Tourist");

            }
            IGroup_RequestService gr = ServiceFactory.GetGroup_RequestService();
            Group_Request g = new Group_Request();
            if(id== Convert.ToInt32(Session["TouristId"]))
            {
                return View("ErrorGroupRegister");
            }
            if (gr.GetGroupID(id, Convert.ToInt32(Session["TouristId"]) ).Count()<=0)
            {
                g.GroupId = id;
                g.TouristIdEx = Convert.ToInt32(Session["TouristId"]);
                gr.Insert(g);
                return View("Success2");
            }
            return View("ErrorReq");
        }

       


    }
}