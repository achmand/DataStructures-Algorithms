namespace ConsoleApp
{
    /// <summary>
    /// AmortisedAnalysisExercises
    /// </summary>
    public static class AmortizedAnalysisWs
    {
        /// <summary>
        /// Exercise one find the number of operations needed to change from one binary to the other. (Assuming the numbers are of the same size)
        /// </summary>
        /// <param name="binaryNumberA"></param>
        /// <param name="binaryNumberB"></param>
        /// <returns></returns>
        public static int? BinaryChangeCounter(string binaryNumberA, string binaryNumberB)
        {
            if (string.IsNullOrEmpty(binaryNumberA) || string.IsNullOrEmpty(binaryNumberB) || (binaryNumberA.Length != binaryNumberB.Length))
            {
                return null; // Not computable 
            }

            if (binaryNumberA == binaryNumberB) // Same binary number 
            {
                return 0; // Best case both numbers are the same no operations 
            }

            var count = 0;
            for (int i = 0; i < binaryNumberA.Length; i++)
            {
                var n1 = binaryNumberA[i];
                var n2 = binaryNumberB[i];

                if (n1 != n2)
                {
                    count ++;
                }
            }

            return count;
        }

    }
}
