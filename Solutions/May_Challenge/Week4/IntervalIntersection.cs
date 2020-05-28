using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize? Beats 43.40% of submissions (https://leetcode.com/submissions/detail/343793768)
        public int[][] IntervalIntersection(int[][] A, int[][] B)
        {
            var retVal = new List<int[]>();

            if (A == null || B == null || A.Length < 1 || B.Length < 1)
                return retVal.ToArray();

            int indexA = 0, indexB = 0;
            int[] intervalA, intervalB;

            while (indexA < A.Length && indexB < B.Length)
            {
                intervalA = A[indexA];
                intervalB = B[indexB];

                // Skip the lesser interval, if the intervals don't intersect
                if (intervalB[1] < intervalA[0])
                {
                    indexB++;
                    continue;
                }
                if (intervalA[1] < intervalB[0])
                {
                    indexA++;
                    continue;
                }

                // Find & add the intersection
                var lowerBound = Math.Max(intervalA[0], intervalB[0]);
                var upperBound = Math.Min(intervalA[1], intervalB[1]);
                retVal.Add(new int[] { lowerBound, upperBound });

                if (intervalA[1] == upperBound)
                    indexA++;
                
                if (intervalB[1] == upperBound)
                    indexB++;
            }

            return retVal.ToArray();
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void IntervalIntersectionTest()
        {
            var s = new Solution();
            int[][] A, B, expected;

            A = new int[][]
            {
                new int[] { 0, 2 },
                new int[] { 5, 10 },
                new int[] { 13, 23 },
                new int[] { 24, 25 }
            };
            B = new int[][]
            {
                new int[] { 1, 5 },
                new int[] { 8, 12 },
                new int[] { 15, 24 },
                new int[] { 25, 26 }
            };
            expected = new int[][] {
                new int[] { 1, 2 },
                new int[] { 5, 5 },
                new int[] { 8, 10 },
                new int[] { 15, 23 },
                new int[] { 24, 24 },
                new int[] { 25, 25 }
            };
            Assert.Equal(expected, s.IntervalIntersection(A, B));
        }
    }
}