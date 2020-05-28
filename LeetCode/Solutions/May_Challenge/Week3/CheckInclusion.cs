using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Submission not ranked (https://leetcode.com/submissions/detail/341229875/)
        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length < 1 || s2.Length < 1)
                return false;

            var sourceDict = new Dictionary<char, int>();

            for (var i = 0; i < s1.Length; i++)
            {
                var c = s1[i];
                sourceDict[c] = sourceDict.ContainsKey(c)
                    ? sourceDict[c] + 1
                    : 1;
            }

            for (var i = 0; i <= s2.Length - s1.Length; i++)
            {
                var dict = new Dictionary<char, int>(sourceDict);
                var charArray = s2.Substring(i, s1.Length).ToCharArray();

                foreach (var c in charArray)
                {
                    if (dict.ContainsKey(c))
                    {
                        if (dict[c] == 1)
                        {
                            dict.Remove(c);

                            if (!dict.Keys.Any())
                                return true;
                        }
                        else
                            dict[c] = dict[c] - 1;
                    }
                    else
                        break;
                }
            }

            return false;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void CheckInclusionTest()
        {
            var s = new Solution();
            string s1, s2;

            s1 = "ab";
            s2 = "eidbaooo";
            Assert.True(s.CheckInclusion(s1, s2));

            s1 = "ab";
            s2 = "eidboaoo";
            Assert.False(s.CheckInclusion(s1, s2));

            s1 = "adc";
            s2 = "dcda";
            Assert.True(s.CheckInclusion(s1, s2));

            s1 = "hello";
            s2 = "ooolleoooleh";
            Assert.False(s.CheckInclusion(s1, s2));
        }
    }
}