using DataStructures.Interfaces;

namespace DataStructures.Trees
{
    // for more information on this data structure visit:
    // https://en.wikipedia.org/wiki/Rope_(data_structure)
    // https://www.ibm.com/developerworks/library/j-ropes/
    // https://kukuruku.co/post/ropes-fast-strings/
    // A rope is a binary tree having leaf nodes that contain a short string. (highly efficient mutations)
    public sealed class RopeTree : IRopeAdt
    {
        #region Properties and variables

        private RopeNode _root;

        #endregion

        #region Ctors

        public RopeTree()
        {
            _root = new RopeNode();
        }

        #endregion

        #region Public methods

        // Time Complexity: O(1) (or O(log N) time to compute the root weight)
        public void Concat(RopeNode ropeA, RopeNode ropeB)
        {

        }

        // Time Complexity: O(Log N)
        public char Index(int index)
        {
            return Index(index, _root);
        }

        #endregion

        #region Private region

        /*
         For example, to find the character at i=10 in Figure 2.1 shown on the right,
         start at the root node (A), find that 22 is greater than 10 and there is a left child, 
         so go to the left child (B). 9 is less than 10, so subtract 9 from 10 (leaving i=1) 
         and go to the right child (D). Then because 6 is greater than 1 and there's a left child,
         go to the left child (G). 2 is greater than 1 and there's a left child, so go to the left child again (J).
         Finally 2 is greater than 1 but there is no left child, so the character at index 1 of the short string "na", is the answer.
         FIGURE URL: https://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Vector_Rope_index.svg/452px-Vector_Rope_index.svg.png
        */
        private static char Index(int index, RopeNode node)
        {
            while (true)
            {
                var weight = node.Weight;
                if (weight >= index)
                {
                    if (node.Left == null)
                    {
                        return node.Element[index];
                    }

                    node = node.Left;
                    continue;
                }

                index = index - weight;
                node = node.Right;
            }
        }

        #endregion
    }
}
