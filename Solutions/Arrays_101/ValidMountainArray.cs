using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Beats 8.87% of submissions (80% slower than median)
        // https://leetcode.com/submissions/detail/363383226
        public bool ValidMountainArray(int[] A)
        {
            if (A == null || A.Length < 3)
                return false;

            var reachedSummit = false;

            for (var i = 1; i < A.Length; i++)
            {
                if (!reachedSummit && i != A.Length - 1 && A[i-1] < A[i] && A[i] > A[i+1]) // Peak
                    reachedSummit = true;
                else if (!reachedSummit && A[i] > A[i-1]) // Climbing
                    continue;
                else if (reachedSummit && A[i] < A[i-1]) // Descending
                    continue;
                else
                    return false;
            }

            return reachedSummit;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void ValidMountainArrayTest()
        {
            var s = new Solution();
            int[] A;

            A = new int[] { 2, 1 };
            Assert.False(s.ValidMountainArray(A));

            A = new int[] { 3, 5, 5 };
            Assert.False(s.ValidMountainArray(A));

            A = new int[] { 0, 3, 2, 1 };
            Assert.True(s.ValidMountainArray(A));

            A = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.False(s.ValidMountainArray(A));

            A = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            Assert.False(s.ValidMountainArray(A));

            A = new int[] { 1, 3, 2 };
            Assert.True(s.ValidMountainArray(A));

            A = new int[] { 3, 7, 6, 4, 3, 0, 1, 0 };
            Assert.False(s.ValidMountainArray(A));

            A = new int[] { 2, 1, 2, 3, 5, 7, 9, 10, 12, 14, 15, 16, 18, 14, 13 };
            Assert.False(s.ValidMountainArray(A));
        }
    }
}