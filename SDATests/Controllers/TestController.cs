using Microsoft.AspNetCore.Mvc;
using SDATests.Db;
using SDATests.Models;

namespace SDATests.Controllers
{
    public class TestController(IQuestionRepository questionRepository) : Controller
    {
        public IActionResult Index()
        {
            Guid g = Guid.Parse("53E50F43-D3B3-4926-AA70-A4AE78679569");
            var all = questionRepository.TryGetById(g);
            var newAll = new List<QuestionVewModel>();
                newAll.Add(new QuestionVewModel(all));
            return View(newAll);
        }


    }
}
