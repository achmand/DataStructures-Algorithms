using System;
using DataStructures.Interfaces;

namespace DataStructures.ArrayBasedVector
{
    /// <summary>
    /// standard array based vector.
    /// </summary>
    /// <typeparam name="T">Vector Type</typeparam>
    public class ArrayBasedVector<T> : IVectorAdt<T>
    {
        #region fields and properties 

        private int _size;

        protected int ElmntsCount
        {
            get { return _size; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Vector size less than 0");
                }
                _size = value;
            }
        }

        protected T[] ElementArray;

        #endregion

        #region ctors 

        public ArrayBasedVector() : this(8)
        {
        }

        public ArrayBasedVector(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than 0");
            }

            ElementArray = new T[capacity];
        }

        #endregion

        #region public methods

        // time-complexity: O(1) 
        public bool IsEmpty() => ElmntsCount == 0;

        // time-complexity: O(1) 
        public int Size() => ElmntsCount;

        // time-complexity: O(1)
        public virtual T ElementAtRank(int rank)
        {
            if (rank < 0 || rank >= ElmntsCount)
            {
                throw new ArgumentException("Out of range");
            }

            return ElementArray[rank];
        }

        // time-complexity: O(1) 
        public T ReplaceAtRank(int rank, T obj)
        {
            if (rank >= ElmntsCount || rank < 0)
            {
                throw new ArgumentException("Out of range");
            }

            var tmp = ElementArray[rank];
            ElementArray[rank] = obj;
            return tmp;
        }

        // time-complexity: O(n) | worst case rank is 0 
        public virtual T RemoveAtRank(int rank)
        {
            if (rank >= ElmntsCount || rank < 0)
            {
                throw new ArgumentException("Out of Range");
            }

            var tmpObj = ElementArray[rank];
            for (var i = rank; i < ElmntsCount - 1; i++)
            {
                ElementArray[i] = ElementArray[i + i];
            }

            ElementArray[ElmntsCount] = default(T);
            ElmntsCount--;
            return tmpObj;
        }

        // time-complexity: O(n) 
        public virtual void InsertAtRank(int rank, T obj)
        {
            if (rank > ElmntsCount || rank < 0)
            {
                throw new ArgumentException("Out of Range");
            }

            if (ElmntsCount == ElementArray.Length)
            {
                var vNew = new T[ElmntsCount * 2];
                for (var i = 0; i < ElmntsCount; i++)
                {
                    vNew[i] = ElementArray[i];
                }

                ElementArray = vNew;
            }

            for (var i = ElmntsCount - 1; i >= rank; i--)
            {
                ElementArray[i + 1] = ElementArray[i];
            }

            ElementArray[rank] = obj;
            ElmntsCount++;

            // THE IMPLEMENTATION BELOW DOES THE ARRAY GROWTH AND COPYING IN ONE LOOP

            //var willGrow = ElmntsCount == ElementArray.Length;
            //if (!willGrow)
            //{
            //    for (var i = ElmntsCount - 1; i >= rank; i--)
            //    {
            //        ElementArray[i + 1] = ElementArray[i];
            //    }
            //}
            //else
            //{
            //    var vNew = new T[ElmntsCount * 2];
            //    var x = 0;
            //    for (var i = 0; i < ElmntsCount + 1; i++)
            //    {
            //        if (rank != i)
            //        {
            //            vNew[i] = ElementArray[x];
            //            x++;
            //            continue;
            //        }
            //        vNew[i] = obj;
            //    }

            //    ElementArray = vNew;
            //}
        }
        #endregion
    }
}
