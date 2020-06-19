using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Beats 46.02% of submissions (https://leetcode.com/submissions/detail/355807279/)
        public void DuplicateZeros(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
                if (arr[i] == 0)
                {
                    for (var j = arr.Length - 1; j > i + 1; j--)
                        arr[j] = arr[j - 1];
                    if (i < arr.Length - 1)
                        arr[i + 1] = 0;
                    i++;
                }
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void DuplicateZerosTest()
        {
            var s = new Solution();
            int[] arr, expected;

            arr      = new int[] { 1, 0, 2, 3, 0, 4, 5, 0 };
            expected = new int[] { 1, 0, 0, 2, 3, 0, 0, 4 };
            s.DuplicateZeros(arr);
            Assert.Equal(expected, arr);

            arr      = new int[] { 1, 2, 3 };
            expected = new int[] { 1, 2, 3 };
            s.DuplicateZeros(arr);
            Assert.Equal(expected, arr);

            arr      = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            expected = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            s.DuplicateZeros(arr);
        }
    }
}