using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize with divide & conquer solution. Beats 6.47% of submissions
        // https://leetcode.com/submissions/detail/351874201
        public int SearchInsert(int[] nums, int target)
        {
            if (nums.Length == 0)
                return 0;

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= target)
                    return i;
            }

            return nums.Length;
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
        }
    }
}