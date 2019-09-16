using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private List<Customer> Customers { get; }

        public CustomerController()
        {
            Customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Richard Hobson"},
                new Customer {Id = 2, Name = "Catherine Scott"},
                new Customer {Id = 3, Name = "Tim Craig"}
            };
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View(Customers);
        }

        public ActionResult ViewCustomer(int Id)
        {
            var customer = Customers.Find(c => c.Id == Id);
            return View(customer);
        }
    }
}