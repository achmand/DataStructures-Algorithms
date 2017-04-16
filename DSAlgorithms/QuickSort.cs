using System;
using System.Collections.Generic;

namespace DSAlgorithms
{
    public enum QuickSortTypes
    {
        SortA,
        SortB,
        SortC
    }

    // Section 1 - P3.1
    // Time complexity -> Best: O(n log n), Avg: (n log n), Worst: O(n^2) 
    // Space complexity -> O(log n)
    // For more info visit: https://en.wikipedia.org/wiki/Quicksort
    public sealed class QuickSort
    {
        private const int InsertionSortSize = 16;

        // Quick sorts the array in asc order
        public void Sort(int[] array, QuickSortTypes quickSortType)
        {
            const int start = 0;
            var length = array.Length - 1;

            switch (quickSortType)
            {
                case QuickSortTypes.SortA:
                    SortA(array, start, length); // using the left most element as pivot
                    break;
                case QuickSortTypes.SortB:
                    SortB(array, 0, array.Length - 1); // using the median of three technique as pivot
                    break;
                case QuickSortTypes.SortC:
                    SortC(array, 0, array.Length - 1); // works just like the sort B but when the array size is less than 16 use the insertion sort
                    break;
            }
        }

        // A -> Deterministic quick-sort using the left-most element as pivot 
        // in this method we use recursion
        private static void SortA(IList<int> array, int left, int right)
        {
            while (true)
            {
                var pivot = array[left]; // using left most pivot
                var i = left;
                var j = right;

                Partition(array, pivot, ref i, ref j);

                if (left < j)
                {
                    SortA(array, left, j);
                }

                if (i < right)
                {
                    left = i;
                    continue;
                }

                break;
            }
        }

        // Partitioning
        private static void Partition(IList<int> array, int pivot, ref int left, ref int right)
        {
            while (left <= right)
            {
                while (array[left] < pivot)
                {
                    left++;
                }

                while (array[right] > pivot)
                {
                    right--;
                }

                if (left > right)
                {
                    continue;
                }

                Swap(array, left, right);
                left++;
                right--;
            }
        }

        // B -> Heuristic added -> using the median of three technique
        // in this method we use a while instead of recursion
        private static void SortB(IList<int> array, int left, int right)
        {
            while (true)
            {
                var pivot = GetMedianPivot(array, ref left, ref right);
                var i = left;
                var j = right;

                while (left <= right)
                {
                    while (array[left] < pivot)
                    {
                        left++;
                    }

                    while (array[right] > pivot)
                    {
                        right--;
                    }

                    if (left > right)
                    {
                        continue;
                    }

                    var tmp = array[left];
                    array[left] = array[right];
                    array[right] = tmp;

                    left++;
                    right--;
                }

                if (left < j)
                {
                    SortB(array, left, j);
                }

                if (i < right)
                {
                    left = i;
                    continue;
                }

                break;
            }
        }

        // B -> Heuristic added -> if array is less than 16 use insertion sort
        private static void SortC(IList<int> array, int left, int right)
        {
            var length = right + 1 - left;
            if (length < InsertionSortSize)
            {
                InsertionSort(array, left, right);
                return;
            }

            while (true)
            {
                var pivot = GetMedianPivot(array, ref left, ref right);
                var i = left;
                var j = right;

                while (left <= right)
                {
                    while (array[left] < pivot)
                    {
                        left++;
                    }

                    while (array[right] > pivot)
                    {
                        right--;
                    }

                    if (left > right)
                    {
                        continue;
                    }

                    var tmp = array[left];
                    array[left] = array[right];
                    array[right] = tmp;

                    left++;
                    right--;
                }

                if (left < j)
                {
                    SortC(array, left, j);
                }

                if (i < right)
                {
                    left = i;
                    continue;
                }

                break;
            }
        }

        // an implementation of insertion sort 
        // code taken from https://rosettacode.org/wiki
        private static void InsertionSort(IList<int> array, int first, int last)
        {
            for (var i = first + 1; i <= last; i++)
            {
                var entry = array[i];
                var j = i;
                while (j > first && array[j - 1].CompareTo(entry) > 0)
                {
                    array[j] = array[--j];
                }

                array[j] = entry;
            }
        }

        // Gets median pivot used in the B algorithm
        private static int GetMedianPivot(IList<int> array, ref int left, ref int right)
        {
            var middle = (left + right) / 2;
            var tmpArray = new[] { array[left], array[middle], array[right] };
            Array.Sort(tmpArray);

            var pivot = tmpArray[1];
            return pivot;
        }

        // Swap elements
        private static void Swap(IList<int> array, int first, int second)
        {
            if (first < 0 || second < 0 || first >= array.Count || second >= array.Count || first == second)
            {
                return;
            }

            var tmp = array[first];
            array[first] = array[second];
            array[second] = tmp;
        }
    }
}
