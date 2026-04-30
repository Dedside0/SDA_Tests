using Microsoft.AspNetCore.Mvc;
using SDATests.Models;
using SDATests.Repositories;

namespace SDATests.Controllers
{
    public class AdminController(QuestionRepository questionRepository) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateQuestionViewModel question)
        {
            var listAnswers = question.Answers.Select(x => x.Value);
            var quest = new Question(question.QuestionText, /*question.Answers*/ listAnswers, question.CorrectId);
            questionRepository.Add(quest);

            return RedirectToAction("Index");
        }


    }
}
