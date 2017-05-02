using System.Web.Mvc;

namespace foodord_web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Categories = foodService.GetCategories();
            ViewBag.TopFoods = foodService.GetTopTenFoods();

            return View("Index");
        }
    }
}