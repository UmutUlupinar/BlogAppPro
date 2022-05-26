using Microsoft.AspNetCore.Mvc;

namespace BlogAppPro.MVC.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
