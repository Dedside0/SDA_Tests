
namespace SDATests.Db.Models
{
    public class Question()
    {
        public Guid Id { get; set; }
        public string? Image { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; } = [];
        public string? Explanation { get; set; }


        public Question(string questionText, List<string> answers, int correctId, string? image = null):this()
        {
            var allAns = new List<Answer>();

            var i = 0;
            foreach (var asnText in answers)
            {
                var ans = new Answer(asnText, correctId == i);
                allAns.Add(ans);
                i++;
            }


            this.Text = questionText;
            this.Answers = allAns;
            this.Image = image ?? "default.png";
        }


    }


}
