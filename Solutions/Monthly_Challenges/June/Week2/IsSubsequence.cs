using System;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public bool IsSubsequence(string s, string t)
        {
            if (s == t)
                return true;
            if (t.Length == 0)
                return false;
            if (s.Length == 0)
                return true;

            var idx = 0;
            foreach(var c in t)
            {
                if (c == s[idx])
                {
                    idx++;
                    if (idx == s.Length)
                        return true;
                }
            }

            return false;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void IsSubsequenceTest()
        {
            var sol = new Solution();
            string s, t;

            s = "abc";
            t = "ahbgdc";
            Assert.True(sol.IsSubsequence(s,t));

            s = "axc";
            t = "ahbgdc";
            Assert.False(sol.IsSubsequence(s,t));
        }
    }
}