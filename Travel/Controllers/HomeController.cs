using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelEntity;
using TravelService;
using Travel.Models;
using System.Web.Security;

namespace Travel.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignupGuide()
        {
            GuideModel objModel = new GuideModel();
            objModel.getAreas = objModel.getAllAreaList();
            return View(objModel);

        }

        [HttpPost]
        public ActionResult SignUpGuide(GuideModel g)
        {
            if (ModelState.IsValid)
            {

                IGuideService service = ServiceFactory.GetGuideService();
                Guide guide = new Guide();
                guide.GuideName = g.GuideName;
                guide.GuideNID = g.GuideNID;
                guide.GuideEmail = g.GuideEmail;
                guide.GuideDOB = g.GuideDOB;
                guide.GuideAddress = g.GuideAddress;
                guide.GuideContact = g.GuideContact;
                guide.GuideGender = g.GuideGender;
                guide.GuideLanguages = g.GuideLanguages;
                guide.GuidePassword = g.GuidePassword;
                guide.NoOfTour = 0;
                guide.GuideStatus = "Active";
                guide.GuideRating = 0;
                guide.GuideArea = g.GuideArea;
                guide.GuideUserName = g.GuideUserName;

                if (service.Get(guide.GuideEmail) != null)
                {
                    if (service.GetUserName(guide.GuideUserName) != null)
                    {
                        if (service.GetNID(guide.GuideNID) != null)
                        {
                            if (service.GetContact(guide.GuideContact) != null)
                            {
                                return View("Error");
                            }
                        }
                    }

                }

                service.Insert(guide);
                return View("Success");

            }
            else
            {
                return View();
            }


        }

        [HttpGet]
        public ActionResult SignupTourist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUpTourist(TouristModel t)
        {
            ITouristService service = ServiceFactory.GetTouristService();
            Tourist tourist = new Tourist();
            tourist.TouristContactNo = t.TouristContactNo;
            tourist.TouristEmail = t.TouristEmail;
            tourist.TouristName = t.TouristName;
            tourist.TouristPassword = t.TouristPassword;
            tourist.TouristDOB = t.TouristDOB;
            tourist.TouristGender = t.TouristGender;
            tourist.TouristAddress = t.TouristAddress;
            tourist.TouristUserName = t.TouristUserName;
            if (service.GetEmail(tourist.TouristEmail) != null)
            {
                if (service.GetUserName(tourist.TouristUserName) != null)
                {
                    if (service.GetContact(tourist.TouristContactNo) != null)
                    {

                        return View("Error");

                    }
                }

            }

            service.Insert(tourist);
            return View("Success");

        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AdminLogin(AdminLogin adlog)
        {
            IAdminService service = ServiceFactory.GetAdminService();
            Admin ad = service.GetUserName(adlog.AdminUserName);
            if (ad != null)
            {
                ad.AdminPassword = adlog.AdminPassword;
                if (service.ValidateCredentials(ad))
                {
                    Session["AdminId"] = ad.AdminId;
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View("NotSuccessfull");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            IGuideService service = ServiceFactory.GetGuideService();

            Guide u = service.GetUserName(user.UserUserName);
            ITouristService service1 = ServiceFactory.GetTouristService();
            Tourist u1 = service1.GetUserName(user.UserUserName);
            if (u != null)
            {
                u.GuidePassword = user.UserPassword;
                if (service.ValidateCredentials(u))
                {
                    Session["GuideId"] = u.GuideId;
                    return RedirectToAction("Index", "Guide");
                }
            }

            else if (u1 != null)
            {
                u1.TouristPassword = user.UserPassword;
                if (service1.ValidateCredentials(u1))
                {
                    Session["TouristId"] = u1.TouristId;
                    return RedirectToAction("Index", "Tourist");
                }
            }

            return View("NotSuccessfull");

        }


            public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Home");
        }
    }
}
    
