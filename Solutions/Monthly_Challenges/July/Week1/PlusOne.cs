using System;
using System.Numerics;
using System.Linq;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // Beats 88.88% of submissions
        // https://leetcode.com/submissions/detail/371071050/
        public int[] PlusOne(int[] digits)
        {
            var strDigits = string.Join("", digits);
            var number = BigInteger.Parse(strDigits);
            
            number += 1;
            
            var retVal = number.ToString()
                .Select(i => Convert.ToInt32(i) - 48)
                .ToArray();

            return retVal;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void PlusOneTest()
        {
            var s = new Solution();
            int[] digits, expected;

            digits   = new int[] { 1, 2, 3 };
            expected = new int[] { 1, 2, 4 };
            Assert.Equal(expected, s.PlusOne(digits));

            digits   = new int[] { 4, 3, 2, 1 };
            expected = new int[] { 4, 3, 2, 2 };
            Assert.Equal(expected, s.PlusOne(digits));

            digits   = new int[] { 1, 9 };
            expected = new int[] { 2, 0 };
            Assert.Equal(expected, s.PlusOne(digits));

            digits   = new int[] { 9, 9 };
            expected = new int[] { 1, 0, 0 };
            Assert.Equal(expected, s.PlusOne(digits));

            digits   = new int[] { 8, 5, 9, 9 };
            expected = new int[] { 8, 6, 0, 0 };
            Assert.Equal(expected, s.PlusOne(digits));

            digits   = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            expected = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 1 };
            Assert.Equal(expected, s.PlusOne(digits));
        }
    }
}