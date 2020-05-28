using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize? Beats 73.56% of submissions (https://leetcode.com/submissions/detail/342950803)
        public bool IsPerfectSquare(int num)
        {
            if (num < 1)
                return false;

            var numStr = num.ToString();
            if (numStr.Length % 2 == 1)
                numStr = "0" + numStr;

            int remainder = 0,
                lastQuotient = 1,
                calculation;

            for (var chunkIdx = 0; chunkIdx < numStr.Length / 2; chunkIdx++)
            {
                var chunkStr = remainder.ToString() + numStr.Substring(chunkIdx * 2, 2);
                var chunk = int.Parse(chunkStr);
                var isFirstChunk = chunkIdx == 0;

                if (chunk == 0)
                    break;

                for (var digit = 1; digit <= 100; digit++)
                {
                    calculation = GetCalculation(isFirstChunk, digit, lastQuotient);

                    if (calculation >= chunk)
                    {
                        if (calculation > chunk)
                        {
                            digit--;
                            calculation = GetCalculation(isFirstChunk, digit, lastQuotient);
                        }

                        remainder = chunk - calculation;
                        lastQuotient = (chunkIdx == 0)
                            ? digit
                            : lastQuotient * 10 + digit;
                        break;
                    }
                }
            }

            return remainder == 0;
        }

        private int GetCalculation(bool isFirstChunk, int digit, int lastQuotient)
        {
            return isFirstChunk
                ? digit * digit
                : ((20 * lastQuotient) + digit) * digit;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void IsPerfectSquareTest()
        {
            var s = new Solution();

            Assert.True(s.IsPerfectSquare(1));
            Assert.False(s.IsPerfectSquare(7));
            Assert.True(s.IsPerfectSquare(9));
            Assert.True(s.IsPerfectSquare(16));
            Assert.False(s.IsPerfectSquare(2147483647));

            // Test case 37/70 - https://leetcode.com/submissions/detail/341343931/
            Assert.True(s.IsPerfectSquare(808201));
        }
    }
}