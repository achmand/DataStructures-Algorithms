using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms
{
    // http://mathworld.wolfram.com/JosephusProblem.html
    // https://www.youtube.com/watch?v=uCsD3ZGzMgE

    public sealed class JosephusProblem
    {
        private readonly List<int> _workingSet;

        public JosephusProblem(int candidates)
        {
            _workingSet = new List<int>(candidates);

            for (int i = 0; i < candidates; i++)
            {
                _workingSet.Add(i);
            }
        }

        /// <summary>
        /// Solving the problem using binary. Converting the number of candidates to binary and then move the first index to the last + 1
        /// </summary>
        /// <returns>Solution</returns>
        public int SolveProblemBinary()
        {
            var length = _workingSet.Count;
            var binaryLength = Convert.ToString(length, 2);
            binaryLength += "0";

            var sb = new StringBuilder(binaryLength);
            var lastNumber = binaryLength[sb.Length - 1];
            sb[sb.Length - 1] = lastNumber;
            sb.Remove(0, 1);

            var ans = Convert.ToInt32(sb.ToString(), 2) + 1;
            return ans;
        }

        /// <summary>
        /// Solving the josephus problem using recursion
        /// </summary>
        /// <returns>Solution</returns>
        public int SolveProblemRecursion()
        {
            RemoveNextSurvivor(0, _workingSet.Count);
            return _workingSet[0] + 1;
        }

        private void RemoveNextSurvivor(int startIndex, int count)
        {
            if (count == 1)
            {
                return;
            }

            var nextDeath = startIndex + 1;
            if (nextDeath >= count)
            {
                nextDeath = 0;
            }

            _workingSet.RemoveAt(nextDeath);

            var nextSurvivor = nextDeath;
            if (nextSurvivor >= _workingSet.Count)
            {
                nextSurvivor = 0;
            }

            RemoveNextSurvivor(nextSurvivor, _workingSet.Count);
        }

        // TODO -> Implement reset object method 
    }
}
