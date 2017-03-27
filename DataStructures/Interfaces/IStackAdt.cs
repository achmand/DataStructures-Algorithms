namespace DataStructures.Interfaces
{
    public interface IStackAdt<T>
    {
        bool IsEmpty();
        int Size();
        void Push(T element);
        T Pop();
        T Peek();
    }
}
