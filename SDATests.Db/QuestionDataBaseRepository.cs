using SDATests.Db.Models;

namespace SDATests.Db
{
    public class QuestionDataBaseRepository(DataBaseContext dbContext) : IQuestionRepository
    {
        //public List<Question> _questions = [
        //    new Question("Вопрос 1", new List<string>{"Вариант 1", "Вариант 2", "Вариант 3", "Вариант 4"}, 1),
        //    new Question("Вопрос 2", new List<string>{"Вариант 1", "Вариант 2", "Вариант 3", "Вариант 4"}, 1),
        //    new Question("Вопрос 3", new List<string>{"Вариант 1", "Вариант 2", "Вариант 3", "Вариант 4"}, 1),
        //    new Question("Вопрос 4", new List<string>{"Вариант 1", "Вариант 2", "Вариант 3", "Вариант 4"}, 1),
        //    ];

        public List<Question> GetAll() => dbContext.Questions.ToList();


        public Question? TryGetById(Guid id) => dbContext.Questions.FirstOrDefault(q => q.Id == id);
        

        public void Add(Question question)
        {
            dbContext.Questions.Add(question);
            dbContext.SaveChanges();
        }
    }
}
