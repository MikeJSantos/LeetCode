using System;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public bool IsPowerOfFour(int num)
        {
            if (num == 1)
                return true;
            if (num % 2 != 0)
                return false;

            var num1 = 4;
            while (num1 < num)
                num1 *= 4;

            return num1 == num;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void IsPowerOfFourTest()
        {
            var s = new Solution();

            Assert.True(s.IsPowerOfFour(4));
            Assert.False(s.IsPowerOfFour(5));
        }
    }
}