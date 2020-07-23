using System;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Beats 31.91% of submissions (104ms/43% slower than mode)
        // https://leetcode.com/submissions/detail/370619159
        public int[] PlusOne(int[] digits)
        {
            if (digits == null || digits.Length == 0)
                return digits;
            else if (digits[digits.Length - 1] != 9)
            {
                digits[digits.Length - 1] += 1;
                return digits;
            }

            for (var i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] == 9)
                {
                    if (i == 0)
                    {   // 99 => 100
                        digits = new int[digits.Length + 1];
                        Array.Fill(digits, 0);
                        digits[0] = 1;
                    }
                    else
                        digits[i] = 0;
                }
                else
                {
                    digits[i] += 1;
                    return digits;
                }
            }

            return digits;
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
        }
    }
}