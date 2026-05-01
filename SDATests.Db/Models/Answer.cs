namespace SDATests.Db.Models
{
    public class Answer()
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsRight { get; set; }

        public Answer(Guid questId, string text, bool isRight):this()
        {
            Id = Guid.NewGuid();
            QuestionId = questId;
            Text = text;
            IsRight = isRight;
        }
    }
}
