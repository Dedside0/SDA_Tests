namespace SDATests.Models
{
    public class Question
    {
        public Guid Id { get; init; }
        public string? Image { get; set; } = "default.png";
        public string Text { get; set; }
        public int CorrectId { get; set; }
        public List<Answer> Answers { get; set; } = [];

        public Answer? RightAnswer => Answers[CorrectId];

        public Question(string questionText, IEnumerable<string> answers, int correctId, string? image = null)
        {
            this.Id = Guid.NewGuid();
            var allAns = new List<Answer>();

            var i = 0;
            foreach (var variant in answers)
            {
                var ans = new Answer(this.Id, variant, correctId == i);
                allAns.Add(ans);
                i++;
            }


            this.Text = questionText;
            this.Answers = allAns;
            Image = image ?? "default.png";
        }

    }
}
