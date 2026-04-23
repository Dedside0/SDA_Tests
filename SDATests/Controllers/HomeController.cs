using Microsoft.AspNetCore.Mvc;
using SDATests.Db;
using SDATests.Models;
using System.Diagnostics;

namespace SDATests.Controllers
{
    public class HomeController : Controller
    {
        DataBaseContext db;
        private readonly ILogger<HomeController> _logger;
        public HomeController(DataBaseContext db, ILogger<HomeController> logger)
        {
            this.db = db;

            _logger = logger;
        }



        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
