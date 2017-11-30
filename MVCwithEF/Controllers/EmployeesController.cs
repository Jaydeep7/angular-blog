using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCwithEF.Models;

namespace MVCwithEF.Controllers
{
    public class EmployeesController : Controller
    {
        private TestDbEntities db = new TestDbEntities();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.ToList();
            return View(employees);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,City,DOB,Salary,DeptId")] Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Name))
            {
                ModelState.AddModelError("Name", "Blank Name Not Allowed......!!!");
            }
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptName", employee.DeptId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptName", employee.DeptId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,City,DOB,Salary,DeptId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptName", employee.DeptId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult EmployeeByDepartment()
        {
            IOrderedEnumerable<DepartmentTotals> employees = db.Employees.Include("Department")
                            .GroupBy(x => x.Department.DeptName)
                            .Select(y => new DepartmentTotals
                            {
                                Name = y.Key,
                                Total = y.Count()

                            }).ToList().OrderBy(z => z.Total);
            return View(employees);
        }

        public ActionResult HtmlHelpers()
        {
            Employee emp = db.Employees.Single(x => x.Id == 2);
            return View(emp);
        }

        public ActionResult DropDown()
        {
            List<Department> DeptList = db.Departments.ToList();
            //ViewBag.Departments = new SelectList(db.Departments, "DeptId", "DeptName" ,1); First Way......
            //second way
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach(Department dp in DeptList)
            {
                SelectListItem item = new SelectListItem();
                item.Text = dp.DeptName;
                item.Value = dp.DeptId.ToString();
                item.Selected = dp.isSelected.HasValue ? dp.isSelected.Value : false;
                selectListItems.Add(item);
            }
            ViewBag.Departments = selectListItems;
            return View();
        }

        [HttpGet]
        public ActionResult TryRadio()
        {
            List<Department> departments = db.Departments.ToList();
            return View(departments);
        }

        [HttpPost]
        //[ActionName("TryRadio")]
        public string TryRadio(Department departments)
        {
                        return "You selected : " + departments.DeptId;
        }

        public ActionResult TryCheck()
        {
            List<Department> depts = db.Departments.ToList();
            return View();
        }
    }

}
