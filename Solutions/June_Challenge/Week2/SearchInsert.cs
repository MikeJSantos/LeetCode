using System;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize Beats 57.41% of submissions
        // https://leetcode.com/submissions/detail/352256037
        public int SearchInsert(int[] nums, int target)
        {
            if (nums.Length == 0 || nums[0] > target)
                return 0;
            if (nums[nums.Length-1] < target)
                return nums.Length;

            int low = 0,
                high = nums.Length - 1,
                mid;

            while (low < high)
            {
                mid = low + (high - low) / 2;

                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                    low = (low != mid) ? mid : low + 1;
                else
                    high = (high != mid) ? mid : high - 1;
            }

            return low;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void SearchInsertTest()
        {
            var s = new Solution();
            int target, expected;
            int[] nums;

            nums     = new int[] { 1, 3, 5, 6 };
            target   = 5;
            expected = 2;
            Assert.Equal(expected, s.SearchInsert(nums, target));

            nums     = new int[] { 1, 3, 5, 6 };
            target   = 2;
            expected = 1;
            Assert.Equal(expected, s.SearchInsert(nums, target));

            nums     = new int[] { 1, 3, 5, 6 };
            target   = 7;
            expected = 4;
            Assert.Equal(expected, s.SearchInsert(nums, target));

            nums     = new int[] { 1, 3, 5, 6 };
            target   = 0;
            expected = 0;
            Assert.Equal(expected, s.SearchInsert(nums, target));

            // Test case 27/62 https://leetcode.com/submissions/detail/352251373/
            nums     = new int[] { 2, 7, 8, 9, 10 };
            target   = 9;
            expected = 3;
            Assert.Equal(expected, s.SearchInsert(nums, target));

            // Test case 52/62 https://leetcode.com/submissions/detail/352256863
            nums = new int[] { 1, 3, 5, 6 };
            target   = 7;
            expected = 4;
            Assert.Equal(expected, s.SearchInsert(nums, target));
        }
    }
}