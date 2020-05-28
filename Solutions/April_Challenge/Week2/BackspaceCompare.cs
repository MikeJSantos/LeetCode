using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public bool BackspaceCompare(string S, string T)
        {
            var parsedS = ParseBackspace(S);
            var parsedT = ParseBackspace(T);

            var retVal = parsedS.Equals(parsedT);

            return retVal;
        }

        private string ParseBackspace(string str)
        {
            var backspaceCounter = 0;
            var characterStack = new Stack<char>();

            for (var i = str.Length - 1; i >= 0; i--)
            {
                var character = str[i];

                if (character == '#')
                {
                    backspaceCounter++;
                }
                else if (backspaceCounter > 0)
                {
                    backspaceCounter--;
                }
                else
                {
                    characterStack.Push(character);
                }
            }

            return new String(characterStack.ToArray());            
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void BackspaceCompareTest()
        {
            var s = new Solution();
            Assert.True(s.BackspaceCompare("ab#c", "ad#c")); // true, "ac"
            Assert.True(s.BackspaceCompare("ab##", "c#d#")); // true, ""
            Assert.True(s.BackspaceCompare("a##c", "#a#c")); // true, "c"
            Assert.False(s.BackspaceCompare("a#c", "b"));    // false, "c" > "b"
        }
    }
}