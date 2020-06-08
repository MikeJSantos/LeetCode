using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public void ReverseString(char[] s)
        {
            for (var i = 0; i < s.Length / 2; i++)
            {
                var lastIdx = s.Length - i - 1;
                var temp = s[i];
                s[i] = s[lastIdx];
                s[lastIdx] = temp;
            }
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void ReverseStringTest()
        {
            var solution = new Solution();
            char[] s, expected;

            s = "hello".ToCharArray();
            expected = "olleh".ToCharArray();
            solution.ReverseString(s);
            Assert.Equal(expected, s);

            s = "Hannah".ToCharArray();
            expected = "hannaH".ToCharArray();
            solution.ReverseString(s);
            Assert.Equal(expected, s);
        }
    }   
}