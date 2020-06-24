using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // Beats 84.13% of submissions (https://leetcode.com/submissions/detail/357828013)
        public bool CheckIfExist(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                return false;
            
            for (var i = 0; i < arr.Length; i++)
            {
                var num = arr[i];
                for (var j = i + 1; j < arr.Length; j++)
                {
                    var num2 = arr[j];
                    if (num == num2 * 2 || num == (double) num2 / 2)
                        return true;
                }
            }

            return false;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void CheckIfExistTest()
        {
            var s = new Solution();
            int[] arr;

            arr = new int[] { 10, 2, 5, 3 };
            Assert.True(s.CheckIfExist(arr));

            arr = new int[] { 7, 1, 14, 11 };
            Assert.True(s.CheckIfExist(arr));

            arr = new int[] { 3, 1, 7, 11 };
            Assert.False(s.CheckIfExist(arr));
        }
    }
}