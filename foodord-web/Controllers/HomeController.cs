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

        public HomeController()
        {
            entities = new FoodOrderingContext();
        }

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Categories = entities.Categories.ToList();
            ViewBag.TopFoods = entities.Foods.ToList(); //TODO create real query
            return View("Index");
        }
    }
}