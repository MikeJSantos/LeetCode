using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize with single pass. Beats 60.93% of submissions
        // https://leetcode.com/submissions/detail/352237694
        public void SortColors(int[] nums)
        {
            for (var tail = 1; tail < nums.Length; tail++)
            {
                for (var head = 0; head < nums.Length - 1; head++)
                {
                    if (SortColors_RunPass(nums, head, tail))
                        SortColors_RunPass(nums, 0, tail);
                }
            }
        }

        private bool SortColors_RunPass(int[] nums, int head, int tail)
        {
            for (; head < tail; head++)
            {
                if (nums[head] > nums[tail])
                {
                    var temp = nums[head];
                    nums[head] = nums[tail];
                    nums[tail] = temp;
                    return true;
                }
            }

            return false;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void SortColorsTest()
        {
            var s = new Solution();
            int[] nums, expected;

            nums     = new int[] { 2, 0, 2, 1, 1, 0 };
            expected = new int[] { 0, 0, 1, 1, 2, 2 };
            s.SortColors(nums);
            Assert.Equal(expected, nums);
        }
    }
}