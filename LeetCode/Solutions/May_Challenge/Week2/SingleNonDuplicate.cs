using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // Beats 73.78% of submissions
        public int SingleNonDuplicate(int[] nums)
        {
            var dict = new Dictionary<int, bool>();

            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                    dict.Remove(num);
                else
                    dict[num] = true;
            }

            return dict.Keys.FirstOrDefault();
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void SingleNonDuplicateTest()
        {
            var s = new Solution();
            int[] nums;

            nums = new int[] { 1, 1, 2, 3, 3, 4, 4, 8, 8 };
            Assert.Equal(2, s.SingleNonDuplicate(nums));

            nums = new int[] { 3, 3, 7, 7, 10, 11, 11 };
            Assert.Equal(10, s.SingleNonDuplicate(nums));
        }
    }
}