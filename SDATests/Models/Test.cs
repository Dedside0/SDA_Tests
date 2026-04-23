namespace SDATests.Models
{
    public class Test
    {
        public Guid Id { get; private set; }

        private List<Question> _questions = [];
        public int Count  => _questions.Count; 
        public int RightCount { get; set; }

    }
}
