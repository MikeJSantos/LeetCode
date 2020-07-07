using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public int SingleNumber(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            var dupeDictionary = new Dictionary<int, bool>();

            foreach (var num in nums)
            {
                dupeDictionary[num] = dupeDictionary.ContainsKey(num);
            }

            foreach (var kvp in dupeDictionary)
            {
                if (!kvp.Value) return kvp.Key;
            }

            return 0;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void SingleNumberTest()
        {
            var s = new Solution();
            int[] nums;
            int expected;

            nums = new int[] { 2, 2, 1 };
            expected = 1;
            Assert.Equal(expected, s.SingleNumber(nums));

            nums = new int[] { 4, 1, 2, 1, 2 };
            expected = 4;
            Assert.Equal(expected, s.SingleNumber(nums));
        }
    }
}