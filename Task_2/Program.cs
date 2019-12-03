using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Generic;

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
                    Console.WriteLine(word.Chars);
                }


                print(3, "Delete all words of a given length starting with a consonant from the text:");
                Text newText = text.Copy();
                newText.SentencesWithoutConsonants(WORDLENGTH);
                Console.WriteLine(newText.ToString());


                print(4, "In a certain sentence of the text, replace the words of a given length with the specified substring:");
                text.Items[0] = text.Items[0].ReplaceWordInSentence(5, "**Substring**", parser.ParseSentence);
                Console.WriteLine(text.Items[0].ToString());


                print(5, "Corcordance:");
                IEnumerable<IWord> t1 = text.GetAllWords().OrderBy(y => y.Chars).ToList();
                var t2 = text.GetAllWordsQuantity();
                int j = 0;

                //write to file
                FileStream file = new FileStream("out.txt", FileMode.OpenOrCreate);
                using (StreamWriter sw = new StreamWriter(file))
                {
                    for (var i = 'A'; i <= 'Z'; i++)
                    {
                        Console.WriteLine(i);
                        for (var ii = j; ii < t1.Count();ii++)
                        {
                            if (i.ToString() == t1.ElementAt(ii).Chars.ToUpper().First().ToString())
                            {
                                Console.Write(Сoncordance.printWord(t1.ElementAt(ii).Chars));
                                Console.Write(t2.ElementAt(ii) + ":");
                                if (t1.ElementAt(ii).LineNumber.Count > 0)
                                    Console.WriteLine(" " + t1.ElementAt(ii).LineNumber?.First());
                                else
                                    Console.WriteLine();
                                sw.WriteLine(i);
                                sw.Write(Сoncordance.printWord(t1.ElementAt(ii).Chars));
                                sw.Write(t2.ElementAt(ii) + ":");
                                if (t1.ElementAt(ii).LineNumber.Count > 0)
                                    sw.WriteLine(" " + t1.ElementAt(ii).LineNumber.First());
                                else
                                    Console.WriteLine();
                                j = ii;
                            }
                        }
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
