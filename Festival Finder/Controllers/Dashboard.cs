using Microsoft.AspNetCore.Mvc;

namespace Festival_Finder.Controllers
{
    public class Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
