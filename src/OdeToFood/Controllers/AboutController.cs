using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
