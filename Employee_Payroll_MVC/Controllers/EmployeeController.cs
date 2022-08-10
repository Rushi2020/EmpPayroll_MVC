using BusinessLayer;
using DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee_Payroll_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeBL employeeBl;
         public EmployeeController(IEmployeeBL employeeBl)
        {
            this.employeeBl = employeeBl;

        }
        public IActionResult Index()
        {
            List<UserModel> lstEmployee = new List<UserModel>();
            lstEmployee = employeeBl.GetAllEmployees().ToList();

            return View(lstEmployee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] UserModel employee)
        {
            if (ModelState.IsValid)
            {
              this.employeeBl.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        
        }

        [HttpGet]
        public IActionResult Edit(int? EmployeeID)
        {
            if (EmployeeID == null)
            {
                return NotFound();
            }
            UserModel employee = employeeBl.GetEmployeeData(EmployeeID);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int EmployeeID, [Bind] UserModel employee)
        {
            if (EmployeeID != employee.EmployeeID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                this.employeeBl.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserModel employee = employeeBl.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            employeeBl.DeleteEmployee(id);
            return RedirectToAction("Index");
        }


       
    }
}
