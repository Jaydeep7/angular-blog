using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSeesion.Controllers
{
    public class Home2Controller : Controller
    {
        // GET: Home2
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string button)
        {
            if (button == "Add Session")
            {
                Session["test"] = "Controller 2 ";
            }
            else
            {
                Session["test"] = "";
            }
            return View();
        }
    }
}