using System.Text.RegularExpressions;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Beats 35.17% of submissions (44ms/55% slower than mode)
        // https://leetcode.com/submissions/detail/375455735/
        public bool IsPalindrome(string s)
        {
            if (s.Length == 0)
                return true;

            // Strip out non alphanumeric characters from string
            s = Regex.Replace(s, "[^0-9A-Za-z]", "").ToLower();

            for (var i = 0; i <= s.Length/2; i++)
                if (s[i] != s[s.Length-1-i])
                    return false;

            return true;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void IsPalindromeTest()
        {
            var sol = new Solution();
            string s;

            s = "A man, a plan, a canal: Panama";
            Assert.True(sol.IsPalindrome(s));

            s = "race a car";
            Assert.False(sol.IsPalindrome(s));

            s = "0P";
            Assert.False(sol.IsPalindrome(s));

            s = "a";
            Assert.True(sol.IsPalindrome(s));

            s = "a.";
            Assert.True(sol.IsPalindrome(s));
        }
    }
}