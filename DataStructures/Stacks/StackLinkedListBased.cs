using System.Collections.Generic;
using DataStructures.Interfaces;

namespace DataStructures.Stacks
{
    public class StackLinkedListBased<T> : IStackAdt<T>
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

        public void Push(T element)
        {
            _linkedList.AddFirst(element);
        }

        public T Pop()
        {
            var returnValue = _linkedList.First.Value;
            _linkedList.RemoveFirst();
            return returnValue;
        }

        public T Peek()
        {
            return _linkedList.First.Value;
        }
    }
}
