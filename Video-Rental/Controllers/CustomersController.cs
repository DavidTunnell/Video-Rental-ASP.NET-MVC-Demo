using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Video_Rental.Models;
using Video_Rental.ViewModels;

namespace Video_Rental.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Scuppy Smith" },
                new Customer { Id = 2, Name = "Driddle Drogen" }
            };
        }

        public ActionResult Details(int id)
        {
            //get the customer by ID from the list of customers
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }


}