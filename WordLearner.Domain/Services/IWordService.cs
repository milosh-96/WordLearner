using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordLearner.Domain.WordAggregate;

namespace WordLearner.Domain.Services
{
    public interface IWordService
    {
        public IEnumerable<Word> GetWords();
        public Translation GetRandomWord(string languageCode);
    }
}
