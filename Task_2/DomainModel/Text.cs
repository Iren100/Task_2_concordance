﻿using System;
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
            foreach (var sentence in Items.Where(sentence => sentence.IsInterrogative))
            {
                result.AddRange(sentence.GetWords(length));
            }
            return result.GroupBy(x => x.Chars.ToLower()).Select(x => x.First()).ToList();
        }

        public void SentencesWithoutConsonants(int length)
        {
            Items = Items.Select(x => x.RemoveByWords(y => y.Length == length && y.IsFirstСonsonant(Separators.Consonant))).ToList();
        }

        public void ReplaceWordInSentence(int index, int length, IList<ISentenceItem> elements)
        {
            Items[index] = new Sentence(Items[index].ReplaceWord((x => x.Length == length), elements));
        }

        public void ReplaceWordInSentence(int index, int length, string line, Func<string, ISentence> parseLine)
        {
            Items[index] = new Sentence(Items[index].ReplaceWord((x => x.Length == length), parseLine(line).Items));
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

        public IEnumerable<byte> GetLineNumbers()
        {
            var result = new List<byte>();
            foreach (var sentence in Items)
            {
                result.AddRange(sentence.GetLines());
            }
            return result;
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