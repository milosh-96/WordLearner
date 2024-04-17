using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordLearner.Domain.WordAggregate;

namespace WordLearner.Domain.Services
{
    public interface IQuestionService
    {
        public Question GenerateQuestion(string content, string correctChoice, IEnumerable<string> choices);
    }
}
