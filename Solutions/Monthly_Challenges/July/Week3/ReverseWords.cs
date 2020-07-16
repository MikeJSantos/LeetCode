using System.Text;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // Beats 95.99% of submissions
        // https://leetcode.com/submissions/detail/367096605
        public string ReverseWords(string s)
        {
            if (s.Length == 0)
                return string.Empty;

            var strBuilder = new StringBuilder();
            int endIndex = 0;

            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ' && endIndex != 0)
                {
                    var length = endIndex - i;
                    strBuilder.Append($"{s.Substring(i + 1, length)} ");
                    endIndex = 0;
                }
                else if (s[i] != ' ' && endIndex == 0)
                    endIndex = i;
            }

            if (s[0] != ' ')
                strBuilder.Append($"{s.Substring(0, endIndex + 1)}");

            return strBuilder.ToString().TrimEnd();
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

            str      = " 1";
            expected = "1";
            Assert.Equal(expected, s.ReverseWords(str));
        }
    }
}