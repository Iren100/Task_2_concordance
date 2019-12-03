using System.Collections.Generic;

namespace Task_2
{
    public interface IWord: ISentenceItem
    {
        Symbol<char>[] Symbols { get; }

        int LineNumber { get; set; }

        bool IsFirstСonsonant(string[] vowels);
    }
}