using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(int ? id)
        {
            ViewBag.choice = id;
            ViewBag.jobs = Jobs.JobList();
            return View();
        }
        public ActionResult EditSalary(int id, string salary)
        {
            try
            {
                Employees.CorrectSalary(id, Double.Parse(salary));
            }
            catch(FormatException)
            {
            }            
            return RedirectToAction("Index");
        }

    }
}
