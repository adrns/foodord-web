using foodord_web.Models;
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
                case BasketModel.BasketResult.Success:
                    return Json(new { result = "success", basket = basket.Json() });
                case BasketModel.BasketResult.LimitReached:
                    return Json(new { result = "failure", reason = "limitreached", basket = basket.Json() });
                case BasketModel.BasketResult.NoSuchFood:
                    return Json(new { result = "failure", reason = "nosuchfood", basket = basket.Json() });
            }
        }

        public ActionResult Remove(int foodId)
        {
            switch (basket.Remove(foodId))
            {
                default:
                case BasketModel.BasketResult.Success:
                    return Json(new { result = "success", basket = basket.Json() });
                case BasketModel.BasketResult.NoSuchFood:
                    return Json(new { result = "failure", reason = "nosuchfood", basket = basket.Json() });
            }
        }

        public ActionResult Clear()
        {
            basket.Clear();

            return Json(new { result = "success", basket = basket.Json() });
        }
    }
}