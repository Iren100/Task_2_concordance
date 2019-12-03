using System.Collections.Generic;

namespace Task_2
{
    public interface IWord//: Symbol
    {
        IEnumerable<Symbol> Symbols { get; }

        ICollection<int> LineNumber { get; set; }

        bool IsFirstСonsonant(string[] vowels);

        //string ToString();

        string Chars { get; }
    }
}