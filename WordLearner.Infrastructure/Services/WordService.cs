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
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public WordService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public Translation GetRandomWord(string languageCode)
        {
            var context = _dbContextFactory.CreateDbContext();
            var language = context.Languages.Where(x => x.Code == languageCode).FirstOrDefault();
            if (language == null)
            {
                throw new ArgumentException($"A language with code {languageCode} could not be found.");
            }
            var ids = context.Words.Select(x=>x.Id).ToList(); // take the count off source words //
            int randomIdIndex = new Random().Next(0,(ids.Count-1)); // generate random index, -1 to prevent out of range

            var translations = context.Translations
                .Include(x => x.Language)
                .Include(x => x.TargetWord)
                .Where(x=>x.Language==language)
                .ToList();

           return translations[randomIdIndex]; // pick all words from translations of selected language and use random index //

        }

        public IEnumerable<Word> GetWords()
        {
            var context = _dbContextFactory.CreateDbContext();
            return context.Words.ToList();
        }
    }
}
