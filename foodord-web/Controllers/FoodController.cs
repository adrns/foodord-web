using System.Web.Mvc;

namespace foodord_web.Controllers
{
    public class FoodController : BaseController
    {
        // GET: Food
        [HttpGet]
        public ActionResult Index(int? category)
        {
            int id = null == category ? 0 : (int) category;

            ViewBag.Category = foodService.GetCategoryName(id);
            ViewBag.Foods = foodService.GetFoodsByCategory(id);

            return View("Index");
        }
    }
}