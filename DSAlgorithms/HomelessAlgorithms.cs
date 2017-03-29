
namespace DSAlgorithms
{
    public static class HomelessAlgorithms
    {
        public static int[] ComputeDifferenceArray(int[] array)
        {
            var computed = new int[array.Length];

            for (int i = 0; i < array.Length - 1; i++)
            {
                computed[i + 1] = array[i + 1] - array[i];
            }

            return computed;
        }

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

        public static int Profits(int[] array)
        {
            int stockDifference = 0;
            int total = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                stockDifference = array[i + 1] - array[i];
                if (stockDifference > 0)
                {
                    total += stockDifference;
                }
                else if(stockDifference < 0)
                {
                    if (total - stockDifference < 0)
                    {
                        total = 0;
                    }
                    else
                    {
                        total -= stockDifference;
                    }
                }
            }

            return total;
        }
    }
}
