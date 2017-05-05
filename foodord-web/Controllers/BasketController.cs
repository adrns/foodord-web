using foodord_web.Models;
using System.Web.Mvc;

namespace foodord_web.Controllers
{
    public class BasketController : BaseController
    {
        private Basket basket;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            basket = CreateBasket();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            Session["basket"] = basket;
        }

        private Basket CreateBasket()
        {
            object cached = Session["basket"];
            if (cached != null && cached is Basket)
            {
                return (Basket)Session["basket"];
            }

            return new Basket(foodService);
        }

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