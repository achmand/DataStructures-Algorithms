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

    // Three types of quick sorts 

    // TODO : ADD RANDOM POINTER SORT  
    // TODO : ADD LR POINTER SORT 

    // Time complexity -> Best: O(n log n), Avg: (n log n), Worst: O(n^2) 
    // Space complexity -> O(log n)
    // For more info visit: https://en.wikipedia.org/wiki/Quicksort
    public sealed class QuickSort
    {
        // Quick sorts the array in asc order
        public void Sort(int[] array, QuickSortTypes quickSortType)
        {
            switch (quickSortType)
            {
                case QuickSortTypes.SortA:
                    SortA(array, 0, array.Length - 1); // using the left most element as pivot
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
        private static void SortA(IList<int> array, int left, int right)
        {
            while (true)
            {
                var pivot = array[left]; // using left most pivot
                var i = left;
                var j = right;

                while (i <= j)
                {
                    while (array[i] < pivot)
                    {
                        i++;
                    }

                    while (array[j] > pivot)
                    {
                        j--;
                    }

                    if (i > j)
                    {
                        continue;
                    }

                    Swap(array, i, j);
                    i++;
                    j--;
                }

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

        // B -> Heuristic added -> using the median of three technique
        private static void SortB(IList<int> array, int left, int right)
        {
            while (true)
            {
                var pivot = GetMedianPivot(array, left, right); // using median as pivot 
                var i = left;
                var j = right;

                while (i <= j)
                {
                    while (array[i] < pivot)
                    {
                        i++;
                    }

                    while (array[j] > pivot)
                    {
                        j--;
                    }

                    if (i > j)
                    {
                        continue;
                    }

                    Swap(array, i, j);
                    i++;
                    j--;
                }

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

        // B -> Heuristic added -> if array is less than 16 use insertion sort
        private static void SortC(IList<int> array, int left, int right)
        {
            if (array.Count < 16)
            {
                InsertionSort(array, array.Count);
                return;
            }

            while (true)
            {
                var pivot = GetMedianPivot(array, left, right); // using median as pivot 
                var i = left;
                var j = right;

                while (i <= j)
                {
                    while (array[i] < pivot)
                    {
                        i++;
                    }

                    while (array[j] > pivot)
                    {
                        j--;
                    }

                    if (i > j)
                    {
                        continue;
                    }

                    Swap(array, i, j);
                    i++;
                    j--;
                }

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

        // An implementation of insertion sort 
        private static void InsertionSort(IList<int> array, int n)
        {
            for (int i = 1; i < n; i++)
            {
                var k = array[i];
                var j = i - 1;

                while (j >= 0 && array[j] > k)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }

                array[j + 1] = k;
            }
        }

        // Gets median pivot used in the B algorithm
        private static int GetMedianPivot(IList<int> array, int left, int right)
        {
            var middle = (left + right) / 2;
            var arrayLen = array.Count - 1;

            var tmpArray = new[] { array[0], array[middle], array[arrayLen] };
            Array.Sort(tmpArray);

            var pivot = tmpArray[1];
            return pivot;
        }

        // Swap elements
        private static void Swap(IList<int> array, int first, int second)
        {
            if (first < 0 || second < 0 || first >= array.Count || second >= array.Count)
            {
                return;
            }

            var tmp = array[first];
            array[first] = array[second];
            array[second] = tmp;
        }
    }
}
