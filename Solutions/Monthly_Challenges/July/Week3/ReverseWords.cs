using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Beats 12.20% of submissions (70ms/77% slower than mode)
        // https://leetcode.com/submissions/detail/367083667
        public string ReverseWords(string s)
        {
            var strArray = s.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(strArray);
            return string.Join(' ', strArray);
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void ReverseWordsTest()
        {
            var s = new Solution();
            string str, expected;

            str      = "the sky is blue";
            expected = "blue is sky the";
            Assert.Equal(expected, s.ReverseWords(str));

            str      = "  hello world!  ";
            expected = "world! hello";
            Assert.Equal(expected, s.ReverseWords(str));

            str      = "a good   example";
            expected = "example good a";
            Assert.Equal(expected, s.ReverseWords(str));
        }
    }
}