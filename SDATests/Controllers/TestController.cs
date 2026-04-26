using Microsoft.AspNetCore.Mvc;
using SDATests.Models;
using SDATests.Repositories;

namespace SDATests.Controllers
{
    public class TestController(QuestionRepository questionRepository) : Controller
    {
        public IActionResult Index()
        {
            return View(questionRepository.GetAll());
        }


    }
}
