using System.ComponentModel.DataAnnotations;

namespace SDATests.Models
{
    public class CreateQuestionViewModel
    {
        [Display(Name = "Вопрос", Prompt = "Пример: разрешена ли здесь парковка?")]
        [Required(ErrorMessage = "заполните это поле")]
        public string QuestionText { get; set; }

        [Display(Name = "Ответ", Prompt = "Текст варианта ответа")]
        public List<string> Answers { get; set; } 

        [Required]
        public int CorrectId { get; set; }
    }

}
