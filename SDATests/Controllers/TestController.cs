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



        /// 🔽 POST: Проверяет ответ и возвращает результат + ID следующего
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckAnswer([FromBody] SubmitAnswerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 1. Проверяем существование выбранного ответа
            var question = questionRepository.TryGetById(dto.QuestionId);
            var selectedAnswer = question?.Answers?.FirstOrDefault(a => a.Id == dto.SelectedAnswerId);

            if (selectedAnswer == null)
                return BadRequest("Неверный ID вопроса или варианта ответа");

            // 2. Находим правильный ответ
            var correctAnswer = question?.Answers?.FirstOrDefault(a => a.IsRight);

            bool isCorrect = correctAnswer != null && selectedAnswer.Id == correctAnswer.Id;

            // 3. Ищем следующий вопрос в билете
            var ticket = ticketRepository.TryGetById(dto.TicketId);
            var nextTicketQuestion = ticket.TicketQuestions.FirstOrDefault(x => x.OrderIndex == dto.CurrentOrder + 1);

            // 4. Возвращаем результат
            return Ok(new
            {
                isCorrect = isCorrect,
                correctAnswerId = correctAnswer?.Id,
                explanation = isCorrect ? null : selectedAnswer.Question?.Explanation,
                nextQuestionId = nextTicketQuestion?.QuestionId
            });
        }


        [HttpGet]
        public async Task<IActionResult> GetQuestion([FromQuery] Guid ticketId, [FromQuery] int index)
        {
            var ticket = ticketRepository.TryGetById(ticketId);

            if (ticket?.TicketQuestions == null || index < 0 || index >= ticket.TicketQuestions.Count)
                return NotFound("Вопрос не найден");

            var ticketQuestion = ticket.TicketQuestions.OrderBy(tq => tq.OrderIndex).ElementAt(index);
            var question = ticketQuestion.Question;

            // 🔒 Возвращаем ответы БЕЗ флага IsCorrect!
            var viewModel = new QuestionViewModel
            {
                Id = question.Id,
                Text = question.Text,
                Image = question.Image,
                Explanation = question.Explanation,
                Answers = question.Answers
                    .Select(a => new AnswerViewModel { Id = a.Id, Text = a.Text })
                    .OrderBy(_ => Guid.NewGuid()) // Перемешиваем варианты
                    .ToList()
            };

            return PartialView("_QuestionCard", viewModel);

        }

        /// 🔽 POST: Завершение теста (опционально)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitTest([FromBody] SubmitTestDto dto)
        {
            // Здесь логика сохранения результатов, подсчёта баллов и т.д.
            // ...

            return Ok(new { success = true, resultsUrl = $"/Test/Results?ticketId={dto.TicketId}" });
        }
    }

    public record SubmitAnswerDto
    {
        public Guid TicketId { get; init; }
        public Guid QuestionId { get; init; }
        public Guid SelectedAnswerId { get; init; }
        public int CurrentOrder { get; init; }
    }

    public record SubmitTestDto
    {
        public Guid TicketId { get; init; }
        public Dictionary<Guid, int> Answers { get; init; } = new();
    }
}
