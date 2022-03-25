using Microsoft.AspNetCore.Mvc;

namespace Admin.eShopDemo.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
