namespace DataStructures.Interfaces
{
    public interface IVectorAdt<T>
    {
        bool IsEmpty();
        int Size();
        T ElementAtRank(int rank);
        T ReplaceAtRank(int rank, T obj);
        T RemoveAtRank(int rank);
        void InsertAtRank(int rank, T obj);
    }
}
