using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Beats 55.94% of submissions
        // https://leetcode.com/submissions/detail/350811262
        public bool IsPowerOfTwo(int n)
        {
            if (n == 1)
                return true;
            if (n < 1 || n % 2 != 0)
                return false;

            return IsPowerOfTwo_Recurse(n);
        }

        private bool IsPowerOfTwo_Recurse(int n)
        {
            if (n == 2)
                return true;
            else if (n % 2 == 1)
                return false;
            
            return IsPowerOfTwo_Recurse(n / 2);
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void IsPowerOfTwoTest()
        {
            var s = new Solution();

            Assert.True(s.IsPowerOfTwo(1));
            Assert.True(s.IsPowerOfTwo(16));
            Assert.False(s.IsPowerOfTwo(218));
            // Test case 1085/1108
            Assert.False(s.IsPowerOfTwo(1073741825));
            // Test case 1086/1108
            Assert.False(s.IsPowerOfTwo(2147483646));
        }
    }
}