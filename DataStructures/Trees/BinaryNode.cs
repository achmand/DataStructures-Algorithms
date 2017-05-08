namespace DataStructures.Trees
{
    public class BinaryNode<T>
    {
        #region Properties and variables

        public T Element { get; set; }
        public BinaryNode<T> Left { get; set; }
        public BinaryNode<T> Right { get; set; }

        #endregion

        #region Ctors

        public BinaryNode()
        {
        }

        public BinaryNode(T element, BinaryNode<T> left, BinaryNode<T> right)
        {
            Element = element;
            Left = left;
            Right = right;
        }

        #endregion
    }
}
