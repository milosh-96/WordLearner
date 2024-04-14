using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordLearner.Domain.Services;
using WordLearner.Domain.WordAggregate;
using WordLearner.Infrastructure.Data;

namespace WordLearner.Infrastructure.Services
{
    public class WordService : IWordService
    {
        private readonly ApplicationDbContext _context;

        public WordService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Translation GetRandomWord(string languageCode)
        {
            var language = _context.Languages.Where(x => x.Code == languageCode).FirstOrDefault();
            if (language == null)
            {
                throw new ArgumentException($"A language with code {languageCode} could not be found.");
            }
            var ids = _context.Words.Select(x=>x.Id).ToList(); // take the count off source words //
            int randomIdIndex = new Random().Next(0,(ids.Count-1)); // generate random index, -1 to prevent out of range

            var translation = _context.Translations.Include(x=>x.Language).Include(x=>x.TargetWord).Where(x=>x.Language==language).FirstOrDefault(x => x.Id == ids[randomIdIndex]); // pick all words from translations of selected language and use random index //

            return translation;
        }

        public IEnumerable<Word> GetWords()
        {
            return _context.Words.ToList();
        }
    }
}
