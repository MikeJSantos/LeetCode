using System.Linq;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Beats 29.72% of submissions (8ms slower than mode)
        // https://leetcode.com/submissions/detail/357804984
        public int RemoveElement(int[] nums, int val)
        {
            var length = nums.Length;

            for (var i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] != val)
                    continue;

                length--;

                // Do nothing, last element in array
                if (i == length)
                    continue;

                for (var j = i; j < length; j++)
                    nums[j] = nums[j+1];
            }

            return length;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void RemoveElementTest()
        {
            var s = new Solution();
            int[] nums, expectedNums;
            int val, expected;

            nums         = new int[] { 3, 2, 2, 3 };
            val          = 3;
            expected     = 2;
            expectedNums = new int[] { 2, 2 };
            Assert.Equal(expected, s.RemoveElement(nums, val));
            Assert.Equal(expectedNums, nums.Take(expected));

            nums         = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            val          = 2;
            expected     = 5;
            expectedNums = new int[] { 0, 1, 3, 0, 4 };
            Assert.Equal(expected, s.RemoveElement(nums, val));
            Assert.Equal(expectedNums, nums.Take(expected));
        }
    }
}