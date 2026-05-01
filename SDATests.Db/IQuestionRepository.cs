using SDATests.Db.Models;

namespace SDATests.Db
{
    public interface IQuestionRepository
    {
        void Add(Question question);
        List<Question> GetAll();
        Question? TryGetById(Guid id);
    }
}