using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLearner.Domain.WordAggregate
{
    public class Translation : IEntity<int>
    {
        public int Id { get; set; }
        public string Content { get; set; } // voz // train
        public Word TargetWord { get; set; } // bahn (de) // bahn (de)
        public Language Language { get; set; } // sr // en
    }
}
