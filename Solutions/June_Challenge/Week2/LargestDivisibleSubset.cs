using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return new List<int>();

            var subset = new List<int>(nums);
            var i = 0;

            foreach (var num in nums)
                while (i < subset.Count)
                {
                    if (num % subset[i] != 0)
                        subset.Remove(subset[i]);
                    i++;
                }

            return subset;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void LargestDivisibleSubsetTest()
        {
            var s = new Solution();
            int[] nums;
            IList<int> expected;

            nums = new int[] { 1, 2, 3 };
            expected = new List<int> { 1, 3 };
            Assert.Equal(expected, s.LargestDivisibleSubset(nums));

            nums = new int[] { 1, 2, 4, 8 };
            expected = new List<int> { 1, 2, 4, 8 };
            Assert.Equal(expected, s.LargestDivisibleSubset(nums));
        }
    }
}