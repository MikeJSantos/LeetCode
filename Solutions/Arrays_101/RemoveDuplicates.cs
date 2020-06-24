using System.Linq;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize? Beats 49.31% of submissions (4ms slower than mode)
        // https://leetcode.com/submissions/detail/357814871
        public int RemoveDuplicates(int[] nums)
        {
            var length = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                if (i == 0 || nums[i] != nums[i-1])
                {
                    nums[length] = nums[i];
                    length++;
                }
            }

            return length;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void RemoveDuplicatesTest()
        {
            var s = new Solution();
            int[] nums, expectedNums;
            int expected;

            nums         = new int[] { 1, 1, 2 };
            expected     = 2;
            expectedNums = new int[] { 1, 2 };
            Assert.Equal(expected, s.RemoveDuplicates(nums));
            Assert.Equal(expectedNums, nums.Take(expected));

            nums         = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            expected     = 5;
            expectedNums = new int[] { 0, 1, 2, 3, 4 };
            Assert.Equal(expected, s.RemoveDuplicates(nums));
            Assert.Equal(expectedNums, nums.Take(expected));
        }
    }
}