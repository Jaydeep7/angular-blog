using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employee = employeeContext.employees.ToList();
            return View(employee);
        }

        [HttpGet]
        [ActionName("Edit")] //Name of the action to display in URL
        public ActionResult Edit_Get(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.employees.Single(e => e.Id == id);
            return View(employee);
        }

        //[HttpPost]
        //[ActionName("Edit")] //Name of the action to display in URL
        //public ActionResult Edit_Post(Employee employee)
        //{
        //    EmployeeContext employeeContext = new EmployeeContext();
        //    employeeContext.updateEmployee(employee);
        //    return RedirectToAction("Index", "Home");
        //}

        //[HttpPost]
        //[ActionName("Edit")] 
        //public ActionResult Edit_Post(int id) //update using UpdateModel with inclue/exclude
        //{
        //    EmployeeContext employeeContext = new EmployeeContext();
        //    Employee employee = employeeContext.employees.Single(x => x.Id == id);
        //    // UpdateModel(employee, new string[] { "Gender", "City" });  only updates Gender & City
        //    //UpdateModel(employee, null,null, new string[] { "Gender", "City" } ); only updates Fields without Gender & City
        //    UpdateModel(employee);
        //    employeeContext.updateEmployee(employee);
        //    return RedirectToAction("Index", "Home");
        //}

        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post([Bind(Include = "City,id,Gender,DateOfBirth")]Employee employee) //update using Bind
        //{
        //    EmployeeContext employeeContext = new EmployeeContext();
        //    employee.Name = employeeContext.employees.Single(x => x.Id == employee.Id).Name;
        //    if (ModelState.IsValid)
        //    {
        //        employeeContext.updateEmployee(employee);
        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View();
        //}

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int Id) //update using Interface
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.employees.Single(x => x.Id == Id);
            UpdateModel<IEmployee>(employee);
            if (ModelState.IsValid)
            {
                employeeContext.updateEmployee(employee);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create_Post_FirstMethod(Employee employee)
        //{
        //    EmployeeContext employeeContext = new EmployeeContext();
        //    employeeContext.addEmployee(employee);
        //    return RedirectToAction("Index", "Home");
        //}

        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create_Post_SecondMethod(int Id, String Name)
        //{
        //    EmployeeContext employeeContext = new EmployeeContext();
        //    Employee employee = new Employee();
        //    employee.Id = Id;
        //    employee.Name = Name;
        //    employeeContext.addEmployee(employee);
        //    return RedirectToAction("Index", "Home");
        //}

        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create_Post_ThirdMethod()
        //{
        //    EmployeeContext employeeContext = new EmployeeContext();
        //    Employee employee = new Employee();
        //    UpdateModel(employee);
        //    if (ModelState.IsValid)
        //    {
        //        employeeContext.addEmployee(employee);
        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View();
        //}

        [HttpPost]
        [ActionName("Create")]
        //TryUpdateModel
        public ActionResult Create_Post_FourthMethod()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = new Employee();
            TryUpdateModel(employee);
            if (ModelState.IsValid)
            {
                employeeContext.addEmployee(employee);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult delete(int Id) //update using Interface
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.employees.Single(x => x.Id == Id);
            if (ModelState.IsValid)
            {
                employeeContext.deleteEmployee(employee);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}