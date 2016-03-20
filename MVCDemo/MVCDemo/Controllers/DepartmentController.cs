using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            EmployeeContext dbContext = new EmployeeContext();
            List<Department> departments = dbContext.Departments.ToList();
            return View(departments);
        }
    }
}