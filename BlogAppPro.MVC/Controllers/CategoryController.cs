using Microsoft.AspNetCore.Mvc;

namespace BlogAppPro.MVC.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
