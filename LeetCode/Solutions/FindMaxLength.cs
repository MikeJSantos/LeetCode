using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public int FindMaxLength(int[] nums)
        {
            
            var maxPotentialLength = nums.Length - (nums.Length % 2);
            var subArrayDictionary = new Dictionary<int, List<int>>();
            var maxSize = 0;

            for (var startIndex = 0; startIndex < nums.Length; startIndex++)
            {
                var zeroCount = 0;
                var oneCount  = 0;
                
                var i = 0;//subArrayDictionary.ContainsKey(startIndex);

                for (; i < nums.Length; i++)
                {
                    if (nums[i] == 0)
                        zeroCount++;
                    else
                        oneCount++;

                    if (zeroCount == oneCount)
                    {
                        var size = zeroCount + oneCount;
                        if (subArrayDictionary.ContainsKey(startIndex))
                            subArrayDictionary[startIndex].Add(size);
                        else
                            subArrayDictionary[startIndex] = new List<int> { size };
                        
                        if (size > maxSize)
                            maxSize = size;
                    }
                }
            }
            
            return maxSize;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void FindMaxLengthTest()
        {
            var s = new Solution();
            int[] nums;
            int expected;

            nums = new int[] { 0, 1 };
            expected = 2;
            Assert.Equal(expected, s.FindMaxLength(nums));

            nums = new int[] { 0, 1, 0 };
            expected = 2;
            Assert.Equal(expected, s.FindMaxLength(nums));
        }
    }
}