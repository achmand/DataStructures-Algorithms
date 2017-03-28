using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Interfaces;

namespace DataStructures.Queues
{
    public class QueueLinkedListBased<T> : IQueueAdt<T>
    {
        private readonly LinkedList<T> _linkedList = new LinkedList<T>();

        public bool IsEmpty()
        {
            return _linkedList.Count == 0;
        }

        public int Size()
        {
            return _linkedList.Count;
        }

        public void Enqueue(T element)
        {
            _linkedList.AddFirst(element);
        }

        public T Dequeue()
        {
            if (!_linkedList.Any())
            {
                throw new Exception("Emtpy");
            }

            var returnValue = _linkedList.Last.Value;
            _linkedList.RemoveLast();
            return returnValue;
        }

        public T Peek()
        {
            if (!_linkedList.Any())
            {
                throw new Exception("Emtpy");
            }

            return _linkedList.First.Value;
        }
    }
}
