using foodord_web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace foodord_web.Controllers
{
    public class BasketController : BaseController
    {
        public ActionResult Add(int foodId)
        {
            switch (basket.Add(foodId))
            {
                default:
                case Basket.BasketResult.Success:
                    return Json(new { result = "success", basket = basket.Json() });
                case Basket.BasketResult.LimitReached:
                    return Json(new { result = "failure", reason = "limitreached", basket = basket.Json() });
                case Basket.BasketResult.NoSuchFood:
                    return Json(new { result = "failure", reason = "nosuchfood", basket = basket.Json() });
            }
        }

        public ActionResult Remove(int foodId)
        {
            switch (basket.Remove(foodId))
            {
                default:
                case Basket.BasketResult.Success:
                    return Json(new { result = "success", basket = basket.Json() });
                case Basket.BasketResult.NoSuchFood:
                    return Json(new { result = "failure", reason = "nosuchfood", basket = basket.Json() });
            }
        }
    }
}