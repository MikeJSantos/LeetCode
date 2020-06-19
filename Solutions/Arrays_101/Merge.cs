using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // Beats 71.50% of submissions (https://leetcode.com/submissions/detail/355831812)
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var lastIdx = nums1.Length - 1;
            var n1Idx = m - 1;
            var n2Idx = n - 1;

            while (n1Idx >= 0 || n2Idx >= 0)
            {
                if (n1Idx >= 0 && (n2Idx < 0 || nums1[n1Idx] > nums2[n2Idx]))
                {
                    nums1[lastIdx] = nums1[n1Idx];
                    n1Idx--;
                }
                else
                {
                    nums1[lastIdx] = nums2[n2Idx];
                    n2Idx--;
                }

                lastIdx--;
            }
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void MergeTest()
        {
            var s = new Solution();
            int[] nums1, nums2, expected;
            int m, n;

            nums1    = new int[] { 1, 2, 3, 0, 0, 0 };
            m        = 3;
            nums2    = new int[] { 2, 5, 6 };
            n        = 3;
            expected = new int[] { 1, 2, 2, 3, 5, 6 };
            s.Merge(nums1, m, nums2, n);
            Assert.Equal(expected, nums1);

            // Test case 43/59 https://leetcode.com/submissions/detail/355829133/
            nums1    = new int[] { 0 };
            m        = 0;
            nums2    = new int[] { 1 };
            n        = 1;
            expected = new int[] { 1 };
            s.Merge(nums1, m, nums2, n);
            Assert.Equal(expected, nums1);
        }
    }
}