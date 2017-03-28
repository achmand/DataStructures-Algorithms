namespace DataStructures.Interfaces
{
    public interface IQueueAdt<T> 
    {
        bool IsEmpty();
        int Size();
        void Enqueue(T element);
        T Dequeue();
        T Peek();
    }
}
