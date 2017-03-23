using System;
using System.Linq;

namespace DSAlgorithms
{
    // http://mathworld.wolfram.com/YoungTableau.html
    // https://www.youtube.com/watch?v=vgZhrEs4tuk

    // TODO -> Cancel out multipliers as the number can get big and reset object method
    public sealed class StandardYoungTableau
    {
        private readonly int[][] _shape;

        private readonly int[] _factorial;
        private readonly int[] _hookNumbers;

        public StandardYoungTableau(int rows, int[] cols)
        {
            var checkShape = ValidateShape(rows, cols);
            if (checkShape == false)
            {
                throw new Exception("Please input a correct shape.");
            }

            _shape = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                _shape[i] = new int[cols[i]];
            }

            var cellSize = cols.Sum();

            _factorial = new int[cellSize];
            _hookNumbers = new int[cellSize];

            var counter = 0;
            for (int i = _factorial.Length; i > 0; i--)
            {
                _factorial[counter] = i;
                counter++;
            }
        }

        /// <summary>
        /// Calculates the total number of standard young tableau, !N/product_of_hook_numbers
        /// </summary>
        /// <returns></returns>
        public int CalculateTotalSyt()
        {
            ComputeHookNumbers();

            // TODO -> Fix this and try to cancel up multipliers 
            var sumFact = _factorial.Aggregate(1, (a, b) => a * b);
            var sumHook = _hookNumbers.Aggregate(1, (a, b) => a * b);
            var result = sumFact/sumHook;

            return result;
        }

        private void ComputeHookNumbers()
        {
            var shapelen = _shape.Length;
            var count = 0;
            for (int i = 0; i < _shape.Length; i++)
            {
                var innerArray = _shape[i];
                var innerLen = innerArray.Length;
          
                for (int j = innerLen; j > 0; j--)
                {
                    var tmpCount = shapelen + j - 1;
                    _hookNumbers[count] = tmpCount;
                    count++;
                }

                shapelen--;
            }
        }

        /// <summary>
        /// Validates the tableau
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static bool ValidateShape(int rows, int[] cols)
        {
            if (rows != cols.Length)
            {
                return false;
            }

            var tmpCheck = 0;
            for (int i = 0; i < cols.Length; i++)
            {
                var tmp = cols[i];
                if (tmp == 0)
                {
                    return false;
                }
                if (tmpCheck != 0)
                {
                    if (tmpCheck < tmp)
                    {
                        return false;
                    }
                }

                tmpCheck = tmp;
            }
            return true;
        }

    }
}
