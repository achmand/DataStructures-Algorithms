namespace DataStructures.Trees
{
    public sealed class RopeNode
    {
        #region Properties and variables

        public string Element { get; set; }
        public RopeNode Left { get; set; }
        public RopeNode Right { get; set; }
        public int Weight { get; set; }

        #endregion

        #region Ctors

        public RopeNode()
        {
            
        }

        public RopeNode(string element, RopeNode left, RopeNode right, int weight)
        {
            Element = element;
            Left = left;
            Right = right;
            Weight = weight;
        }

        #endregion
    }
}
