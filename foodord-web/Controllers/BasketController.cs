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
                case Basket.BasketResult.Success:
                    return Json(new { result = "success", foodId = foodId, total = basket.Total(), count = basket.Count() });
                case Basket.BasketResult.LimitReached:
                    return Json(new { result = "failure", reason = "limitreached", foodId = foodId, total = basket.Total(), count = basket.Count() });
                case Basket.BasketResult.NoSuchFood:
                    return Json(new { result = "failure", reason = "nosuchfood", foodId = foodId, total = basket.Total(), count = basket.Count() });
            }

            return Json(new { result = "success", id = foodId, total = basket.Total() });
        }
    }
}