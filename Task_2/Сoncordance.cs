using System;

namespace Task_2
{
    public static class Сoncordance
    {
        public const int LENGTH = 40;
        private const string DELIMITER = "..............................................................";

        public static string printWord(string word)
        {
            word = String.Concat(word, DELIMITER);
            int maxLength = Math.Min(word.Length, LENGTH);
            string title = word.Substring(0, maxLength);
            title.Replace(" ", "P");

            return title;
        }      
    }
}
