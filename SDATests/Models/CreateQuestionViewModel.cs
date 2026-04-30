using System.ComponentModel.DataAnnotations;

namespace SDATests.Models
{
    public class CreateQuestionViewModel
    {
        [Display(Name = "Вопрос", Prompt = "Пример: разрешена ли здесь парковка?")]
        [Required(ErrorMessage = "Заполните это поле")]
        public string QuestionText { get; set; }


        public List<OptionViewModel> Answers { get; set; } 

        [Required]
        public int CorrectId { get; set; }
    }

    public class OptionViewModel
    {
        [Required(ErrorMessage = "Заполните это поле")]
        [Display(Name = "Ответ", Prompt = "Вариант ответа")]
        public string Value { get; set; }
    }

}
