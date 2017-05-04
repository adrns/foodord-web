using foodord_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace foodord_web.Controllers
{
    public class BasketController : BaseController
    {
        private Basket basket;

        public BasketController() : base()
        {
            basket = new Basket(foodService);
        }
    }
}