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
    public class TouristController : Controller
    {
        // GET: Tourist
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ProfileDetails()
        {
            ITouristService service = ServiceFactory.GetTouristService();
            Tourist t = service.Get(Convert.ToInt32(Session["TouristId"]));
            TouristModel tourist = new TouristModel();
            tourist.TouristId = t.TouristId;
            tourist.TouristContactNo = t.TouristContactNo;
            tourist.TouristEmail = t.TouristEmail;
            tourist.TouristName = t.TouristName;
            tourist.TouristPassword = t.TouristPassword;
            tourist.TouristDOB = t.TouristDOB;
            tourist.TouristGender = t.TouristGender;
            tourist.TouristAddress = t.TouristAddress;
            tourist.TouristUserName = t.TouristUserName;
            return View(tourist);



        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(TouristModel t)
        {
           
                ITouristService service = ServiceFactory.GetTouristService();
                Tourist tourist = service.Get(Convert.ToInt32(Session["TouristId"]));
                if (t.TouristCPassword.Equals(t.TouristPassword))
                {

                    tourist.TouristPassword = t.TouristPassword;
                    service.Update(tourist);
                    return RedirectToAction("ProfileDetails");
                }
                else
                {
                    return View("ErrorPass");
                }

            

           

        }
        [HttpGet]
        public ActionResult GroupRegister()
        {
            GroupModel objModel = new GroupModel();
            objModel.getAreas = objModel.getAllAreaList();
            return View(objModel);
            
        }
        [HttpPost]
        public ActionResult GroupRegister(GroupModel group)
        {
            IGroupService service = ServiceFactory.GetGroupService();
            Group g = new Group();



            g.TouristId = Convert.ToInt32(Session["TouristId"]);
            if (service.GetTouristId(g.TouristId, true).Count > 0)
            {
                return View("Error");
            }
            g.NoofFemale = group.NoofFemale;
            g.NoOfMale = group.NoOfMale;
            g.AgeMax = group.AgeMax;
            g.AgeMin = group.AgeMin;
            g.Area = group.Area;
            g.Date = group.Date;
            g.GroupId = Convert.ToInt32(Session["TouristId"]);
            service.Insert(g);

            return RedirectToAction("Index");


        }
    }
       


    
}