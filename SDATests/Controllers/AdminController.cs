using Microsoft.AspNetCore.Mvc;

namespace SDATests.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Save()
        {
            return View();
        }


    }
}
