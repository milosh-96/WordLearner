namespace WordLearner.Domain.Entities
{
    public class Word : IEntity<int>
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public Word()
        {
        }
        public Word(string content)
        {
            Content = content;
        }
    }
}
