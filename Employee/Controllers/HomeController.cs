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

        [HttpGet]
        public ActionResult GetEmployee(int pageIndex, int pageSize, string sortField = "Id", string sortOrder = "desc")
        {
            IEnumerable<EmployeeDB.employee> EmployeeList = null;
            IQueryable<EmployeeDB.employee> Query = null;
            IEnumerable<EmployeeDB.Model.Employee> ResultList = null;

            int itemsCount = 0;
            var param = sortField;
            var propertyInfo = typeof(EmployeeDB.employee).GetProperty(param);
            int skip = (pageIndex - 1) * pageSize;

            try
            {
                using (_Repo)
                {
                    Query = _Repo.GetEmployee();
                    itemsCount = Query.Count();

                    switch (sortField)
                    {
                        case "firstname":
                            if(sortOrder == "asc")
                            {
                                EmployeeList = Query.OrderBy(S => S.firstname);
                            }
                            else if(sortOrder == "desc")
                            {
                                EmployeeList = Query.OrderByDescending(S => S.firstname);
                            }
                            break;
                        case "lastname":
                            if(sortOrder == "asc")
                            {
                                EmployeeList = Query.OrderBy(S => S.lastname);
                            }
                            else if(sortOrder == "desc")
                            {
                                EmployeeList = Query.OrderByDescending(S => S.lastname);
                            }
                            break;

                        default:
                            EmployeeList = Query.OrderByDescending(S => S.id);
                            break;
                    }
                    ResultList = EmployeeList.Skip(skip)
                        .Take(pageSize).ToList().ToList()
                        .Select(T => _ModelMapping.LoadEmployee(T));

                    var res = EmployeeList.GroupBy(x => x.id).Select(y => y.First());
                }
            }
            catch (Exception ex)
            {
                //
            }
            var Result = new { data = ResultList, itemsCount = itemsCount };
            if(Result == null)
            {

            }

            return Json(Result, JsonRequestBehavior.AllowGet);
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