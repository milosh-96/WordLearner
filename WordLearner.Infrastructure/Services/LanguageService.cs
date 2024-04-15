using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordLearner.Domain;
using WordLearner.Domain.Services;
using WordLearner.Infrastructure.Data;

namespace WordLearner.Infrastructure.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public LanguageService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IEnumerable<Language> GetLanguages()
        {
            var context = _dbContextFactory.CreateDbContext();
            return context.Languages.AsEnumerable<Language>();
        }

        public IEnumerable<Language> GetLanguagesWithout(string code)
        {
            var context = _dbContextFactory.CreateDbContext();
            var toExlude = context.Languages.Where(x => x.Code == code).FirstOrDefault();
            if (toExlude == null)
            {
                throw new ArgumentException("This language doesn't exist.");
            }
            var languages = context.Languages.ToList();
            languages.Remove(toExlude);
            return languages;
        }
    }
}
