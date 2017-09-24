using GRP.Data;
using GRP.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GRP.Web.Controllers
{
    public class CustomerController : Controller
    {
        private IRepository<Customer> repoCustomer;

        public CustomerController(IRepository<Customer> repoCustomer)
        {
            this.repoCustomer = repoCustomer;
        }
        public IActionResult Index()
        {
            List<CustomerListingViewModel> model = new List<CustomerListingViewModel>();
            repoCustomer.GetAll().ToList().ForEach(c =>
            {
                CustomerListingViewModel customer = new CustomerListingViewModel
                {
                    Id = c.Id,
                    Name = $"{c.FirstName} {c.LastName}",
                    Email = c.Email,
                    MobileNo = c.MobileNo
                };
                model.Add(customer);
            });
            return View(model);
        }

        public PartialViewResult AddEditCustomer(long? id)
        {
            CustomerViewModel model = new CustomerViewModel();
            if (id.HasValue && id.Value != 0)
            {
                Customer customer = repoCustomer.GetQueryable(id.Value).Include(c => c.Addresses).SingleOrDefault();
                if (customer != null)
                {
                    model.FirstName = customer.FirstName;
                    model.LastName = customer.LastName;
                    model.Email = customer.Email;
                    model.MobileNo = customer.MobileNo;
                    Address address = customer.Addresses.SingleOrDefault();
                    if (address != null)
                    {
                        model.AddressLine = address.AddressLine1;
                        model.Street = address.Street;
                        model.City = address.City;
                        model.Postcode = address.Postcode;
                    }
                }
            }

            return PartialView("_AddEditCustomer", model);
        }

        [HttpPost]
        public IActionResult AddEditCustomer(long? id, CustomerViewModel model)
        {
            Customer customer = new Customer();
            if (id.HasValue && id.Value != 0)
            {
                customer = repoCustomer.GetQueryable(id.Value).Include(c => c.Addresses).SingleOrDefault();
                if (customer != null)
                {
                    customer.FirstName = model.FirstName;
                    customer.LastName = model.LastName;
                    customer.Email = model.Email;
                    customer.MobileNo = model.MobileNo;
                    customer.AddedDate = DateTime.UtcNow;
                    customer.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    customer.ModifiedDate = DateTime.UtcNow;
                    Address address = customer.Addresses.SingleOrDefault();
                    if (address != null)
                    {
                        address.AddressLine1 = model.AddressLine;
                        address.Street = model.Street;
                        address.City = model.City;
                        address.Postcode = model.Postcode;
                        address.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                        address.AddedDate = DateTime.UtcNow;
                        address.ModifiedDate = DateTime.UtcNow;
                    }
                    repoCustomer.Update(customer);
                }
            }
            else
            {
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.Email = model.Email;
                customer.MobileNo = model.MobileNo;
                customer.AddedDate = DateTime.UtcNow;
                customer.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                customer.ModifiedDate = DateTime.UtcNow;
                customer.Addresses = new List<Address>
                {
                    new Address
                    {
                        AddressLine1 = model.AddressLine,
                        Street= model.Street,
                        City = model.City,
                        Postcode = model.Postcode,
                        IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                        AddedDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow
                    }
                };                    
                repoCustomer.Insert(customer);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult DeleteCustomer(long id)
        {
            Customer customer = repoCustomer.Get(id);
            return PartialView("_DeleteCustomer", $"{customer?.FirstName} { customer?.LastName}");
        }

        [HttpPost]
        public ActionResult DeleteCustomer(long id, IFormCollection form)
        {
            Customer customer = repoCustomer.Get(id);
            if (customer != null)
            {
                repoCustomer.Delete(customer);
            }
            return RedirectToAction("Index");
        }
    }
}