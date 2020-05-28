using System;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public int FindComplement(int num)
        {
            var binaryArray = Convert.ToString(num, 2).ToCharArray();
            
            for(var i = 0; i < binaryArray.Length; i++)
            {
                binaryArray[i] = binaryArray[i] == '1'
                    ? '0'
                    : '1';
            }

            return Convert.ToInt32(new string(binaryArray), 2);
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void FindComplementTest()
        {
            var s = new Solution();

            Assert.Equal(2, s.FindComplement(5));
            Assert.Equal(0, s.FindComplement(1));
        }
    }
}