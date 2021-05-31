using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Video_Rental.Models;
using Video_Rental.ViewModels;

namespace Video_Rental.Controllers
{
    public class CustomersController : Controller
    {
        //get DB context for controller
        private ApplicationDbContext _context;

        //initialize it in constructor
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //Dispose of ApplicationDbContext via overriding the Dispose method of the base controller class
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {

            //get customers from DB. Note this is a deferred execution object. Once iterated on it will actually run the SQL query. Adding ToList also makes it run. 
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //get the customer by ID from the list of customers from DB
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }


}