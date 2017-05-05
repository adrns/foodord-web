using foodord_web.Models;
using System.Web.Mvc;

namespace foodord_web.Controllers
{
    public class BaseController : Controller
    {
        protected FoodService foodService;
        protected Basket basket;

        public BaseController()
        {
            foodService = new FoodService();
        }

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
    }
}