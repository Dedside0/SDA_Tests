using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDATests.Db;
using SDATests.Db.Models;
using SDATests.Models;
using SDATests.Models.Dto;

namespace SDATests.Controllers
{
    public class TestController(IQuestionRepository questionRepository, ITicketRepository ticketRepository) : Controller
    {
        public IActionResult Index()
        {
            var ticket = ticketRepository.GetAll().FirstOrDefault();
            return View(new TicketViewModel(ticket));

        }

        

        [HttpPost]
        public IActionResult CheckAnswer([FromBody] UserAnswerDto userAnswer)
        {
            var question = questionRepository.TryGetById(userAnswer.QuestionId);

            var correctAnswer = question.Answers.First(x => x.IsRight);

            bool isCorrect = correctAnswer.Id == userAnswer.AnswerId;

            return Ok(new
            {
                isCorrect,
                correctAnswerId = correctAnswer.Id,
                explanation = question.Explanation
            });
        }

        [HttpGet]
        public IActionResult GetQuestion(Guid ticketId, int index)
        {
            var ticket = ticketRepository.TryGetById(ticketId);
            var question = ticket?.TicketQuestions[index];

            return PartialView("_QuestionCard", question);
        }

       

    }
}
