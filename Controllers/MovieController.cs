using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        public ActionResult Random()
        {
            // There are other properties within the viewResult, not just model.
            //var viewResult = new ViewResult
            //{
            //    ViewData =
            //    {
            //        Model = new Movie {Name = "The Italian Job"}
            //    }
            //};

            // Initialise the new ViewModel
            var viewModel = new RandomMovieViewModel
            {
                Movie = new Movie {Name = "Everest"},
                Customers = new List<Customer>
                {
                    new Customer {Name = "Joe"},
                    new Customer {Name = "Aaron"}
                }
            };

            return View(viewModel);

            //return View(new Movie{Name = "The Italian Job"});
        }

        [Route("Movies/Released/{year}/{month}")]
        public ActionResult Released(int year, int month)
        {
            return Content($"Year {year} & Month {month} - Yes Paddy !");
        }
    }
}