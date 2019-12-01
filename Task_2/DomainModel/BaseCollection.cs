using System.Collections.Generic;

namespace Task_2
{
    public interface BaseCollection<T> //where T : Symbol, IWord, ISentence
    {
        List<T> Items { get; set; }
    }
}
