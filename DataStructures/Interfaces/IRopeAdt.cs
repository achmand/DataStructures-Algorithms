using DataStructures.Trees;

namespace DataStructures.Interfaces
{
    public interface IRopeAdt
    {
        void Concat(RopeNode ropeA, RopeNode ropeB);
        char Index(int index);
    }
}
