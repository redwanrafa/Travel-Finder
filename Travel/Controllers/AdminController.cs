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
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            IAdminService service = ServiceFactory.GetAdminService();
            Admin a = service.Get(Convert.ToInt32(Session["AdminId"]));
            AdminModel admodel = new AdminModel();
            admodel.AdminName = a.AdminName;
            admodel.AdminUserName = a.AdminUserName;
            admodel.AdminEmail = a.AdminUserName;

            return View(admodel);
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            return View();
        }
        [HttpPost]
         public ActionResult EditProfile(AdminModel ad)
         {
            IAdminService service = ServiceFactory.GetAdminService();
            Admin admin = service.Get(Convert.ToInt32(Session["AdminId"]));
            if (ad.AdminCPassword.Equals(ad.AdminPassword))
            {

                admin.AdminPassword = ad.AdminPassword;
                service.Update(admin);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult ViewTourist()
        {
            ITouristService service = ServiceFactory.GetTouristService();
            return View(service.GetAll());
        }
        public ActionResult ViewGuide()
        {
            IGuideService service = ServiceFactory.GetGuideService();
            return View(service.GetAll());
        }
        public ActionResult ViewTour()
        {
            ITourService service = ServiceFactory.GetTourService();
            ICollection<Tour> tourlist = service.GetAll(true);
            List<TourGuideGroupModel> viewtourlist = new List<TourGuideGroupModel>();
            foreach(Tour tour in tourlist)
            {
                TourGuideGroupModel tourguide = new TourGuideGroupModel()
                {
                    TourId = tour.TourId,
                    GuideId = tour.GuideId,
                    GuideName = tour.Guide.GuideName,
                    MoneyCal = tour.MoneyCal,
                    StartDate = tour.StartDate,
                    NoOfDays = tour.NoOfDays,
                    Area = tour.Area
                };
                viewtourlist.Add(tourguide);
            }
            return View(viewtourlist);

        }

    }
}