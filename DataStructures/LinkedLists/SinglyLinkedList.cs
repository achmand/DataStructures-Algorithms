using System;
using DataStructures.Interfaces;

namespace DataStructures.LinkedLists
{
    public class SinglyLinkedList<T> : IListAdt<T>
    {
        #region fields and properties

        // begining 
        // we will have nodes (sentinal nodes)
        protected Node<T> Head; // header node 

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
            Head = new Node<T>();
        }

        #endregion

        // time complexity: O(1)
        public bool IsEmpty()
        {
            return _size == 0;
        }

        // time complexity: O(1)
        public int Size()
        {
            return _size;
        }

        // time complexity: O(n)
        public Node<T> NodeAtRank(int rank)
        {
            if (rank < 0 || rank >= _size)
            {
                throw new IndexOutOfRangeException("Out of range");
            }

            var head = Head.Next;
            var c = rank;
            while (c > 0)
            {
                head = head.Next;
                c--;
            }

            return head;
        }

        // time complexity: O(n)
        public T ElementAtRank(int rank)
        {
            return NodeAtRank(rank).Element;
        }

        // time complexity: O(n)
        public T ReplaceAtRank(int rank, T element)
        {
            if (rank < 0 || rank >= _size)
            {
                throw new IndexOutOfRangeException("Out of range");
            }

            var replaceNode = NodeAtRank(rank);
            var returnValue = replaceNode.Element;
            replaceNode.Element = element;

            return returnValue;
        }

        // time complexity: O(n)
        // best case: O(1)
        // worst case: O(n)
        public T RemoveAtRank(int rank)
        {
            if (rank < 0 || rank >= _size)
            {
                throw new IndexOutOfRangeException("Out of range");
            }

            var head = Head.Next;
            var c = rank;
            while (c > 0)
            {
                head = head.Next;
                c--;
            }

            var returnValue = head.Element;
            if (head == Head.Next)
            {
                Head.Next = head.Next; // best case O(1)
                _size--;
            }
            else
            {
                Remove(head); // O(n)
            }

            return returnValue;
        }

        // time complexity: O(n)
        public void InsertAtRank(int rank, T obj)
        {
            if (rank < 0 || rank >= _size)
            {
                throw new IndexOutOfRangeException("Out of range");
            }

            if (rank == 0)
            {
                InsertFirst(obj); // best case O(1)
                return;
            }

            var newNode = new Node<T> { Element = obj };
            var prevNode = NodeAtRank(rank - 1); // worst case O(n)
            newNode.Next = prevNode.Next;
            prevNode.Next = newNode;

            _size++;
        }

        // time complexity: O(1)
        public bool IsFirst(Node<T> node)
        {
            if (IsEmpty())
            {
                throw new Exception("List is empty");
            }

            return First() == node;
        }

        // time complexity: O(n)
        public bool IsLast(Node<T> node)
        {
            if (IsEmpty())
            {
                throw new Exception("List is empty");
            }

            return Last() == node;
        }

        // time complexity: O(1)
        public Node<T> First()
        {
            if (IsEmpty())
            {
                throw new Exception("List is empty");
            }

            return Head.Next;
        }

        // time complexity: O(n)
        public Node<T> Last()
        {
            if (IsEmpty())
            {
                throw new Exception("List is empty");
            }

            var head = Head.Next;
            while (head.Next != null) // until the next is null,then we found the last node
            {
                head = head.Next;
            }

            return head;
        }

        // time complexity: O(n)
        public Node<T> PrevNode(Node<T> currNode)
        {
            if (currNode == null)
            {
                throw new Exception("Node is null");
            }

            var currentNode = Head.Next;
            while (currentNode != null)
            {
                if (currentNode.Next == currNode)
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }

            return null; // returns null if node does not exist
        }

        // time complexity O(1)
        public Node<T> NextNode(Node<T> currNode)
        {
            if (currNode?.Next == null)
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

        // time complexity: O(n)
        public T Remove(Node<T> currNode)
        {
            if (currNode == null)
            {
                throw new Exception("Cannot be null");
            }

            var element = currNode.Element;
            if (currNode == Head.Next)
            {
                Head.Next = currNode.Next; // best case: O(n)
                _size--;
            }
            else
            {
                var prevNode = PrevNode(currNode); // O(n)
                element = RemoveAfter(prevNode);
            }

            return element;
        }

        // O(n)
        public T RemoveBefore(Node<T> currNode)
        {
            if (currNode == null)
            {
                throw new Exception("Cannot be null");
            }

            var prevNode = PrevNode(currNode);
            if (prevNode == null)
            {
                throw new Exception("Node does not exist");
            }

            var returnValue = prevNode.Element;
            Remove(prevNode);
            return returnValue;
        }

        //// time complexity: O(n)
        //public void SwapNodes(Node<T> currNode, Node<T> swapNode)
        //{
        //    if (currNode == null || swapNode == null)
        //    {
        //        throw new Exception("Cannot be null");
        //    }

        //    var curNext = currNode.Next;
        //    currNode.Next = swapNode.Next;
        //    swapNode.Next = curNext;
        //}

        // time complexity: O(1)
        public void SwapElements(Node<T> currNode, Node<T> swapNode)
        {
            if (currNode == null || swapNode == null)
            {
                throw new Exception("Cannot be null");
            }

            var elementCur = currNode.Element;
            currNode.Element = swapNode.Element;
            swapNode.Element = elementCur;
        }

        // time complexity: O(1)
        public void InsertFirst(T element)
        {
            var node = new Node<T> { Element = element };
            var head = Head.Next;
            node.Next = head;
            Head.Next = node;
            _size++;
        }

        // time complexity: O(n)
        public void InsertLast(T element)
        {
            var head = Head.Next;
            if (Head.Next == null)
            {
                InsertFirst(element);
                return;
            }

            while (head.Next != null)
            {
                head = head.Next;
            }

            var newNode = new Node<T> { Element = element };
            head.Next = newNode;
            _size++;
        }

        // time complexity: O(1)
        public void InsertAfter(Node<T> currNode, T element)
        {
            if (currNode == null)
            {
                throw new Exception("Cannot be null");
            }

            var newNode = new Node<T> { Next = currNode.Next, Element = element };
            currNode.Next = newNode;
            _size++;
        }

        //time complexity: O(n)
        public void InsertBefore(Node<T> currNode, T element)
        {
            if (currNode == null)
            {
                throw new Exception("Cannot be null");
            }

            if (currNode == Head.Next)
            {
                InsertFirst(element); // best case: O(1)
            }

            var newNode = new Node<T>
            {
                Element = element,
                Next = currNode
            };

            var previousNode = PrevNode(currNode);
            previousNode.Next = newNode;
            _size++;
        }
    }
}
