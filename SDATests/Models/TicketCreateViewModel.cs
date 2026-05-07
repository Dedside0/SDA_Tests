namespace SDATests.Models
{
    public class TicketCreateViewModel
    {
        public string Name { get; set; } = string.Empty;

        public List<QuestionCreateViewModel> Questions { get; set; } = new();
    }
}
