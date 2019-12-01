
using System.IO;

namespace Task_2
{
    public abstract class Parser
    {
        public abstract Text Parse(StreamReader fileReader);

        public abstract ISentence ParseSentence(string sentence);
    }
}
