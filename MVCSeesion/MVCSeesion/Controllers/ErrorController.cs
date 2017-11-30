using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSeesion.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult error404()
        {
            return View();
        }
    }
}