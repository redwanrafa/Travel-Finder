using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.Controllers
{
    public class BaseController : Controller
    {
            protected override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);

                // Enable the following code to activate session check

                /*if(Session["LoggedInUser"] == null)
                {
                    Response.Redirect("/Login");
                }*/
            }
        }
    }
