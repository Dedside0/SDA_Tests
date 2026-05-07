namespace SDATests.Models
{
    public class QuestionCreateViewModel
    {
        public string Text { get; set; } = string.Empty;

        public List<AnswerCreateViewModel> Answers { get; set; } = new();

        public int CorrectIndex { get; set; }
    }
}
