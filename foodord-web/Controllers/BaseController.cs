using foodord_web.Models;
using System.Web.Mvc;

namespace foodord_web.Controllers
{
    public class BaseController : Controller
    {
        protected FoodService foodService;

        public BaseController()
        {
            foodService = new FoodService();
        }
    }
}