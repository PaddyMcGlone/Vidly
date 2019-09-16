using System.Collections.Generic;
using System.Linq;
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
            if (Customers.Count == 0)
                return Content("No customers to display");

            return View(Customers);
        }

        public ActionResult ViewCustomer(int Id)
        {
            var customer = Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}