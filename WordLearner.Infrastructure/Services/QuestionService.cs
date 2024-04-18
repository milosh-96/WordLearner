using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordLearner.Domain.Services;
using WordLearner.Domain.WordAggregate;

namespace WordLearner.Infrastructure.Services
{
    public class QuestionService : IQuestionService
    {
        public Question GenerateQuestion(string content, string correctChoice, IEnumerable<string> choices)
        {
            var newChoices = choices.ToList();
            newChoices.Add(correctChoice);
            var correctIndex = new Random((int)DateTime.UtcNow.Ticks).Next(0, newChoices.Count);

            var temp = newChoices[correctIndex];

            newChoices[newChoices.Count-1] = temp;
            newChoices[correctIndex] = correctChoice;

            return new Question() { Content = content, Choices = newChoices, CorrectChoiceIndex = correctIndex };
        }
    }
}
