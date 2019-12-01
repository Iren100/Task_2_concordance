using System;
using System.Collections.Generic;

namespace Task_2
{
    public interface ISentence: BaseCollection<ISentenceItem>
    {
        byte LineNumber { get; set; }

        bool IsInterrogative { get; }

        ISentence RemoveByWords(Func<IWord, bool> predicate);

        IEnumerable<ISentenceItem> ReplaceWord(Func<IWord, bool> predicate, IList<ISentenceItem> items);

        IEnumerable<IWord> GetWords();

        IEnumerable<IWord> GetWords(int length);

        IEnumerable<byte> GetLines();
    }
}
