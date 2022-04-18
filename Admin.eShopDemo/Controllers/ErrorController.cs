using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace Admin.eShopDemo.Controllers
{
    [Route("Error/{statusCode}")]
    public class ErrorController : Controller
    {
        public IActionResult Index(int statusCode)
        {
            ViewData["Title"] = ReasonPhrases.GetReasonPhrase(statusCode);
            return View("NotFound");
        }
    }
}
