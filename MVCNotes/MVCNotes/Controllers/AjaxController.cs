using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCNotes.Models;

namespace MVCNotes.Controllers
{
    public class AjaxController : Controller
    {
        static  List<Product> ProductList = new List<Product>();
        // GET: Ajax
        public ActionResult Index()
        {
            Product p1 = new Product { ProdCode = "P001", ProdName = "IPHONE", ProdQty = 1 };
            Product p2 = new Product { ProdCode = "P002", ProdName = "SAMSUNG", ProdQty = 2 };
            Product p3 = new Product { ProdCode = "P003", ProdName = "NOKIA ", ProdQty = 3 };
            ProductList.Add(p1);
            ProductList.Add(p2);
            ProductList.Add(p3);
            return View();
        }
 
        [HttpPost]
        public PartialViewResult ShowDetails(string txtSearch)
        {
            Product p = new Product();
            //string code = Request.Form["txtSearch"];
            string code = txtSearch;
            foreach ( Product  p1 in ProductList)
            {
                if (p1.ProdCode == code )
                {
                    p = p1;
                    break;
                }
            }
            return PartialView("_ShowDetails",p);
        }
    }
}