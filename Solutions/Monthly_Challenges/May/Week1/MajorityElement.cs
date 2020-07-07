using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Beats 39.69% of submissions (https://leetcode.com/submissions/detail/335300805/)
        public int MajorityElement(int[] nums)
        {
            var majorityElement = 0;
            var numDictionary = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (!numDictionary.Any())
                {
                    numDictionary[num] = 1;
                    majorityElement = num;
                    continue;
                }

                numDictionary[num] = numDictionary.ContainsKey(num)
                    ? numDictionary[num] + 1
                    : 1;

                if (numDictionary[num] > numDictionary[majorityElement])
                    majorityElement = num;
            }

            return majorityElement;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void MajorityElementTest()
        {
            var s = new Solution();
            int[] array;

            array = new int[] { 3, 2, 3 };
            Assert.Equal(3, s.MajorityElement(array));

            array = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            Assert.Equal(2, s.MajorityElement(array));

            array = new int[] { 6, 5, 5 };
            Assert.Equal(5, s.MajorityElement(array));
        }
    }
}