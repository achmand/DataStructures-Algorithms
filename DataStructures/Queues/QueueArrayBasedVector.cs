using System;
using DataStructures.ArrayBasedVector;
using DataStructures.Interfaces;

namespace DataStructures.Queues
{
    public class QueueArrayBasedVector<T> : IQueueAdt<T>
    {
        #region fields and properties 

        private readonly IVectorAdt<T> _vectorAdt = new ArrayBasedVector<T>();

        #endregion
        
        // time complexity: O(1)
        public bool IsEmpty()
        {
            return _vectorAdt.IsEmpty();
        }

        // time complexity: O(1)
        public int Size()
        {
            return _vectorAdt.Size();
        }

        // time complexity: O(1)
        public void Enqueue(T element)
        {
            _vectorAdt.InsertAtRank(_vectorAdt.Size(), element);
        }

        // time complexity: O(n)
        public T Dequeue()
        {
            if (_vectorAdt.IsEmpty())
            {
                throw new Exception("Queue is empty");
            }

            return _vectorAdt.RemoveAtRank(0);
        }

        // Time complexity: O(1)
        public T Peek()
        {
            if (_vectorAdt.IsEmpty())
            {
                throw new Exception("Queue is empty");
            }

            return _vectorAdt.ElementAtRank(0);
        }
    }
}
