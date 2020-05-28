using System;
using System.Linq;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // Beats 70.47% of submissions. (https://leetcode.com/submissions/detail/345906222)
        public int[] CountBits(int num)
        {
            if (num < 0)
                return new int[] {};

            var retVal = new int[num+1];
            var twoToTheN = 2;

            for (var i = 1; i <= num; i++)
            {
                if (i % 2 == 1)
                    retVal[i] = retVal[i-1] + 1;
                else if (i == twoToTheN)
                {
                    retVal[i] = 1;
                    twoToTheN *= 2;
                }
                else
                    retVal[i] = 1 + retVal[i - (twoToTheN/2)];
            }

            return retVal;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void CountBitsTest()
        {
            var s = new Solution();
            int num;
            int[] expected;

            num = 2;
            expected = new int[] { 0, 1, 1 };
            Assert.Equal(expected, s.CountBits(num));

            num = 5;
            expected = new int[] { 0, 1, 1, 2, 1, 2 };
            Assert.Equal(expected, s.CountBits(num));

            num = 16;
            expected = ReadTestDataFromFile($"CountBits_{num}_output.txt")
                .Split(',')
                .Select(n => Convert.ToInt32(n))
                .ToArray();
            Assert.Equal(expected, s.CountBits(num));

            num = 99999;
            expected = ReadTestDataFromFile($"CountBits_{num}_output.txt")
                .Split(',')
                .Select(n => Convert.ToInt32(n))
                .ToArray();
            Assert.Equal(expected, s.CountBits(num));
        }
    }
}