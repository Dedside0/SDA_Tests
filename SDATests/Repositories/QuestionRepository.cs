using SDATests.Models;

namespace SDATests.Repositories
{
    public class QuestionRepository()
    {
        public List<Question> _questions = [
            new Question("Вопрос 1", new List<string>{"Вариант 1", "Вариант 2", "Вариант 3", "Вариант 4"}, 1),
            new Question("Вопрос 2", new List<string>{"Вариант 1", "Вариант 2", "Вариант 3", "Вариант 4"}, 1),
            new Question("Вопрос 3", new List<string>{"Вариант 1", "Вариант 2", "Вариант 3", "Вариант 4"}, 1),
            new Question("Вопрос 4", new List<string>{"Вариант 1", "Вариант 2", "Вариант 3", "Вариант 4"}, 1),
            ];

        public List<Question> GetAll() => new List<Question>(_questions);


        public Question? TryGetById(Guid id) => _questions.FirstOrDefault(x => x.Id == id);

        public void Add(Question question)
        {
            _questions.Add(question);
        }
    }
}
