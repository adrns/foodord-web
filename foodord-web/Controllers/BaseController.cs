using foodord_web.Models;
using System.Web.Mvc;

namespace foodord_web.Controllers
{
    public class BaseController : Controller
    {
        protected IFoodService foodService;
        protected BasketModel basket;

        public BaseController()
        {
            foodService = new FoodService();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            ViewBag.Basket = basket = CreateBasket();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            Session["foodsInBasket"] = basket.Foods;
        }

        private BasketModel CreateBasket()
        {
            object foodsInBasket = Session["foodsInBasket"];
            if (foodsInBasket != null && foodsInBasket is int[])
            {
                return new BasketModel(foodService, (int[])foodsInBasket);
            }

            return new BasketModel(foodService);
        }
    }
}