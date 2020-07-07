using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public bool IsHappy(int n)
        {
            var numbersAlreadyCalculated = new List<int>();

            while (n != 1)
            {
                if (numbersAlreadyCalculated.Contains(n))
                    return false;

                numbersAlreadyCalculated.Add(n);
                n = IsHappy_Iterate(n);
            }

            return true;
        }

        private int IsHappy_Iterate(int n)
        {
            // convert n to array of single digits
            var nInDigits = new Stack<int>();

            for (; n > 0; n /= 10)
                nInDigits.Push(n % 10);

            // for each digit, square & add to calculatedNumber
            var calculatedNumber = 0;
            foreach (var digit in nInDigits.ToArray())
            {
                calculatedNumber += (digit * digit);
            }

            return calculatedNumber;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void IsHappyTest()
        {
            var s = new Solution();

            Assert.True(s.IsHappy(19));
        }
    }
}