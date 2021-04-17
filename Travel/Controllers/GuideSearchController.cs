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
    public class GuideSearchController : Controller
    {
        // GET: GuideSearch
        public ActionResult Index(string list)
        {

            IGuideService service = ServiceFactory.GetGuideService();
            ICollection<Guide> g = service.GetByArea(list, "Active");
            List<GuideModel> gd = new List<GuideModel>();
            if (g != null)
            {
                foreach (var item in g)
                {
                    GuideModel guide = new GuideModel();
                    guide.GuideName = item.GuideName;
                    guide.GuideNID = item.GuideNID;
                    guide.GuideEmail = item.GuideEmail;
                    guide.GuideDOB = item.GuideDOB;
                    guide.GuideAddress = item.GuideAddress;
                    guide.GuideContact = item.GuideContact;
                    guide.GuideGender = item.GuideGender;
                    guide.GuideLanguages = item.GuideLanguages;
                    guide.GuidePassword = item.GuidePassword;
                    guide.NoOfTour = item.NoOfTour;
                    guide.GuideStatus = item.GuideStatus;
                    guide.GuideRating = item.GuideRating;
                    guide.GuideArea = item.GuideArea;
                    guide.GuideUserName = item.GuideUserName;
                    guide.GuidePassword = item.GuidePassword;
                    guide.GuideId = item.GuideId;
                    gd.Add(guide);
                }
                ICollection<GuideModel> collection = gd;
                return View(collection);
            }



            return View();
        }


        [HttpGet]
        public ActionResult Hire(int id)

        {
            /* ITourService service = ServiceFactory.GetTourService();
             Tour t = new Tour();
             t.GuideId = id;*/
            Session["HiredGuideId"] = id;
            /*t.NoOfDays = 0;
            t.StartDate = DateTime.Now;
            t.MoneyCal = 0;
            service.Insert(t);*/

            return View();
        }
        [HttpPost]
        public ActionResult Hire(TourModel tour)
        {
            ITourService service = ServiceFactory.GetTourService(); // form theke noofdays r start date nichi

            Tour t = new Tour();
            t.NoOfDays = tour.NoOfDays;
            t.StartDate = tour.StartDate;

            //t.GroupId = 1;
            t.GuideId = Convert.ToInt32(Session["HiredGuideId"]);
            /* t.Area = "Sajek";*/





            IGroupService serviceg = ServiceFactory.GetGroupService(); // group registered naki check kortesi
            Group group = serviceg.Get(Convert.ToInt32(Session["TouristId"]));
            if (group == null)
            {
                return View("Error");
            }
            Tour temptour1 = service.GetByGroup(group.GroupId); // group already tour ache naki dekhtesi
            if (temptour1 != null)
            {
                return View("Error");
            }
            else
            {
                IGuideService servicegu = ServiceFactory.GetGuideService();
                Guide guide = servicegu.Get(Convert.ToInt32(Session["HiredGuideId"])); // guide ene status update kortesi

                if (guide != null)
                {
                    guide.GuideStatus = "Busy";
                    t.Area = guide.GuideArea;
                    guide.NoOfTour = guide.NoOfTour + 1;



                }

                IGroup_FormedService serviceformed = ServiceFactory.GetGroup_FormedService();  // group formed naki check kortesi
                Group_Formed gf = serviceformed.GetByTouristId(Convert.ToInt32(Session["TouristId"]));
                if (gf == null)
                {
                    IGroup_RequestService servicereq = ServiceFactory.GetGroup_RequestService(); //groupformed na hoile single group

                    ICollection<Group_Request> gr = servicereq.GetByTouristId(Convert.ToInt32(Session["TouristId"]));
                    if (gr.Count <= 0)
                    {
                        Tour temptour = service.GetByGroup(group.GroupId); // group already tour ache naki dekhtesi
                        if (temptour != null)
                        {
                            return View("Error");
                        }
                        t.GroupId = group.GroupId;

                    }
                    else                              //group formed hoile groupformed id nichi
                    {
                        foreach (var item in gr)
                        {
                            int i = item.GroupReqId;
                            Group_Formed gf1 = serviceformed.GetByReqId(i);
                            if (gf1 != null)
                            {
                                Group group2 = serviceg.Get(item.TouristIdEx);
                                t.Area = group2.Area;
                                Tour temptour = service.GetByGroupFormed(gf1.GroupFormedId);
                                if (temptour != null)
                                {
                                    return View("Error");
                                }
                                t.GroupFormedId = gf1.GroupFormedId;



                            }
                            else
                            {
                                Tour temptour = service.GetByGroup(group.GroupId); // group already tour ache naki dekhtesi
                                if (temptour != null)
                                {
                                    return View("Error");
                                }

                                t.GroupId = Convert.ToInt32(Session["TouristId"]);
                            }
                        }

                    }

                }
                else
                {
                    Tour temptour = service.GetByGroupFormed(gf.GroupFormedId);
                    if (temptour != null)
                    {
                        return View("Error");
                    }
                    t.GroupFormedId = gf.GroupFormedId;

                }

                if (t.GroupFormedId != null)
                {

                    t.MoneyCal = t.NoOfDays * 250 * 2;
                    int temporary = Convert.ToInt32(t.MoneyCal);
                    guide.GuideRating = guide.GuideRating + temporary;
                    servicegu.Update(guide);
                }
                else if (t.GroupId != null)
                {
                    int temporary = Convert.ToInt32(t.MoneyCal);
                    guide.GuideRating = guide.GuideRating + temporary;
                    servicegu.Update(guide);
                    t.MoneyCal = t.NoOfDays * 250;
                }

                service.Insert(t);

                return View("SuccesGuide");


            }



        }

    }
}