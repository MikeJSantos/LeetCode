using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Beats 9.35% of submissions (https://leetcode.com/submissions/detail/343093044)
        public string FrequencySort(string s)
        {
            if (s.Length < 3)
                return s;

            var charToCountDict  = new Dictionary<char, int>();
            var countToCharsDict = new Dictionary<int,  List<char>>();

            foreach (var c in s.ToCharArray())
            {
                var count = charToCountDict.ContainsKey(c)
                    ? charToCountDict[c] + 1
                    : 1;

                charToCountDict[c] = count;

                if (countToCharsDict.ContainsKey(count - 1))
                    countToCharsDict[count - 1].Remove(c);

                if (!countToCharsDict.ContainsKey(count))
                    countToCharsDict[count] = new List<char>();

                countToCharsDict[count].Add(c);
            }

            var strBuilder = new StringBuilder();
            foreach (var count in countToCharsDict.Keys.OrderByDescending(count => count))
                foreach (var c in countToCharsDict[count])
                {
                    strBuilder.Append("".PadRight(count, c));
                }

            return strBuilder.ToString();
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void FrequencySortTest()
        {
            var s = new Solution();
            string input, expected;

            input = "tree";
            expected = "eetr";
            Assert.Equal(expected, s.FrequencySort(input));

            input = "cccaaa";
            expected = "cccaaa";
            Assert.Equal(expected, s.FrequencySort(input));

            input = "Aabb";
            expected = "bbAa";
            Assert.Equal(expected, s.FrequencySort(input));
        }
    }
}