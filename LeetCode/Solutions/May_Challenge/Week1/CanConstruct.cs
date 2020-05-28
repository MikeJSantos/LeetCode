using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Submission not ranked (https://leetcode.com/submissions/detail/334875410/)
        // Sort both strings, then compare chunks of the ransom note to magazine?
        public bool CanConstruct(string ransomNote, string magazine)
        {
            var noteDictionary = new Dictionary<char, int>();
            var magDictionary = new Dictionary<char, int>();

            foreach (var c in ransomNote.ToCharArray())
            {
                if (c == ' ') continue;
                noteDictionary[c] = noteDictionary.ContainsKey(c)
                    ? noteDictionary[c] + 1
                    : 1;
            }

            foreach (var c in magazine.ToCharArray())
            {
                if (c == ' ') continue;
                magDictionary[c] = magDictionary.ContainsKey(c)
                    ? magDictionary[c] + 1
                    : 1;
            }

            foreach(var c in noteDictionary.Keys)
            {
                if (!magDictionary.ContainsKey(c) || magDictionary[c] < noteDictionary[c]) return false;
            }

            return true;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void CanConstructTest()
        {
            var s = new Solution();
            string ransomNote, magazine;

            ransomNote = "give me the money";
            magazine = "given all the memes that make money";
            Assert.True(s.CanConstruct(ransomNote, magazine));

            ransomNote = "a";
            magazine = "b";
            Assert.False(s.CanConstruct(ransomNote, magazine));

            ransomNote = "aa";
            magazine = "ab";
            Assert.False(s.CanConstruct(ransomNote, magazine));

            ransomNote = "aa";
            magazine = "aab";
            Assert.True(s.CanConstruct(ransomNote, magazine));
        }
    }
}