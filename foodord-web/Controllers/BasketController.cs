using foodord_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace foodord_web.Controllers
{
    public class BasketController : BaseController
    {
        private Basket basket;

        public BasketController() : base()
        {
            basket = new Basket(foodService);
        }

        public ActionResult Add(int foodId)
        {
            return Json(new { result = "ok", id = foodId });
        }
    }
}