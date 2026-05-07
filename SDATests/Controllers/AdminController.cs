using Microsoft.AspNetCore.Mvc;
using SDATests.Db;
using SDATests.Db.Models;
using SDATests.Models;

namespace SDATests.Controllers
{
    public class AdminController(IQuestionRepository questionRepository,ITicketRepository ticketRepository) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(QuestionViewModel question)
        {
            var listAnswers = question.Answers.Select(x => x.Text).ToList();
            var quest = new Question(question.Text, listAnswers, question.CorrectIndex);
            questionRepository.Add(quest);

            return RedirectToAction("Index");
        }



        public IActionResult CreateTicket()
        {
            var vm = new TicketCreateViewModel
            {
                Questions = Enumerable.Range(0, 2)
                    .Select(_ => new QuestionCreateViewModel
                    {
                        Answers = Enumerable.Range(0, 4)
                            .Select(_ => new AnswerCreateViewModel())
                            .ToList()
                    })
                    .ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult CreateTicket(TicketCreateViewModel vm)
        {
            var ticket = new Ticket
            {
                TicketQuestions = new List<TicketQuestion>()
            };

            for (int i = 0; i < vm.Questions.Count; i++)
            {
                var qVm = vm.Questions[i];

                var question = new Question
                {
                    Text = qVm.Text,
                    Answers = new List<Answer>()
                };

                for (int j = 0; j < qVm.Answers.Count; j++)
                {
                    question.Answers.Add(new Answer
                    {
                        Text = qVm.Answers[j].Text,
                        IsRight = (j == qVm.CorrectIndex)
                    });
                }

                ticket.TicketQuestions.Add(new TicketQuestion
                {
                    Question = question,
                    OrderIndex = i
                });
            }

            ticketRepository.Create(ticket);

            return RedirectToAction("Index");
        }


    }
}
