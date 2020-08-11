using System;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // Beats 92.14% of submissions
        // https://leetcode.com/submissions/detail/379376668
        public int TitleToNumber(string s)
        {
            if (s.Length == 0)
                return 0;

            var sum = 0;
            for (var i = s.Length - 1; i >= 0; i--)
            {
                // A = 65, Z = 90
                var num = (int) s[i] - 64;
                
                if (i == s.Length - 1)
                    sum += num;
                else
                {
                    var power = s.Length - i - 1;
                    sum += num * (int) Math.Pow(26, power);
                }
            }

            return sum;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void TitleToNumberTest()
        {
            var s = new Solution();

            Assert.Equal(1, s.TitleToNumber("A"));
            Assert.Equal(26, s.TitleToNumber("Z"));
            Assert.Equal(28, s.TitleToNumber("AB"));
            Assert.Equal(701, s.TitleToNumber("ZY"));
            Assert.Equal(703, s.TitleToNumber("AAA"));
        }
    }
}