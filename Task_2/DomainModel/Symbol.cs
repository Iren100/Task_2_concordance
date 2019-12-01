
namespace Task_2
{
    public struct Symbol<T>
    {
        public T Characters { get; }

        public Symbol(T characters)
        {
            Characters = characters;
        }
    }
}
