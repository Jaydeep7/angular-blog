using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreatingDropDownList.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        public ActionResult Index()
        {
            TestDbEntities1 db = new TestDbEntities1();
               
            return View();
        }
    }
}