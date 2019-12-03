using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_2
{
    public class Sentence : ISentence
    {
        public List<ISentenceItem> Items { get; set; } = new List<ISentenceItem>();

        public int LineNumber { get; set; }

        public Sentence()
        {
        }

        public Sentence(IEnumerable<ISentenceItem> items)
        {
            foreach (ISentenceItem item in items)
            {
                Items.Add(item);
            }
        }

        public TypeSentences typeSentence => Separators.EndPunctuationIsInterrogative.Contains(Items.Last().Chars)? TypeSentences.Interrogative : TypeSentences.Вeclarative;

        #region Operations

        public ISentence RemoveByWords(Func<IWord, bool> predicate)
        {
            return new Sentence(Items.Where(x => !(x is IWord && predicate((IWord)x))));
        }

        public IEnumerable<IWord> GetWords()
        {
            return Items.Where(x => x is IWord).Cast<IWord>();        
        }

        public IEnumerable<IWord> GetWords(int length)
        {
            return Items.Where(x => x is IWord).Cast<IWord>().Where(x => x.Symbols?.Count() == length);
        }

        public IEnumerable<int> GetLines()
        {
            return Items.Where(x => x is IWord).Cast<IWord>().GroupBy(x => x.Chars.ToLower()).Select(x=>x.First().LineNumber = LineNumber);
        }

        public ISentence ReplaceWordInSentence(int length, IList<ISentenceItem> elements)
        {
            return new Sentence(ReplaceWord((x => x.Symbols?.Count() == length), elements));
        }

        public ISentence ReplaceWordInSentence(int length, string line, Func<string, ISentence> parseLine)
        {
            return new Sentence(ReplaceWord((x => x.Symbols?.Count() == length), parseLine(line).Items));
        }

        public IEnumerable<ISentenceItem> ReplaceWord(Func<IWord, bool> predicate, IList<ISentenceItem> items)
        {
            var newSentence = new List<ISentenceItem>();
            foreach (var item in Items)
            {
                if (item is IWord && predicate(item as IWord))
                {
                    newSentence.AddRange(items);
                    continue;
                }
                newSentence.Add(item);
            }
            return newSentence;
        }

        private void ConcatWords(sbyte index, StringBuilder sb)
        {
            while (true)
            {
                index++;
                if (index >= Items.Count)
                {
                    break;
                }
                sb.Append(Items[index].Chars);
                var nextElement = Items.ElementAtOrDefault(index + 1);
                if (nextElement == null)
                {
                    continue;
                }
                if (Separators.AllSentence2.Contains(Items[index].Chars) || 
                    Separators.AllSentence4.Contains(nextElement.Chars))
                {
                    continue;
                }
                if (Separators.ClosePunctuation.Contains(Items[index].Chars))
                {
                    break;
                }
                if (Separators.OpenPunctuation.Contains(Items[index].Chars) ||
                    Separators.RepeatPunctuation.Contains(Items[index].Chars))
                {
                    ConcatWords(index, sb);
                }
                if (!Separators.ClosePunctuation.Contains(nextElement.Chars))
                {
                    sb.Append(" ");
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            ConcatWords(-1, sb);
            return sb.ToString();
        }

        #endregion
    }
}
