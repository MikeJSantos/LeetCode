using System;
using System.Linq;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public int TwoCitySchedCost(int[][] costs)
        {
            if (costs == null || costs.Length == 0)
                return 0;

            // Find the minimum of each row, and return the sum of the list
            var minCosts = new int[costs.Length];
            for (var applicantNum = 0; applicantNum < costs.Length; applicantNum++)
                minCosts[applicantNum] = costs[applicantNum].Min();

            var retVal = minCosts.OrderBy(cost => cost);
            return retVal.Sum();
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void TwoCitySchedCostTest()
        {
            var s = new Solution();
            int[][] costs;
            int expected;

            costs = Create2dArray(2, 10, 20, 30, 200, 400, 50, 30, 20);
            expected = 110;
            //Assert.Equal(expected, s.TwoCitySchedCost(costs));

            // 8/49 (https://leetcode.com/submissions/detail/348479918)
            // Candidates must be sent equally to each city
            costs = Create2dArray(2, 259, 770, 448, 54, 926, 667, 184, 139, 840, 118, 577, 469);
            expected = 1859;
            Assert.Equal(expected, s.TwoCitySchedCost(costs));
        }
    }
}