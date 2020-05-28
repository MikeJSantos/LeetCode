using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Beats 30.00% of submissions (https://leetcode.com/submissions/detail/334816601/)
        public int FirstUniqChar(string s)
        {
            var uniqueChars = new Dictionary<char, int>();
            var duplicateChars = new List<char>();
            var charArray = s.ToCharArray();

            for (var i = 0; i < charArray.Length; i++)
            {
                var character = charArray[i];

                if (duplicateChars.Contains(character))
                    continue;
                else
                {
                    if (uniqueChars.ContainsKey(character))
                    {   // Add to duplicates
                        duplicateChars.Add(character);
                        uniqueChars.Remove(character);
                    }
                    else
                    {   // Add to uniques
                        uniqueChars[character] = i;
                    }

                }
            }

            if (!uniqueChars.Any()) return -1;

            // return first instance of unique char
            var minIndex = uniqueChars.Values.Min();
            return minIndex;
        }
    }
    
    public partial class UnitTests
    {
        [Fact]
        public void FirstUniqCharacterTest()
        {
            var s = new Solution();
            string str;

            str = "leetcode";
            Assert.Equal(0, s.FirstUniqChar(str));

            str = "loveleetcode";
            Assert.Equal(2, s.FirstUniqChar(str));
        }
    }
}