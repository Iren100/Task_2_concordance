using System.Collections.Generic;

namespace Task_2
{
    public interface IWord
    {
        IEnumerable<Symbol> Symbols { get; }

        ICollection<int> LineNumber { get; set; }

        bool IsFirstСonsonant(string[] vowels);

        string Chars { get; }
    }
}