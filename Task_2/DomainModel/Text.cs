using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_2
{
    public class Text: BaseCollection<ISentence>
    {
        public List<ISentence> Items { get; set; } = new List<ISentence>();

        #region Operations

        public IEnumerable<IWord> GetWordsFromInterrogativeSentences(int length)
        {
            var result = new List<IWord>();
            foreach (var sentence in Items.Where(sentence => sentence.typeSentence == TypeSentences.Interrogative))
            {
                result.AddRange(sentence.GetWords(length));
            }
            return result.GroupBy(x => x.Chars.ToLower()).Select(x => x.First()).ToList();
        }

        public void SentencesWithoutConsonants(int length)
        {
            Items = Items.Select(x => x.RemoveByWords(y => y.Symbols?.Count() == length && y.IsFirstСonsonant(Separators.Consonant))).ToList();
        }

        public IEnumerable<IWord> GetAllWords()
        {
            var result = new List<IWord>();
            foreach (var sentence in Items)
            {
                result.AddRange(sentence.GetWords());
            }

            return result.GroupBy(x => x.Chars.ToLower()).Select(x => x.First()).ToList();
        }

        public IEnumerable<Int32> GetAllWordsQuantity()
        {
            var result = new List<IWord>();
            foreach (var sentence in Items)
            {
                result.AddRange(sentence.GetWords());
            }
            return result.GroupBy(x => x.Chars.ToLower()).Select(x => x.Count()).ToList();          
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (ISentence sentence in Items)
            {
                sb.Append(sentence.ToString() + "\n");
            }
            return sb.ToString();
        }

        public Text Copy()
        {
            return (Text)this.MemberwiseClone();
        }

        #endregion
    }
}