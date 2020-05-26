using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public int MaxUncrossedLines(int[] A, int[] B)
        {
            var lines = new Dictionary<int, List<int[]>>();
            var uncrossedLines = new List<int []>();

            if (A == null || A.Length == 0 || B == null || B.Length == 0)
                return uncrossedLines.Count();

            // Find all potential lines
            for (var indexA = 0; indexA < A.Length; indexA++)
            {
                var value = A[indexA];
                if (!lines.ContainsKey(value))
                    lines[value] = MaxUncrossedLines_FindLines(value, indexA, B);
            }

            // TODO: Calculate potential lines

            return uncrossedLines.Count();
        }

        private List<int[]> MaxUncrossedLines_FindLines(int value, int indexA, int[] B)
        {
            throw new NotImplementedException();
        }
    }

    public partial class UnitTests
    {
        public void MaxUncrossedLinesTest()
        {
            var s = new Solution();
            int[] A, B;
            int expected;

            A = new int[] { 1, 4, 2 };
            B = new int[] { 1, 2, 4 };
            expected = 2;
            Assert.Equal(expected, s.MaxUncrossedLines(A, B));

            A = new int[] { 2, 5, 1, 2, 5 };
            B = new int[] { 10, 5, 2, 1, 5, 2 };
            expected = 3;
            Assert.Equal(expected, s.MaxUncrossedLines(A, B));

            A = new int[] { 1, 3, 7, 1, 7, 5 };
            B = new int[] { 1, 9, 2, 5, 1 };
            expected = 2;
            Assert.Equal(expected, s.MaxUncrossedLines(A, B));
        }
    }
}