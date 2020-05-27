using System;
using System.Linq;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public int NumJewelsInStones(string J, string S) {
            var jewelCount = 0;
            var jewels = J.ToCharArray();

            foreach(var stone in S.ToCharArray())
            {
                if (jewels.Contains(stone))
                    jewelCount++;
            }

            return jewelCount;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void NumJewelsInStonesTest()
        {
            var s = new Solution();
            string J, S;

            J = "aA";
            S = "aAAbbbb";
            Assert.Equal(3, s.NumJewelsInStones(J, S));

            J = "z";
            S = "ZZ";
            Assert.Equal(0, s.NumJewelsInStones(J, S));
        }
    }
}