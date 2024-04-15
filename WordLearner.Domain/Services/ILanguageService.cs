using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLearner.Domain.Services
{
    public interface ILanguageService
    {
        public IEnumerable<Language> GetLanguages();
        public IEnumerable<Language> GetLanguagesWithout(string code);
    }
}
