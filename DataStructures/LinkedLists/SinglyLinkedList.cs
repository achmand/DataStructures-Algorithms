using System;
using System.CodeDom;
using DataStructures.Interfaces;

namespace DataStructures.LinkedLists
{
    public class SinglyLinkedList<T> : IListAdt<T>
    {
        #region fields and properties

        // begining and an end marker 
        // we will have nodes (sentinal nodes)
        private Node<T> _head; // header node

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

        private int _size;

        #endregion

        #region ctors 

        public SinglyLinkedList()
        {

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
            if (rank < 0 || rank >= _size)
            {
                throw new ArgumentException("Out of range");
            }

            var head = _head.Next;
            var c = rank;
            while (c > 0)
            {
                head = head.Next;
                c--;
            }

            return head.Element;
        }

        public T ReplaceAtRank(int rank, T obj)
        {
            throw new NotImplementedException();
        }

        public T RemoveAtRank(int rank)
        {
            throw new NotImplementedException();
        }

        public void InsertAtRank(int rank, T obj)
        {
            throw new NotImplementedException();
        }

        public void IsFirst(Node<T> node)
        {
            throw new NotImplementedException();
        }

        public void IsLast(Node<T> node)
        {
            throw new NotImplementedException();
        }

        public Node<T> NodeAtRank(int rank)
        {
            if (rank < 0 || rank >= _size)
            {
                throw new ArgumentException("Out of range");
            }


        }

        // time complexity: O(1)
        public Node<T> First()
        {
            if (_head.Next == null)
            {
                throw new Exception("List is empty");
            }

            return _head.Next;
        }

        public Node<T> Last()
        {
            throw new NotImplementedException();
        }

        public Node<T> PrevNode(Node<T> currNode)
        {
            throw new NotImplementedException();
        }

        public Node<T> NextNode(Node<T> currNode)
        {
            if (currNode?.Next == null) // checks for currNode and next node  
            {
                throw new Exception("Node is null");
            }

            return currNode.Next;
        }

        // time complexity: O(1)
        public T RemoveAfter(Node<T> currNode)
        {
            if (currNode?.Next == null)
            {
                throw new Exception("Cannot be null");
            }

            var removeNode = currNode.Next;
            var value = removeNode.Element;
            currNode.Next = currNode.Next.Next;
            removeNode.Next = null;

            _size--;
            return value;
        }

        public T RemoveBefore(Node<T> currNode)
        {
            throw new NotImplementedException();
        }

        // time complexity: O(1)
        public void SwapElements(Node<T> currNode, Node<T> swapNode)
        {
            if (currNode == null || swapNode == null)
            {
                throw new Exception("Cannot be null");
            }

            var curNext = currNode.Next;
            currNode.Next = swapNode.Next;
            swapNode.Next = curNext;
        }

        public void InsertFirst(T element)
        {
            throw new NotImplementedException();
        }

        public void InsertLast(T element)
        {
            throw new NotImplementedException();
        }

        // time complexity : O(1)
        public void InsertAfter(Node<T> currNode, T element)
        {
            if (currNode == null)
            {
                throw new Exception("Cannot be null");
            }

            var newNode = new Node<T> { Next = currNode.Next };
            currNode.Next = newNode;
            _size++;
        }

        public void InsertBefore(Node<T> currNode, T element)
        {
            if (currNode == null)
            {
                throw new Exception("Cannot be null");
            }
        }
    }
}
