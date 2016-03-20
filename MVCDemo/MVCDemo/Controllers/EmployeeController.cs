using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeContext dbContext = new EmployeeContext();
            List<Employee> employees = dbContext.Employees.ToList();

            return View(employees);
        }

        public ActionResult Details(int? id)
        {
            ActionResult action = RedirectToAction("Index");
            if (id != null)
            {

                EmployeeContext dbContext = new EmployeeContext();
                Employee employee = dbContext.Employees.SingleOrDefault(x => x.EmployeeId == id);
                if (employee != null)
                {
                    action = View(employee);
                }
            }
            return action;
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult CreateGet()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost()
        {
            ActionResult action = View();
            Employee employee = new Employee();
            TryUpdateModel<Employee>(employee);

            if (ModelState.IsValid)
            {
                EmployeeContext dbContext = new EmployeeContext();
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();

                action = RedirectToAction("Index");
            }
            return action;
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult EditGet(int? id)
        {
            ActionResult action = RedirectToAction("Index");
            if (id != null)
            {

                EmployeeContext dbContext = new EmployeeContext();
                Employee employee = dbContext.Employees.SingleOrDefault(x => x.EmployeeId == id);
                if (employee != null)
                {
                    action = View(employee);
                }
            }
            return action;
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost()
        {
            ActionResult action = View();
            Employee employee = new Employee();
            TryUpdateModel<Employee>(employee);

            if (ModelState.IsValid)
            {
                EmployeeContext dbContext = new EmployeeContext();
                Employee currentDetails = dbContext.Employees.SingleOrDefault(x => x.EmployeeId == employee.EmployeeId);

                // Name property is black listed
                if (currentDetails != null)
                {
                    currentDetails.Gender = employee.Gender;
                    currentDetails.DateOfBirth = employee.DateOfBirth;
                    currentDetails.City = employee.City;
                    dbContext.SaveChanges();

                }
                action = RedirectToAction("Index");
            }
            return action;
        }

        [HttpGet]
        public ActionResult Delete(int? id) 
        {
            EmployeeContext dbContext = new EmployeeContext();
            if (id != null)
            {
                Employee employee = dbContext.Employees.SingleOrDefault(e => e.EmployeeId == id);
                if (employee != null)
                {
                    dbContext.Employees.Remove(employee);
                }
                dbContext.SaveChanges();
            }

            return RedirectToAction("Index"); 
        }
    }
}