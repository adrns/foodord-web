using foodord_web.Models;
using System.Web.Mvc;

namespace foodord_web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.IsHome = true;
            ViewBag.Categories = foodService.GetCategories();
            ViewBag.TopFoods = foodService.GetTopTenFoods();

            return View("Index");
        }

        // GET: Home/Category/?id
        [HttpGet]
        public ActionResult Category(int? id)
        {
            int categoryId = null == id ? 0 : (int)id;

            ViewBag.Category = foodService.GetCategoryName(categoryId);
            string filter = Request.QueryString["filter"];
            ViewBag.Foods = null != filter && filter.Length > 0 ? foodService.GetFilteredFoodsByCategory(categoryId, filter) : foodService.GetFoodsByCategory(categoryId);

            return View("Category");
        }

        [HttpGet]
        public ActionResult Basket()
        {
            ViewBag.IsBasket = true;

            return View("Basket", basket);
        }

        [HttpGet]
        public ActionResult Order()
        {
            return View("Order");
        }

        public ActionResult Order(OrderForm form)
        {
            if (ModelState.IsValid && basket.Count() > 0)
            {
                foodService.PlaceOrder(Models.Order.Create(foodService.Entities, form, basket));
                basket.Clear();
                ViewBag.OrderSuccess = true;
            }

            return View("Order");
        }
    }
}