using DataStructures.LinkedLists;

namespace DataStructures.Interfaces
{
    public interface IListAdt<T>
    {
        // generic methods 
        int Size();
        bool IsEmpty();

        // query methods
        void IsFirst(Node<T> node);
        void IsLast(Node<T> node);

        // accessor methods
        T ElementAtRank(int rank);
        Node<T> NodeAtRank(int rank);
        Node<T> First();
        Node<T> Last();
        Node<T> PrevNode(Node<T> currNode);
        Node<T> NextNode(Node<T> currNode);

        // update methods 
        T RemoveAtRank(int rank);
        T RemoveAfter(Node<T> currNode, T element);
        T RemoveBefore(Node<T> currNode, T element);
        T ReplaceAtRank(int rank, T element);

        void InsertFirst(T element);
        void InsertAfter(Node<T> currNode, T element);
    }
}
