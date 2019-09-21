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

        public ActionResult Details(int Id)
        {
            var customer = context.Customers
                                    .Include(c => c.MembershipType)
                                    .SingleOrDefault(c => c.Id == Id);

            if (customer == null) return HttpNotFound();
            return View(customer);
        }

        public ActionResult Add()
        {
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = context.MembershipTypes.ToList(),
                Customer = new Customer()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(CustomerFormViewModel formViewModel)
        {
            if (!ModelState.IsValid)
            {
                formViewModel.MembershipTypes = context.MembershipTypes.ToList();
                return View("Add", formViewModel);
            }

            if (formViewModel.Customer.Id == 0)
                context.Customers.Add(formViewModel.Customer);
            else
                TryUpdateModel(formViewModel.Customer);
            
            context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int Id)
        {
            var customer = context.Customers.Find(Id);
            if (customer == null) return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = context.MembershipTypes.ToList()
            };

            return View("Add", viewModel);
        }
    }
}