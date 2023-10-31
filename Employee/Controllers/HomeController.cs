using Employee.Model;
using EmployeeDB.Interface;
using EmployeeDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class HomeController : Controller
    {
        IEmployeeRepository _Repo;
        ModelMapping _ModelMapping;

        public HomeController() { }

        public HomeController(IEmployeeRepository Repo, ModelMapping ModelMapping)
        {
            _Repo = Repo;
            _ModelMapping = ModelMapping;
        }

        public ActionResult Index()
        {
            SelectLists ddFilter = new SelectLists();
            ddFilter.EmployeeList = new SelectList((from a in _Repo.GetEmployee()
                                                    select new
                                                    {
                                                        Value = a.id,
                                                        Text = a.firstname.Trim() + " " + a.lastname.Trim()
                                                    }).Distinct(), "Value", "Text");
            return View(ddFilter);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}