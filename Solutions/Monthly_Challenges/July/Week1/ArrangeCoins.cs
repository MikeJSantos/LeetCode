using System;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Beats 15.15% of submissions (36ms/81% slower than mode)
        // https://leetcode.com/submissions/detail/364311518
        public int ArrangeCoins(int n)
        {
            if (n < 1)
                return 0;

            var i = 1;
            var rows = 0;

            while (n > 0)
            {
                if (i <= n)
                {
                    rows++;
                    n -= i;
                    i++;
                }
                else
                    break;
            }

            return rows;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void ArrangeCoinsTest()
        {
            var s = new Solution();
            int n, expected;

            n = 5;
            expected = 2;
            Assert.Equal(expected, s.ArrangeCoins(n));

            n = 8;
            expected = 3;
            Assert.Equal(expected, s.ArrangeCoins(n));
        }
    }
}