
namespace SDATests.Db.Models
{

    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }   
        public string Explanation { get; set; } = string.Empty; 
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
        public ICollection<TicketQuestion> TicketQuestions { get; set; } = new List<TicketQuestion>();
    }

    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        public string Text { get; set; } = string.Empty;
        public bool IsCorrect { get; set; } 
    }

    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<TicketQuestion> TicketQuestions { get; set; } = new List<TicketQuestion>();
    }


    public class TicketQuestion
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;

        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;

        public int OrderIndex { get; set; } 
    }
}
