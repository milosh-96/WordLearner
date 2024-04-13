using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordLearner.Domain.Entities;

namespace WordLearner.Application.Services
{
    public interface IWordService
    {
        public IEnumerable<Word> GetWords();
        public Word GetRandomWord();
    }
}
