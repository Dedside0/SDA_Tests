using Microsoft.EntityFrameworkCore;
using SDATests.Db.Models;

namespace SDATests.Db
{
    public class QuestionRepository(AppContext dbContext) : IQuestionRepository
    {
        //public List<Question> _questions = [
        //    new Question("Вопрос 1", new List<string>{"Вариант 1", "Вариант 2", "Вариант 3", "Вариант 4"}, 1),
        //    new Question("Вопрос 2", new List<string>{"Вариант 1", "Вариант 2", "Вариант 3", "Вариант 4"}, 1),
        //    new Question("Вопрос 3", new List<string>{"Вариант 1", "Вариант 2", "Вариант 3", "Вариант 4"}, 1),
        //    new Question("Вопрос 4", new List<string>{"Вариант 1", "Вариант 2", "Вариант 3", "Вариант 4"}, 1),
        //    ];

        public List<Question> GetAll() => dbContext.Questions.Include(x=>x.Answers).ToList();


        public Question? TryGetById(Guid id) => dbContext.Questions.Include(x=>x.Answers).FirstOrDefault(q => q.Id == id);
        

        public void Add(Question question)
        {
            dbContext.Questions.Add(question);
            dbContext.SaveChanges();
        }
    }
}
