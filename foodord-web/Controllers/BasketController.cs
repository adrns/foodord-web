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
            basket.Add(foodId);

            return Json(new { result = "ok", id = foodId, total = basket.Total() });
        }
    }
}