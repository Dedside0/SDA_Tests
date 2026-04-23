using Microsoft.AspNetCore.Mvc;

namespace SDATests.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
