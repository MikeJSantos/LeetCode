using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize? Beats 63.74% of submissions (at mode)
        // https://leetcode.com/submissions/detail/370585725
        public int[] SingleNumberIII(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return nums;

            var hashSet = new HashSet<int>();

            foreach (var num in nums)
            {
                if (hashSet.Contains(num))
                    hashSet.Remove(num);
                else
                    hashSet.Add(num);
            }

            var retVal = new int[hashSet.Count];
            hashSet.CopyTo(retVal);
            return retVal;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void SingleNumberIIITest()
        {
            var s = new Solution();
            int[] nums, expected;

            nums     = new int[] { 1, 2, 1, 3, 2, 5 };
            expected = new int[] { 3, 5 };
            Assert.Equal(expected, s.SingleNumberIII(nums));
        }
    }
}