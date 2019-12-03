using System;
using System.Collections.Generic;

namespace Task_2
{
    public interface ISentence: BaseCollection<ISentenceItem>
    {
        int LineNumber { get; set; }

        TypeSentences typeSentence { get; }

        ISentence RemoveByWords(Func<IWord, bool> predicate);

        IEnumerable<ISentenceItem> ReplaceWord(Func<IWord, bool> predicate, IList<ISentenceItem> items);

        IEnumerable<IWord> GetWords();

        IEnumerable<IWord> GetWords(int length);

        IEnumerable<int> GetLines();

        ISentence ReplaceWordInSentence(int length, IList<ISentenceItem> elements);

        ISentence ReplaceWordInSentence(int length, string line, Func<string, ISentence> parseLine);
    }
}
