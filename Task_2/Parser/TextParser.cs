﻿using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task_2
{
    public class TextParser : Parser
    {
        public override Text Parse(StreamReader fileReader)
        {
            var textResult = new Text();
            string line;
            string buffer = null;
            byte lineNumber = 1;
            while ((line = fileReader.ReadLine()) != null)
            {
                lineNumber++;
                if (Regex.Replace(line.Trim(), @"\s+", @" ") != "")
                {
                    line = buffer + line;

                    var sentences = Separators.EnglishLettersRegex.Split(line)
                            .Select(x => Regex.Replace(x.Trim(), @"\s+", @" "))
                            .ToArray();

                    if (!Separators.EndPunctuation.Contains(sentences.Last().Last().ToString()))
                    {
                        buffer = sentences.Last();
                        if (textResult.Items != null)
                        {
                            textResult.Items.AddRange(sentences.Select(x => x).Where(x => x != sentences.Last()).Select(ParseSentence));
                        }
                        if (textResult.Items.Count() != 0)
                        {
                            textResult.Items.Last().LineNumber = lineNumber;
                        }
                    }
                    else
                    {
                        textResult.Items.AddRange(sentences.Select(ParseSentence));
                        if (textResult.Items.Count() != 0)
                        {
                            textResult.Items.Last().LineNumber = lineNumber;
                        }
                        buffer = null;
                    }
                }               
                }
            return textResult;
        }

        public override ISentence ParseSentence(string sentence)
        {
            var result = new Sentence();
            Func<string, ISentenceItem> toISentenceItem =
                item => new Word(item);

            foreach (Match match in Separators.SentenceToWordsRegex.Matches(sentence))
            {
                for (var i = 1; i < match.Groups.Count; i++)
                {
                    if (match.Groups[i].Value.Trim() != "")
                    {
                        result.Items.Add(toISentenceItem(match.Groups[i].Value.Trim()));
                    }
                }
            }

            return result;
        }
    }
}