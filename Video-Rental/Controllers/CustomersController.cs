using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Video_Rental.Models;
using Video_Rental.ViewModels;

//https://www.restapitutorial.com/lessons/httpmethods.html

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

        // For New entries, get the membership type list from the DB to be selectable
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var ViewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", ViewModel);
        }

        // POST: Customer
        //using the same view model used on the view here (Model Binding) - NewCustomerViewModel
        //or the framework is also smart enough to bind the object being used - Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //checks the model state and checks for validation
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            
            //if id = 0 then they are a new customer
            if (customer.Id == 0)
            {
                //add data from form to memory and then save to DB
                _context.Customers.Add(customer);
            }
            else //existing so update instead of create
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //update using arguement coming in from form
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            //redirect to the main customer page 
            return RedirectToAction("Index", "Customers");
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
            //get the customer by ID from the list of customers from DB. Include associated objects from foreign keys
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            //get customer with arguements id from DB
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);


            if (customer == null) {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

    }


}