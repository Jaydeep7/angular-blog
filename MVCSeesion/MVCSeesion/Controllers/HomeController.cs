using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSeesion.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Index(string button)
        {
            if (button == "Add Session")
            {
                Session["test"] = "Controller 1 ";
            }
            else
            {
                Session["test"] = "";
            }
            return View();
        }

        [Route("/")]
        [Route("/Home")]
        [Route("/Home/Index")]
        public ActionResult Index2(string button)
        {
            return View();
        }
    }
}