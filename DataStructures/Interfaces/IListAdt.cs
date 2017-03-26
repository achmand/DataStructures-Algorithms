using DataStructures.LinkedLists;

namespace DataStructures.Interfaces
{
    public interface IListAdt<T>
    {
        bool IsEmpty();
        int Size();
        T ElementAtRank();
        void InsertFirst(T element);
        void InsertAfter(Node<T> currNode, T element);
    }
}
