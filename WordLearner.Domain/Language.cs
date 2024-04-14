using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLearner.Domain
{
    public class Language : IEntity<int>
    {
        public Language(string name, string code)
        {
            Name = name;
            Code = code;
        }
        public Language() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
