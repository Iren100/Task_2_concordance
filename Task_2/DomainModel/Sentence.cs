using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_2
{
    public class Sentence : ISentence
    {
        public List<IWord> Items { get; set; } = new List<IWord>();

        public int LineNumber { get; set; }

        public Sentence()
        {
        }

        public Sentence(IEnumerable<IWord> items)
        {
            foreach (Word item in items)
            {
                Items.Add(item);
            }
        }

        public TypeSentences typeSentence => Separators.EndPunctuationIsInterrogative.Contains(Items.Last().Chars)? TypeSentences.Interrogative : TypeSentences.Вeclarative;

        #region Operations

        public ISentence RemoveByWords(Func<IWord, bool> predicate)
        {
            return new Sentence(Items.Where(x => !(x is IWord && predicate(x))));
        }

        public IEnumerable<IWord> GetWords()
        {
            return Items.Where(x => x is IWord).Cast<IWord>();        
        }

        public IEnumerable<IWord> GetWords(int length)
        {
            return Items.Where(x => x is IWord).Cast<IWord>().Where(x => x.Symbols?.Count() == length);
        }

        public ISentence ReplaceWordInSentence(int length, string line, Func<string, ISentence> parseLine)
        {
            return new Sentence(ReplaceWord(x => x.Symbols?.Count() == length, parseLine(line).Items));
        }

        private IEnumerable<IWord> ReplaceWord(Func<IWord, bool> predicate, IEnumerable<IWord> items)
        {
            var newSentence = new List<IWord>();
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
