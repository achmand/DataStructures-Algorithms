using DataStructures.ArrayBasedVector;
using DataStructures.Interfaces;

namespace DataStructures.Stacks
{
    public sealed class StackArrayBasedVector<T> : IStackAdt<T>
    {
        #region fields and properties 

        private readonly IVectorAdt<T> _vectorAdt = new ArrayBasedVector<T>();

        #endregion

        #region public methods

        public bool IsEmpty()
        {
            return _vectorAdt.IsEmpty();
        }

        public int Size()
        {
            return _vectorAdt.Size();
        }

        public void Push(T element)
        {
            _vectorAdt.InsertAtRank(_vectorAdt.Size(), element);
        }

        public T Pop()
        {
            return _vectorAdt.RemoveAtRank(_vectorAdt.Size() - 1);
        }

        public T Peek()
        {
            return _vectorAdt.ElementAtRank(_vectorAdt.Size() - 1);
        }

        #endregion
    }
}
