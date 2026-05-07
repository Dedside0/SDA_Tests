using SDATests.Db.Models;
using System.ComponentModel.DataAnnotations;

namespace SDATests.Models
{
    public class TicketQuestionViewModel()
    {
        public Guid Id { get; set; }

        public QuestionViewModel Question { get; set; }

        public int OrderIndex { get; set; }

        public TicketQuestionViewModel(TicketQuestion ticketQuestion):this() 
        {
            Id = ticketQuestion.Id;
            Question = new(ticketQuestion.Question);
            OrderIndex = ticketQuestion.OrderIndex;
        }
    }

}