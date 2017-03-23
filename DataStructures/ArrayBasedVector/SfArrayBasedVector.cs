using System;

namespace DataStructures.ArrayBasedVector
{
    public sealed class SfArrayBasedVector<T> : ArrayBasedVector<T>
    {
        #region fields and properties 

        private int _offset;

        #endregion

        #region ctors 

        public SfArrayBasedVector() : base(8)
        {

        }

        public SfArrayBasedVector(int capacity) : base(capacity)
        {

        }

        #endregion

        #region public methods

        // time complexity: O(1) without array growth
        public void Append(T obj)
        {
            InsertLast(obj);
        }

        // time-complexity: O(1)
        public override T ElementAtRank(int rank)
        {
            var index = rank >= _offset ? rank - _offset : rank + _offset;
            return ElementArray[index];
        }

        // time complexity: O(1) without array growth
        public void InsertFirst(T obj)
        {
            if (ElmntsCount > 0)
            {
                var index = ElementArray.Length - 1 - _offset;
                InsertElement(index, obj);
                _offset++;
                return;
            }

            InsertElement(ElmntsCount, obj);
        }

        // time complexity: O(1) without array growth
        public void InsertLast(T obj)
        {
            InsertElement(ElmntsCount - _offset, obj);
        }

        public override void InsertAtRank(int rank, T obj)
        {
            if (rank >= ElmntsCount || rank < 0) // for last use append or insert last (ONLY INSERT AT EXISTING RANKS)
            {
                throw new ArgumentException("Out of Range");
            }

            if (rank == 0)
            {
                InsertFirst(obj);
                return;
            }

            if (ElmntsCount == ElementArray.Length)
            {
                ArrayGrowth();
            }

            var mpRank = _offset + rank % ElementArray.Length;
            for (var i = ElmntsCount - _offset; i <= mpRank; i--)
            {
                ElementArray[i] = ElementArray[i - 1];
            }

            ElementArray[mpRank] = obj;
            ElmntsCount++;
        }

        private void InsertElement(int index, T obj)
        {
            if (ElmntsCount == ElementArray.Length)
            {
                index = index == ElmntsCount - _offset ? ElmntsCount : ElementArray.Length - 1 - _offset;
                ArrayGrowth();
            }

            ElementArray[index] = obj;
            ElmntsCount++;
        }

        private void ArrayGrowth()
        {
            var vNew = new T[ElmntsCount * 2];
            for (var i = 0; i < ElmntsCount; i++)
            {
                var mappedRank = _offset + i % ElementArray.Length;
                vNew[i] = ElementArray[mappedRank];
            }

            _offset = 0;
            ElementArray = vNew;
        }

        public T RemoveFirst()
        {
            return default(T);
        }

        public T RemoveLast()
        {
            return default(T);
        }

        public override T RemoveAtRank(int rank)
        {
            return default(T);
        }

        #endregion 
    }
}
