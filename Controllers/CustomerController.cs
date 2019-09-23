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
        public ActionResult Add(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    MembershipTypes = context.MembershipTypes.ToList(),
                    Customer = customer
                };
                
                return View("Add", viewModel);
            }

            if (customer.Id == 0)
                context.Customers.Add(customer);
            else
            {
                // This needs automapped
                var source                      = context.Customers.Find(customer.Id);
                source.Name                     = customer.Name;
                source.BirthDate                = customer.BirthDate;
                source.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                source.MembershipTypeId         = customer.MembershipTypeId;
            }

            context.SaveChanges();
            return RedirectToAction("Index", "Customer");
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