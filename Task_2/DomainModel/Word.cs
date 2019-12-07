using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Task_2
{
    public class Word : IWord
    {
        public IEnumerable<Symbol> Symbols { get; }

        public ICollection<int> LineNumber { get; set; } = new List<int>();

        public Word(string characters)
        {
            Symbols = characters?.Select(x => new Symbol(x.ToString())).ToList();
        }

        public string Chars
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var symbol in Symbols)
                {
                    sb.Append(symbol.Characters);
                }
                return sb.ToString();
            }
        }

        public bool IsFirstСonsonant(string[] consonants)
        {
            return consonants.Contains(Symbols.First().Characters.ToString());
        }
    }
}
