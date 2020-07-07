using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public string StringShift(string s, int[][] shift)
        {
            if (shift?.Length == 0 || shift.GetLength(0) < 1)
                return string.Empty;

            for (var i = 0; i < shift.GetLength(0); i++)
            {
                if (shift[i].Length != 2) continue; // not a [direction,amount] input, ignore

                var direction = shift[i][0];
                var amount    = shift[i][1];
                string strA, strB;

                if (direction == 0) // shift left
                {
                    strA = s.Substring(0, amount);
                    strB = s.Substring(amount, s.Length - amount);
                    s = strB + strA;
                }
                else // shift right
                {
                    strA = s.Substring(0, s.Length - amount);
                    strB = s.Substring(s.Length - amount, amount);
                    s = strB + strA;
                }
            }

            return s;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void StringShiftTest()
        {
            var s = new Solution();
            string inputStr;
            int[][] shift;

            inputStr = "abc";
            shift = Create2dArray(2, 0, 1, 1, 2);
            Assert.Equal("cab", s.StringShift(inputStr, shift));

            inputStr = "abcdefg";
            shift = Create2dArray(2, 1, 1, 1, 1, 0, 2, 1, 3);
            Assert.Equal("efgabcd", s.StringShift(inputStr, shift));
        }
    }
}