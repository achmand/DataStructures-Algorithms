using DataStructures.LinkedLists;

namespace DataStructures.Interfaces
{
    public interface IListAdt<T> : IVectorAdt<T>
    {
        // query methods
        bool IsFirst(Node<T> node);
        bool IsLast(Node<T> node);

        // accessor methods
        Node<T> NodeAtRank(int rank);
        Node<T> First();
        Node<T> Last();
        Node<T> PrevNode(Node<T> currNode);
        Node<T> NextNode(Node<T> currNode);

        // update methods 
        T RemoveAfter(Node<T> currNode);
        T Remove(Node<T> currNode);
        T RemoveBefore(Node<T> currNode);

        //void SwapNodes(Node<T> currNode, Node<T> swapNode);
        void SwapElements(Node<T> currNode, Node<T> swapNode);
        void InsertFirst(T element);
        void InsertLast(T element);
        void InsertAfter(Node<T> currNode, T element);
        void InsertBefore(Node<T> currNode, T element);
    }
}
