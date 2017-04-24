using foodord_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace foodord_web.Controllers
{
    public class HomeController : Controller
    {
        private FoodOrderingContext entities;

        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}