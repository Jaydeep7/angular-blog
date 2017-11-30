using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransferDataFromControllerToView.Models;

namespace TransferDataFromControllerToView.Controllers
{
    public class HomeController : Controller
    {

        public Repository _repository = new Repository();

        // GET: Home
        public ActionResult ViewDataDemo()
        {
            ViewData["Courses"] = _repository.GetCourses();
            ViewData["Students"] = _repository.GetStudents();
            ViewData["Faculties"] = _repository.GetFaculties();
            return View();
        }

        public ActionResult ViewBagDemo()
        {
            ViewBag.Faculties = _repository.GetFaculties();
            ViewBag.Students = _repository.GetStudents();
            ViewBag.Courses = _repository.GetCourses();
            return View();
        }
    }
}