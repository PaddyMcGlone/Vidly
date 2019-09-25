using System;
using System.Web.Http;
using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // Get api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // Get api/customers/1
        public Customer GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id)
            
            if(customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        // Post api/customers
        public Customer CreateCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(Customer);
            _context.SaveChanges();

            return customer;
        }

        // Put /api/Customer/1
        [HttpPut]
        public void UpdateCustomer(int Id, Customer customer)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var current = _context.Customer.SingleOrDefault(c => c.Id == Id);

            if(current == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            current.Name                     = customer.Name;
            current.Birthdate                = customer.Birthdate;
            current.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            current.MembershipTypeId         = customer.MembershipTypeId;

            _context.SaveChanges();
        }

        // Delete /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var current = _context.Customer.SingleOrDefault(c => c.Id == Id);

            if(current == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(current);
            _context.SaveChanges();
        }


    }
}