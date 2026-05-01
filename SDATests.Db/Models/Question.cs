
namespace SDATests.Db.Models
{
    public class Question()
    {
        public Guid Id { get; set; }
        public string? Image { get; set; } = "default.png";
        public string Text { get; set; }
        public int CorrectIndex { get; set; }
        public List<Answer> Answers { get; set; } = [];


        public Question(string questionText, List<string> answers, int correctId, string? image = null):this()
        {
            this.Id = Guid.NewGuid();
            var allAns = new List<Answer>();

            var i = 0;
            foreach (var asnText in answers)
            {
                var ans = new Answer(this.Id, asnText, correctId == i);
                allAns.Add(ans);
                i++;
            }


            this.Text = questionText;
            this.Answers = allAns;
            this.CorrectIndex = correctId;
            Image = image ?? "default.png";
        }


    }


}
