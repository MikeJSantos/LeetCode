using System.Linq;

namespace LeetCode
{
    public partial class Solution 
    {
        public int MaxSubArray(int[] nums)
        {
            switch (nums.Length)
            {
                case 0: return 0;
                case 1: return nums[0];
                default: return Recurse(nums[0], ref nums, 0, nums.Length - 1);
            }
        }

        private int Recurse(int maxSum, ref int[] nums, int idxStart, int idxEnd)
        {
            //recurseCounter++;

            if (idxStart == idxEnd) return maxSum > nums[idxStart] ? maxSum : nums[idxStart];

            var subArray = nums.Skip(idxStart).Take(idxEnd - idxStart + 1);
            var subArraySum = subArray.Sum();

            var startIncrementSum = Recurse(maxSum, ref nums, idxStart + 1, idxEnd);
            var endDecrementSum = Recurse(maxSum, ref nums, idxStart, idxEnd - 1);

            var comparisonArray = new[] { maxSum, subArraySum, startIncrementSum, endDecrementSum };
            var newMaxSum = comparisonArray.Max();

            //Console.Out.WriteLine($"{recurseCounter} ({idxStart},{idxEnd}): [{string.Join(",", comparisonArray)}] => {newMaxSum}");
            return newMaxSum;
        }
    }
}