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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers
                            .ToList()
                            .Select(Mapper.Map<Customer, CustomerDto>);
        }

        // Get api/customers/1
        public CustomerDto GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id)
            
            if(customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);        

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        // Post api/customers
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(Customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return customerDto;
        }

        // Put /api/Customer/1
        [HttpPut]
        public void UpdateCustomer(int Id, CustomerDto customer)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var current = _context.Customer.SingleOrDefault(c => c.Id == Id);

            if(current == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CustomerDto, Customer>(customerDto, current);

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