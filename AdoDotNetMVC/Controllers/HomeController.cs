using AdoDotNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoDotNetMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            EmployeeDBContext db = new EmployeeDBContext();
            List<Employee> obj = db.GetEmployees();
            return View(obj);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDBContext context = new EmployeeDBContext();
                    bool check = context.AddEmployee(emp);
                    if (check == true)
                    {
                        TempData["InsertMessage"] = " Data has been Inserted Successfully.";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            var row = context.GetEmployees().Find(model => model.id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDBContext context = new EmployeeDBContext();
                    bool check = context.UpdateEmployee(emp);
                    if (check == true)
                    {
                        TempData["UpdateMessage"] = " Data has been Updated Successfully.";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            var row = context.GetEmployees().Find(model => model.id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int id, Employee emp)
        {
            try
            {
                EmployeeDBContext context = new EmployeeDBContext();
                bool check = context.DeleteEmployee(id);
                if (check == true)
                {
                    TempData["DeleteMessage"] = " Data has been Deleted Successfully.";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            var row = context.GetEmployees().Find(model => model.id == id);
            return View(row);
        }
    }
}