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
    public class GroupProfileController : Controller
    {
        // GET: GroupProfile
        public ActionResult Index()
        {


            IGroupService service = ServiceFactory.GetGroupService();
            Group group = service.Get(Convert.ToInt32(Session["TouristId"]));
            if(group==null)
            {
                return View("Error");
            }
            GroupModel g = new GroupModel();
            g.NoofFemale = group.NoofFemale;
            g.NoOfMale = group.NoOfMale;
            g.AgeMax = group.AgeMax;
            g.AgeMin = group.AgeMin;
            g.Area = group.Area;
            g.Date = group.Date;
            g.GroupId = group.GroupId;
            IGroup_FormedService serviceformed =ServiceFactory.GetGroup_FormedService();
            Group_Formed gf = serviceformed.GetByTouristId(Convert.ToInt32(Session["TouristId"]));
            if (gf == null)
            {
                IGroup_RequestService servicereq = ServiceFactory.GetGroup_RequestService();
                ICollection<Group_Request> gr = servicereq.GetByTouristId(Convert.ToInt32(Session["TouristId"]));
                if (gr == null) g.GroupFormed = "notformed";
                else
                {
                    foreach (var item in gr)
                    {
                        int i = item.GroupReqId;
                        Group_Formed gf1 = serviceformed.GetByReqId(i);
                        if (gf1 != null)
                        {
                            g.GroupFormed = "formed";

                        }
                        else
                        {
                            g.GroupFormed = "Notformed";
                        }
                    }

                }
              
            }
            else
            {
                g.GroupFormed = "formed";
            }
            return View(g);


        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(GroupModel g)
        {
            if (ModelState.IsValid)
            {
                IGroupService service = ServiceFactory.GetGroupService();
                Group group = service.Get(Convert.ToInt32(Session["TouristId"]));
                if(g.AgeMax>0)
                {
                    group.AgeMax = g.AgeMax;
                }
                if (g.AgeMin>0)
                {
                    group.AgeMin = g.AgeMin;
                }
                if (g.NoofFemale > 0)
                {
                    group.NoofFemale = g.NoofFemale;
                }
                if (g.NoOfMale > 0)
                {
                    group.NoOfMale = g.NoOfMale;
                }
                service.Update(group);

                return RedirectToAction("Index");
                

            }

            return View();

        }

    }
}