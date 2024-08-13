namespace WordLearner.Domain.WordAggregate
{
    public class Word : IEntity<int>
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public Word()
        {
        }
        public Word(string content)
        {
            Content = content;
        }
    }
}
