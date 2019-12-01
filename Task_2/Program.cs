using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            const byte WORDLENGTH = 3;
            var parser = new TextParser();

            using (StreamReader streamReader = new StreamReader(ConfigurationSettings.AppSettings["file"], Encoding.Default))
            {
                Text text = parser.Parse(streamReader);

                print(1, "All sentences in increasing order of words:");
                foreach (var sentence in text.Items.OrderBy(x => x.Items.Count))
                {
                    Console.WriteLine(sentence.ToString());
                }


                print(2, "In interrogative sentences type without repeating words of a given length:");
                foreach (var word in text.GetWordsFromInterrogativeSentences(WORDLENGTH))
                {
                    Console.WriteLine(word.Symbols);
                }


                print(3, "Delete all words of a given length starting with a consonant from the text:");
                Text newText = text.Copy();
                newText.SentencesWithoutConsonants(WORDLENGTH);
                Console.WriteLine(newText.ToString());


                print(4, "In a certain sentence of the text, replace the words of a given length with the specified substring:");
                text.ReplaceWordInSentence(0, 4, "строка, с различными элементами", parser.ParseSentence);
                Console.WriteLine(text.ToString());


                print(5, "Corcordance:");
                var t1 = text.GetAllWords();
                var t2 = text.GetAllWordsQuantity();
                var t3 = text.GetLineNumbers();
                int j = 0;
                //write to file
                string fileName = "out.txt";
                FileStream file = new FileStream(fileName, FileMode.OpenOrCreate);
                using (StreamWriter sw = new StreamWriter(file))
                {
                    for (var i = 'A'; i <= 'Z'; i++)
                    {
                        j++;
                        Console.WriteLine(i);
                        Console.Write(Сoncordance.printWord(t1.ElementAt(j).Chars));
                        Console.Write(t2.ElementAt(j) + ":");
                        Console.WriteLine(" " + t3.ElementAt(j));

                        sw.WriteLine(i);
                        sw.Write(Сoncordance.printWord(t1.ElementAt(j).Chars));
                        sw.Write(t2.ElementAt(j) + ":");
                        sw.WriteLine(" " + t3.ElementAt(j));
                    }
                }

                Console.ReadLine();
            }
        }

        public static void print(byte number, string text)
        {
            Console.WriteLine();
            Console.WriteLine(number + " ........................................................................");
            Console.WriteLine(text);
            Console.WriteLine(number + " ........................................................................");
            Console.WriteLine();
        }
    }
}
