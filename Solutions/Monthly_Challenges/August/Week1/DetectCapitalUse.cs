using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // Beats 93.08% of submissions
        // https://leetcode.com/submissions/detail/375434971
        public bool DetectCapitalUse(string word)
        {
            if (word == word.ToUpper() || word == word.ToLower())
                return true;

            if (!char.IsUpper(word[0]))
                return false;

            for (var i = 1; i < word.Length; i++)
                if (char.IsUpper(word[i]))
                    return false;
            
            return true;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void DetectCapitalUseTest()
        {
            var s = new Solution();

            Assert.True(s.DetectCapitalUse("USA"));
            Assert.False(s.DetectCapitalUse("FlaG"));
        }
    }
}