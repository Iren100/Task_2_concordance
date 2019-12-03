using System;
using System.Collections.Generic;

namespace Task_2
{
    public interface ISentence: BaseCollection<IWord>
    {
        int LineNumber { get; set; }

        TypeSentences typeSentence { get; }

        IEnumerable<IWord> GetWords();

        IEnumerable<IWord> GetWords(int length);

        ISentence RemoveByWords(Func<IWord, bool> predicate);

        ISentence ReplaceWordInSentence(int length, string line, Func<string, ISentence> parseLine);
    }
}
