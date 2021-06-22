using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Video_Rental.Dtos;
using Video_Rental.Models;

namespace Video_Rental.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer ==  null)
            {
                return NotFound();
            } else
            {
                return Ok(Mapper.Map<Customer, CustomerDto>(customer));
            }
        }

        //POST /api/customers
        //HttpPost will only be called if a post request is called
        [HttpPost]
        public IHttpActionResult CreateCustomer (CustomerDto customerDto)
        {
            if (!ModelState.IsValid || customerDto == null)
            {
                return BadRequest();
            } else
            {
                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
                _context.Customers.Add(customer);
                _context.SaveChanges();
                //add ID generated and return to client
                customerDto.Id = customer.Id;
            }
            
            return Created(new Uri(Request.RequestUri + "/" + customerDto.Id), customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/customer/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
