using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Beats 41.98% of submissions (68ms slower than median)
        // https://leetcode.com/submissions/detail/346748585
        public int[][] KClosest(int[][] points, int K)
        {
            if (K == 0 || points.Length == 0)
                return new int[][] { };

            // key: distance, value: list of points matching the distance
            var distToPointDict = new Dictionary<double, List<int[]>>();

            // for each point, calculate distance w/ pythagorean theorem, then add to dictionary
            foreach (var point in points)
            {
                var distance = Math.Sqrt((point[0] * point[0]) + (point[1] * point[1]));

                if (!distToPointDict.ContainsKey(distance))
                    distToPointDict[distance] = new List<int[]>();

                distToPointDict[distance].Add(point);
            }

            var returnValue = new int[K][];
            var count = 0;

            foreach (var distance in distToPointDict.Keys.OrderBy(key => key))
            {
                if (count == K)
                    break;

                foreach (var point in distToPointDict[distance])
                {
                    if (count == K)
                        break;

                    returnValue[count] = point;
                    count++;
                }
            }

            return returnValue;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void KClosestTest()
        {
            var s = new Solution();
            int K;
            int[][] points, expected;

            K = 1;
            points = Create2dArray(2, 1, 3, -2, 2);
            expected = Create2dArray(2, -2, 2);
            Assert.Equal(expected, s.KClosest(points, K));

            K = 2;
            points = Create2dArray(2, 3, 3, 5, -1, -2, 4);
            expected = Create2dArray(2, 3, 3, -2, 4);
            Assert.Equal(expected, s.KClosest(points, K));
        }
    }
}