using System;
using System.Collections.Generic;
using DataStructures.Interfaces;

namespace DataStructures.Stacks
{
    // Implementing a stack using two queues 
    public sealed class StackQueues<T> : IStackAdt<T>
    {
        #region fields and properties

        private bool _isA;
        private int _size;
        private readonly Queue<T> _queueA;
        private readonly Queue<T> _queueB;

        #endregion

        #region ctors

        public StackQueues()
        {
            _isA = true;
            _size = 0;
            _queueA = new Queue<T>();
            _queueB = new Queue<T>();
        }

        #endregion

        #region public methods

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

        // time complexity: O(N)
        public void Push(T element)
        {
            var tmpA = _isA ? _queueA : _queueB;
            var tmpB = !_isA ? _queueA : _queueB;

            tmpA.Enqueue(element);
            while (tmpB.Count > 0)
            {
                var tmp = tmpB.Dequeue();
                tmpA.Enqueue(tmp);
            }

            _isA = !_isA;
            _size++;
        }

        // time complexity: O(1)
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("Stack is empty");
            }

            var value = !_isA ? _queueA.Dequeue() : _queueB.Dequeue();
            _size--;
            return value;
        }

        // time complexity: O(1)
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("Stack is empty");
            }

            var value = _isA ? _queueA.Peek() : _queueB.Peek();
            return value;
        }

        #endregion
    }
}
