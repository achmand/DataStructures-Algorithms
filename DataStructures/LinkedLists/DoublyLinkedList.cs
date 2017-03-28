using DataStructures.Interfaces;

namespace DataStructures.LinkedLists
{
    public class DoublyLinkedList<T> : IListAdt<T>
    {
        #region fields and properties

        // begining and an end marker 
        // we will have nodes (sentinal nodes)
        private Node<T> _head;
        private Node<T> _tail;
        private int _size;
        
        #endregion

        #region notes

        /* Note: "using these extra marker nodes will 
           remove a host of special cases. For instance 
           if we do not use a header node, then removing
           the first node becomes a special case, because 
           we must reset the list's link to the first node
           during remove, and also because the remove algorithm
           in general needs to access the node prior to the node 
           being removed (and without a header node, the first node
           does not have a node prior to it)"
         */

        #endregion

        #region ctors

        public DoublyLinkedList()
        {
            _head = new Node<T>();
            _tail = new Node<T>();
            _head.Next = _tail;
        }

        #endregion

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public int Size()
        {
            return _size;
        }

        public T ElementAtRank(int rank)
        {
            throw new System.NotImplementedException();
        }

        public T ReplaceAtRank(int rank, T obj)
        {
            throw new System.NotImplementedException();
        }

        public T RemoveAtRank(int rank)
        {
            throw new System.NotImplementedException();
        }

        public void InsertAtRank(int rank, T obj)
        {
            throw new System.NotImplementedException();
        }

        public bool IsFirst(Node<T> node)
        {
            throw new System.NotImplementedException();
        }

        public bool IsLast(Node<T> node)
        {
            throw new System.NotImplementedException();
        }

        public Node<T> NodeAtRank(int rank)
        {
            throw new System.NotImplementedException();
        }

        public Node<T> First()
        {
            throw new System.NotImplementedException();
        }

        public Node<T> Last()
        {
            throw new System.NotImplementedException();
        }

        public Node<T> PrevNode(Node<T> currNode)
        {
            throw new System.NotImplementedException();
        }

        public Node<T> NextNode(Node<T> currNode)
        {
            throw new System.NotImplementedException();
        }

        public T RemoveAfter(Node<T> currNode)
        {
            throw new System.NotImplementedException();
        }

        public T Remove(Node<T> currNode)
        {
            throw new System.NotImplementedException();
        }

        public T RemoveBefore(Node<T> currNode)
        {
            throw new System.NotImplementedException();
        }

        public void SwapElements(Node<T> currNode, Node<T> swapNode)
        {
            throw new System.NotImplementedException();
        }

        public void InsertFirst(T element)
        {
            throw new System.NotImplementedException();
        }

        public void InsertLast(T element)
        {
            throw new System.NotImplementedException();
        }

        public void InsertAfter(Node<T> currNode, T element)
        {
            throw new System.NotImplementedException();
        }

        public void InsertBefore(Node<T> currNode, T element)
        {
            throw new System.NotImplementedException();
        }
    }
}
