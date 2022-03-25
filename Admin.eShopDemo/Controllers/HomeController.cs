using Microsoft.AspNetCore.Mvc;

namespace Admin.eShopDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
