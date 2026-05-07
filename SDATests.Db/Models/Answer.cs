namespace SDATests.Db.Models
{
    public class Answer()
    {
        public Guid Id { get; set; }

        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public string Text { get; set; }
        public bool IsRight { get; set; }

        public Answer(string text, bool isRight):this()
        {
            Text = text;
            IsRight = isRight;
        }
    }
}
