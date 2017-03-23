namespace DataStructures.ArrayBasedVector
{
    public sealed class SfArrayBasedVector<T> : ArrayBasedVector<T>
    {
        #region fields and properties 

        private bool _usingFirst;
        
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

        public void Append(T obj)
        {

        }

        public override T RemoveAtRank(int rank)
        {
            return default(T);
        }

        public override void InsertAtRank(int rank, T obj)
        {

        }
        #endregion 
    }
}
