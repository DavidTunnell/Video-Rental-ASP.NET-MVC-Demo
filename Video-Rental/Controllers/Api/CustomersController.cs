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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
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
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
                if (customerInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                } else
                {
                    //the 2nd arguement can be used when the mapped object already exists
                    Mapper.Map(customerDto, customerInDb);
                    _context.SaveChanges();
                }
            }
        }

        //DELETE /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();
            }
        }
    }
}
