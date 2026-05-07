using SDATests.Db.Models;
using System.ComponentModel.DataAnnotations;

namespace SDATests.Models
{
    public class AnswerViewModel()
    {
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Заполните это поле")]
        [Display(Name = "Ответ", Prompt = "Вариант ответа")]
        public string Text { get; set; }

        public bool IsRight { get; set; }

        public AnswerViewModel(Answer ans):this()
        {
            Id = ans.Id;
            Text = ans.Text;
            IsRight = ans.IsRight;
            
        }
    }
}
