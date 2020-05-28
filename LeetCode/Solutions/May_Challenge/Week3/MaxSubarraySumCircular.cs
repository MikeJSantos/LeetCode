using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public int MaxSubarraySumCircular(int[] A)
        {
            int i = 0, sum = 0, maxSum = int.MinValue, subArrayLength = 0;
            var hasLooped = false;

            do
            {
                var num = A[i];

                if (num >= 1)
                {
                    sum += num;

                    if (sum > maxSum)
                        maxSum = sum;

                    subArrayLength++;

                    if (subArrayLength == A.Length)
                        break;
                }
                else
                {
                    sum = 0;
                    subArrayLength = 0;
                }

                i = (i + 1) % A.Length;
                if (i == 0)
                    hasLooped = true;
            } while (!hasLooped || subArrayLength != 0);

            return maxSum;
        }

        // public int MaxSubarraySumCircular(int[] A)
        // {
        //     if (A.Length < 0) return 0;
        //     if (A.Length < 1) return A[0];

        //     var maxSum = int.MinValue;

        //     for (var startIdx = 0; startIdx < A.Length; startIdx++)
        //     {
        //         maxSum = MaxSubarraySumCircular_Iterate(A, startIdx, maxSum);
        //     }

        //     return maxSum;
        // }

        // private int MaxSubarraySumCircular_Iterate(int[] A, int startIdx, int maxSum)
        // {
        //     int idx;
        //     var sum = 0;

        //     for (var i = 0; i < A.Length; i++)
        //     {
        //         idx = (startIdx + i) % A.Length;
        //         sum += A[idx];

        //         if (sum > maxSum)
        //             maxSum = sum;
        //     }

        //     return maxSum;
        // }
    }

    public partial class UnitTests
    {
        [Fact]
        public void MaxSubarraySumCircularTest()
        {
            var s = new Solution();
            int[] A;

            A = new int[] { 1, -2, 3, -2 };
            Assert.Equal(3, s.MaxSubarraySumCircular(A));

            A = new int[] { 5, -3, 5 };
            Assert.Equal(10, s.MaxSubarraySumCircular(A));

            A = new int[] { 3, -1, 2, -1 };
            Assert.Equal(4, s.MaxSubarraySumCircular(A));

            A = new int[] { 3, -2, 2, -3 };
            Assert.Equal(3, s.MaxSubarraySumCircular(A));

            A = new int[] { -2, -3, -1 };
            Assert.Equal(-1, s.MaxSubarraySumCircular(A));

            // TODO: Failed test case 101/109, TLE -- https://leetcode.com/submissions/detail/339749427/
        }
    }
}