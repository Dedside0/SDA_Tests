namespace SDATests.Models
{
    public class Question
    {
        public Guid Id { get; private set; }
        public string? Image { get; set; }
        public required string Text { get; set; }
        public required string RightAnswer { get; set; }
        private List<string> _answers = [];
        public List<string> Answers => new(_answers);

    }
}
