using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordLearner.Application.Services;
using WordLearner.Domain.Entities;

namespace WordLearner.Infrastructure.Services
{
    public class WordService : IWordService
    {
        private readonly List<Word> _words = new List<Word>()
            {
                new Word("Bahn"),
                new Word("Strasse"),
                new Word("Hilfe"),
                new Word("Fernsehen"),
            };
        public Word GetRandomWord()
        {
            int itemsCount = _words.Count;
            int randomIndex = new Random().Next(0,(itemsCount-1)); // -1 to prevent out of range

            return _words[randomIndex];
        }

        public IEnumerable<Word> GetWords()
        {
            return _words;
        }
    }
}
