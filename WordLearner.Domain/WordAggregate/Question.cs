using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLearner.Domain.WordAggregate
{
    public class Question
    {
        public string Content { get; set; } = "";

        public List<string> Choices { get; set; } = new List<string>();

        public int CorrectChoiceIndex { get; set; } = 0;
    }
}
