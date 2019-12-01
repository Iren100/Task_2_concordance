
namespace Task_2
{
    public interface IWord: ISentenceItem
    {
        Symbol<char>[] Symbols { get; }

        byte LineNumber { get; set; }

        int Length { get; }

        bool IsFirstСonsonant(string[] vowels);
    }
}