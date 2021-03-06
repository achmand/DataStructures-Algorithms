﻿
using System;
using System.Collections.Generic;

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
        // time complexity: O(n2)
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

            return ansA / ansB;
        }

        #endregion

        #region collatz conjecture 

        // Collatz Conjecture (aka 3n + 1 conjecture) 
        // If n is even, divide it by 2 to get n / 2. If n is odd, multiply it by 3 and add 1 to obtain 3n + 1. 
        // Repeat the process indefinitely and no matter what number you start with you will end up with 1.
        // Parameter must be a postive integer
        // for more info: https://en.wikipedia.org/wiki/Collatz_conjecture 
        // https://xkcd.com/710/ :)

        /// <summary>
        /// 3n + 1 conjecture.
        /// </summary>
        /// <param name="number">Must be a positve integer.</param>
        /// <param name="array">Output of numbers until it reached 1.</param>
        public static void CollatzConjecture(int number, out List<int> array)
        {
            array = new List<int>();
            while (number > 1)
            {
                if (number % 2 == 0)
                {
                    number = number / 2;
                }
                else
                {
                    number = 3 * number + 1;
                    // because this always returns even
                    // the ans could be divided by 2 
                    // number = (3 * number + 1) / 2;
                }

                array.Add(number);
            }
        }

        #endregion
    }
}
