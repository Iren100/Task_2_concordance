using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Task_2
{
    public class Word : IWord
    {
        public Symbol<char>[] Symbols { get; }

        public byte LineNumber { get; set; }

        public int Length { get { return Symbols?.Count() ?? 0; } }

        public Word(string characters)
        {
            Symbols = characters?.Select(x => new Symbol<char>(x)).ToArray();
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

        public bool IsFirstСonsonant(string[] vowels)
        {
            return vowels.Contains(Symbols.First().Characters.ToString());
        }
    }
}
