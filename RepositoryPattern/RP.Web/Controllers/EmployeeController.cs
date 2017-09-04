using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RP.Data;
using RP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RP.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<EmployeeViewModel> model = employeeRepository.GetAllEmployees().Select(e => new EmployeeViewModel
            {
                Id = e.Id,
                Name = $"{e.FirstName} {e.LastName}",
                Salary = e.Salary,
                City = e.City
            });
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult AddEditEmployee(long? id)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            if (id.HasValue)
            {
                Employee employee = employeeRepository.GetEmployee(id.Value);
                if (employee != null)
                {
                    model.Id = employee.Id;
                    model.FirstName = employee.FirstName;
                    model.LastName = employee.LastName;
                    model.Salary = employee.Salary;
                    model.City = employee.City;
                }
            }
            return PartialView("~/Views/Employee/_AddEditEmployee.cshtml", model);
        }
        [HttpPost]
        public ActionResult AddEditEmployee(long? id, EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Employee employee = isNew ? new Employee
                    {
                        AddedDate = DateTime.UtcNow
                    } : employeeRepository.GetEmployee(id.Value);
                    employee.FirstName = model.FirstName;
                    employee.LastName = model.LastName;
                    employee.Salary = model.Salary;
                    employee.City = model.City;
                    employee.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    employee.ModifiedDate = DateTime.UtcNow;
                    if (isNew)
                    {
                        employeeRepository.SaveEmployee(employee);
                    }
                    else
                    {
                        employeeRepository.UpdateEmployee(employee);
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteEmployee(long id)
        {
            Employee employee = employeeRepository.GetEmployee(id);
            EmployeeViewModel model = new EmployeeViewModel
            {
                Name = $"{employee.FirstName} {employee.LastName}"
            };
            return PartialView("~/Views/Employee/_DeleteEmployee.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteEmployee(long id, IFormCollection form)
        {
            employeeRepository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
