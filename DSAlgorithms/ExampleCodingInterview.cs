using System;
using System.Linq;

namespace DSAlgorithms
{
    // Problem taken from "Work at Google — Example Coding/Engineering Interview"
    // https://www.youtube.com/watch?v=XKu_SEDAykw

    public sealed class ExampleCodingInterview
    {
        // A: You have a collection of numbers, find a matching pair that is equal to the sum of the parameter
        // Example for sum = 8, A = [1 , 2 , 3 , 9] , B = [1 , 2 , 4 , 4] , Case A -> No pair | Case B -> True '4 & 4'
        // Assume they are ordered in ascending order , are integer with both negative and positive 

        // List must be sorted
        // This function computes all the numbers 
        // Checks if each sum matches the matching number (not very efficient -> Quadratic)
        // Time complexity: O(n^2)
        public bool HasPairWithSum_1(int[] collection, int matchingNumber)
        {
            var len = collection.Length;
            for (int i = 0; i < len; i++)
            {
                var tmpA = collection[i];
                for (int j = i; j < len - 1; j++)
                {
                    var tmpB = collection[j + 1];
                    var result = tmpA + tmpB;
                    if (result == matchingNumber)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // List must be sorted | Using binary search to search for a complement
        // Binary search a 'uni directional' solution is a log algorithm in a sorted list (For finding)
        // This solution becomes a n_log_n as you need to do the binary search for each number
        // For more info about 'Array.BinarySearch' https://msdn.microsoft.com/en-us/library/2cy9f6wb(v=vs.110).aspx
        // Time Complexity: O(n_log_n)
        public bool HasPairWithSum_2(int[] collection, int matchingNumber)
        {
            for (int i = 0; i < collection.Length - 1; i++)
            {
                var tmpA = collection[i];
                var complement = matchingNumber - tmpA;
                var collectionShrink = collection.Skip(i + 1).ToArray();

                var found = Array.BinarySearch(collectionShrink, complement);
                if (found >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        // List must be sorted | Using ranges, and going bi directional, once the ranges cross no pair was found
        // This is more efficient than the previous solution as this becomes a linear solution
        // Time Complexity: O(n)
        public bool HasPairWithSum_3(int[] collection, int matchingNumber)
        {
            var rangeMax = collection.Length - 1;
            var rangeLow = 0;

            while (true)
            {
                if (rangeLow == rangeMax)
                {
                    return false;
                }

                var sumRange = collection[rangeLow] + collection[rangeMax];
                if (sumRange == matchingNumber)
                {
                    return true;
                }
                if (sumRange < matchingNumber)
                {
                    rangeLow ++;
                }
                else 
                {
                    rangeMax --;
                }
            }
        }

        /// <summary>
        /// This time the collection of numbers is not sorted 
        /// </summary>
        /// <returns></returns>
        public bool HasPairWithSum_4()
        {
            return false;
        }
    }
}
