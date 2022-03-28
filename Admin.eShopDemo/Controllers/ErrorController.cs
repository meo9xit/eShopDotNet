using Microsoft.AspNetCore.Mvc;

namespace Admin.eShopDemo.Controllers
{
    [Route("Error/{statusCode}")]
    public class ErrorController : Controller
    {
        public IActionResult Index(int statusCode)
        {
            return View("NotFound");
        }
    }
}
