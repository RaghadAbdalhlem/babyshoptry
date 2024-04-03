using Microsoft.AspNetCore.Mvc;

namespace BabyShop.Controllers
{
    public class searchingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult searching()
        { return View("searching"); }
    }
}
