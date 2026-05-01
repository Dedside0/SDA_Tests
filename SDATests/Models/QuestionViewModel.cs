using SDATests.Db.Models;
using System.ComponentModel.DataAnnotations;

namespace SDATests.Models
{
    public class QuestionVewModel()
    {
        public Guid Id { get; init; }

        [Display(Name = "Вопрос", Prompt = "Пример: разрешена ли здесь парковка?")]
        [Required(ErrorMessage = "Заполните это поле")]
        public string Text { get; set; }

        public string? Image { get; set; } = "default.png";

        public List<AnswerViewModel> Answers { get; set; } = [];

        [Required]
        public int CorrectIndex { get; set; }

        public AnswerViewModel CorrectAnswer => Answers[CorrectIndex];


        public QuestionVewModel(Question quest):this()
        {
            Id = quest.Id;
            Text= quest.Text;
            Image = quest.Image;
            CorrectIndex = quest.CorrectIndex;
            foreach (var ans in quest.Answers)
            {
                Answers.Add(new(ans));
            } ;
        }

    }
}
