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
            ViewBag.Foods = foodService.GetFoodsByCategory(categoryId);

            return View("Category");
        }
    }
}