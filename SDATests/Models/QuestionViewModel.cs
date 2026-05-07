using SDATests.Db.Models;
using System.ComponentModel.DataAnnotations;

namespace SDATests.Models
{
    public class QuestionViewModel()
    {
        public Guid Id { get; init; }

        [Display(Name = "Вопрос", Prompt = "Пример: разрешена ли здесь парковка?")]
        [Required(ErrorMessage = "Заполните это поле")]
        public string Text { get; set; }

        [Required]
        public int CorrectIndex { get; set; }

        public string Image { get; set; } = "default.png";
        public string? Explanation { get; set; }

        public List<AnswerViewModel> Answers { get; set; } = [];

        //=============================================================

        public AnswerViewModel CorrectAnswer => Answers[CorrectIndex];

        public QuestionViewModel(Question quest):this()
        {
            Id = quest.Id;
            Text= quest.Text;
            Image = quest.Image;
            Explanation = quest.Explanation;
            for (int i = 0; i < quest.Answers.Count(); i++)
            {
                Answers.Add(new(quest.Answers[i]));
                if (quest.Answers[i].IsRight)
                    CorrectIndex= i;
            } ;
        }

    }
}
