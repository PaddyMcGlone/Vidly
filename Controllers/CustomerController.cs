using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext context;

        public CustomerController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = context.Customers.Include(c => c.MembershipType).ToList();

            if (customers.Count == 0)
                return Content("No customers to display");

            return View(customers);
        }

        public ActionResult ViewCustomer(int Id)
        {
            var customer = context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}