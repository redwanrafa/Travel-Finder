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
    public class GuideController : Controller
    {
        // GET: Guide
        public ActionResult Index()
        {
            IGuideService service = ServiceFactory.GetGuideService();
            Guide g = service.Get(Convert.ToInt32(Session["GuideId"]));
            GuideModel guide = new GuideModel();
            guide.GuideName = g.GuideName;
            guide.GuideNID = g.GuideNID;
            guide.GuideEmail = g.GuideEmail;
            guide.GuideDOB = g.GuideDOB;
            guide.GuideAddress = g.GuideAddress;
            guide.GuideContact = g.GuideContact;
            guide.GuideGender = g.GuideGender;
            guide.GuideLanguages = g.GuideLanguages;
            guide.GuidePassword = g.GuidePassword;
            guide.NoOfTour = g.NoOfTour; ;
            guide.GuideStatus = g.GuideStatus;
            guide.GuideRating = g.GuideRating;
            guide.GuideArea = g.GuideArea;
            guide.GuideUserName = g.GuideUserName;
            guide.GuidePassword = g.GuidePassword;
            return View(guide);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            IGuideService service = ServiceFactory.GetGuideService();
            Guide g = service.Get(Convert.ToInt32(Session["GuideId"]));
            GuideModel guide = new GuideModel();
            guide.GuideName = g.GuideName;
            guide.GuideNID = g.GuideNID;
            guide.GuideEmail = g.GuideEmail;
            guide.GuideDOB = g.GuideDOB;
            guide.GuideAddress = g.GuideAddress;
            guide.GuideContact = g.GuideContact;
            guide.GuideGender = g.GuideGender;
            guide.GuideLanguages = g.GuideLanguages;
            guide.GuidePassword = g.GuidePassword;
            guide.NoOfTour = g.NoOfTour;
            guide.GuideStatus = g.GuideStatus;
            guide.GuideRating = g.GuideRating;
            guide.GuideArea = g.GuideArea;
            guide.GuideUserName = g.GuideUserName;
            guide.GuidePassword = g.GuidePassword;
            return View(guide);

        }
        [HttpPost]
        public ActionResult Edit(GuideModel g)
        {
            IGuideService service = ServiceFactory.GetGuideService();
            Guide guide = service.Get(Convert.ToInt32(Session["GuideId"]));
            Console.WriteLine(g.GuideStatus);
            if (guide != null)
            {
                guide.GuideStatus = g.GuideStatus;
                service.Update(guide);
                return View("SuccesGuide");
            }
            return View("Error");
        }
        [HttpGet]
        public ActionResult TourList(int id)
        {
            ITourService service = ServiceFactory.GetTourService();
            ICollection<Tour> t = service.GetByGuide(Convert.ToInt32(Session["GuideId"]));
            List<TourModel> tourmodel = new List<TourModel>();
            if (t != null)
            {
                foreach (var item in t)
                {
                    Tour t2 = service.Get(item.TourId);
                    TourModel temp = new TourModel();
                    temp.TourId = t2.TourId;
                    temp.NoOfDays = t2.NoOfDays;
                    temp.StartDate = t2.StartDate;
                    temp.MoneyCal = t2.MoneyCal;
                    temp.GroupId = Convert.ToInt32(t2.GroupId);
                    temp.GroupFormedId = Convert.ToInt32(t2.GroupFormedId);
                    tourmodel.Add(temp);
                }
                ICollection<TourModel> collection = tourmodel;
                return View(collection);
            }
            return View();

        }
        public ActionResult Done(int id)
        {
            ITourService service = ServiceFactory.GetTourService();
            IGroup_FormedService groupformedservice = ServiceFactory.GetGroup_FormedService();
            IGroupService group = ServiceFactory.GetGroupService();
            IGroup_RequestService groupreqservice = ServiceFactory.GetGroup_RequestService();
            Tour tour = service.Get(id);
            if (tour != null)
            {
                service.Delete(tour.TourId);
                if (tour.GroupId != null)
                {

                    ICollection<Group_Request> gr = groupreqservice.GetByGroupID(tour.GroupId);

                    foreach (var item in gr)
                    {
                        groupreqservice.Delete(item.GroupReqId);
                    }
                    group.Delete(tour.GroupId);
                }
                else if (tour.GroupFormedId != null)
                {

                    Group_Formed g = groupformedservice.Get(tour.GroupFormedId);
                    groupformedservice.Delete(g.GroupFormedId);
                    groupreqservice.Delete(g.GroupReqId);

                    ICollection<Group_Request> gr = groupreqservice.GetByGroupID(tour.GroupId);

                    foreach (var item in gr)
                    {
                        groupreqservice.Delete(item.GroupReqId);
                    }
                    group.Delete(tour.GroupFormedId);
                }
                //service.Delete(tour.TourId);
                return View("SuccesGuide");
            }
            return View("Error");

        }


    }

}