using foodord_web.Models;
using System.Web.Mvc;

namespace foodord_web.Controllers
{
    public class BaseController : Controller
    {
        protected FoodService foodService;
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


            foodService.SaveChanges();
            Session["basket"] = basket.Id;
        }

        private BasketModel CreateBasket()
        {
            object cached = Session["basket"];
            if (cached != null && cached is int)
            {
                return new BasketModel(foodService, (int)Session["basket"]);
            }

            return new BasketModel(foodService);
        }
    }
}