﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        public ActionResult Random()
        {
            return View(new Movie{Name = "The Italian Job"});
        }

        [Route("Movies/Released/{year}/{month}")]
        public ActionResult Released(int year, int month)
        {
            return Content($"Year {year} & Month {month} - Yes Paddy !");
        }
    }
}