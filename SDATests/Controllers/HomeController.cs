using Microsoft.AspNetCore.Mvc;
using SDATests.Db;
using SDATests.Models;
using System.Diagnostics;

namespace SDATests.Controllers
{
    public class HomeController(ILogger<HomeController> _logger, IQuestionRepository questionRepository) : Controller
    {


        public IActionResult Index()
        {
            return View(questionRepository.GetAll());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
