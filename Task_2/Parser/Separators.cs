using System.Text.RegularExpressions;
using System.Linq;

namespace Task_2
{
    public static class Separators
    {
        public static Regex EnglishLettersRegex = new Regex(
            @"(?<=[\.*!\?])\s+(?=\W*&([A-Z]))",
            RegexOptions.Compiled);

        public static Regex SentenceToWordsRegex = new Regex(
            @"(\W*)(\w+[\-|`]\w+)(\!\=|\>\=|\=\<|\/|\=\=|\?\!|\!\?|\.{3}|\W)|(\W*)(\w+|\d+)(\!\=|\>\=|\=\<|\/|\=\=|\?\!|\!\?|\.{3}|\W)|(.*)",
            RegexOptions.Compiled);

        public static string[] Numbers = { "1" , "2" , "3" , "4" , "5" , "6" , "7" , "8" , "9" };

        public static string[] Consonant = "bcdfghjklmnpqrstvwxz".ToCharArray().Select(e => e.ToString()).ToArray();

        public static string[] OpenPunctuation = { "<", "(", "[", "{", "„", "«", "‘" };

        public static string[] ClosePunctuation = { ")", ">", "]", "}", "“", "»", "’" };

        public static string[] EndPunctuation = { "!", ".", "?", "...", "?!", "!?" };

        public static string[] EndPunctuationIsInterrogative = { "?", "?!", "!?" };

        public static string[] RepeatPunctuation = { "\"" , "'" };

        public static string[] OperationPunctuation { get; } = { "*", "/", "+", "=", "==", "!=", ">=", "=<" };

        public static string[] InnerPunctuation { get; } = { ",", ";", ":" };

        public static string[] AllSentence = OpenPunctuation.Concat(OpenPunctuation).Concat(ClosePunctuation).
                                                Concat(EndPunctuation).Concat(EndPunctuationIsInterrogative).
                                                    Concat(RepeatPunctuation).Concat(OperationPunctuation).
                                                        Concat(InnerPunctuation).ToArray();

        public static string[] AllSentence2 = OpenPunctuation.Concat(EndPunctuation).Concat(OperationPunctuation).
                                               ToArray();

        public static string[] AllSentence4 = OpenPunctuation.Concat(ClosePunctuation).Concat(InnerPunctuation).
                                               Concat(EndPunctuation).Concat(OperationPunctuation).ToArray();
    }
}
