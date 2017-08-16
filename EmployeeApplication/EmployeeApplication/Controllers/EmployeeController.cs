using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeApplication.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeApplication.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(EmployeeData.Employees);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            EmployeeViewModel model = new EmployeeViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeData.Employees.Add(model);
            }
            return RedirectToAction("Index");
        }
    }
}
