using Microsoft.AspNetCore.Mvc;
using SDATests.Db;
using SDATests.Db.Models;
using SDATests.Models;

namespace SDATests.Controllers
{
    public class AdminController(IQuestionRepository questionRepository) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(QuestionVewModel question)
        {
            var listAnswers = question.Answers.Select(x => x.Text).ToList();
            var quest = new Question(question.Text, listAnswers, question.CorrectIndex);
            questionRepository.Add(quest);

            return RedirectToAction("Index");
        }


    }
}
