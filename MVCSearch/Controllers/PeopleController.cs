using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSearch.Models;

namespace MVCSearch.Controllers
{
    public class PeopleController : Controller
    {
        People db = new People();
        // GET: People
        //public ActionResult Index()
        //{

        //    return View(db.Peoples.ToList());
        //}

        public ActionResult Index(string searchText, string searchBy, string orderBy)
        {
            ViewBag.OrderByName = string.IsNullOrEmpty(orderBy) ? "Name Desc" : "";
            ViewBag.OrderByAge = orderBy == "Age" ? "Age Desc" : "Age";
            ViewBag.searchText = searchText ?? "";

            var people = db.Peoples.AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
            {
                if (searchBy == "Name")
                {
                    people = people.Where(x => x.Name.StartsWith(searchText));
                }
                else if (searchBy == "Age")
                {
                    var age = Convert.ToInt64(searchText);
                    people = people.Where(x => x.Age == age);
                }
            }
            switch (orderBy)
            {
                case "Name Desc":
                    people = people.OrderByDescending(x => x.Name);
                    break;
                case "Age":
                    people = people.OrderBy(x => x.Age);
                    break;
                case "Age Desc":
                    people = people.OrderByDescending(x => x.Age);
                    break;
                default:
                    people = people.OrderBy(x => x.Name);
                    break;
            }

            return View(people.ToList());
        }

        public ActionResult DeletePeople()
        {
            return View(db.Peoples.ToList());
        }

        [HttpPost]
        public ActionResult DeletePeople(IEnumerable<string> idsToDelete)
        {
            IEnumerable<Person> persons = db.Peoples.Where(x => idsToDelete.Contains(x.Name));
            db.Peoples.RemoveRange(persons);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult ChildOnlyMethod()
        {
            return View();
        }

        public ActionResult Method1()
        {
            return View();
        }
    }


}