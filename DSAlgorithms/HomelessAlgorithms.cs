
using System;

namespace DSAlgorithms
{
    public static class HomelessAlgorithms
    {

        #region assignment 1 question

        public static int[] ComputeDifferenceArray(int[] array)
        {
            var computed = new int[array.Length];

            for (int i = 0; i < array.Length - 1; i++)
            {
                computed[i + 1] = array[i + 1] - array[i];
            }

            return computed;
        }

        // this for loop could be removed by setting the 
        // positive index when computing the array. -> ComputeDifferenceArray
        // i would suggest to have a datastructure for this. 
        public static int? FindIndexOfFirstPositive(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    return i;
                }
            }

            return null;
        }

        public static int MaxSubArrayDifference(int[] computed)
        {
            var firstPos = FindIndexOfFirstPositive(computed) ?? 0;
            var first = computed[firstPos] + computed[firstPos + 1];
            var max = first > 0 ? first : 0;

            for (int i = firstPos + 2; i < computed.Length; i++)
            {
                first += computed[i];
                if (first > 0)
                {
                    if (first > max)
                    {
                        max = first;
                    }
                }
                else
                {
                    first = computed[i];
                }
            }

            return max;
        }

        #endregion

        #region binomial coefficient

        // for more info: http://mathworld.wolfram.com/BinomialCoefficient.html
        // Equation: n!/(n-r)!r! -> Note: Combinations is when the order doesnt matter
        // n -> set of n numbers
        // r -> set of combinations
        // time complexity: O(n^2)
        public static int BinomialCoefficient(int n, int k)
        {
            if (n < k)
            {
                throw new ArgumentException("Incorrect inputs");
            }

            var x = n - k;
            var isSmaller = x < k;
            var sizeB = isSmaller ? k : x;

            // added this to be able to compute big numbers
            var ansA = 1;
            for (int i = n; i > sizeB; i--)
            {
                ansA *= i;
            }

            var sizeBInv = isSmaller ? x : k;
            var ansB = 1;
            for (int i = 1; i <= sizeBInv; i++)
            {
                ansB *= i;
            }

            return ansA/ansB;
        }

        #endregion
    }
}
