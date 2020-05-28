using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Beats 29.43% of submissions (https://leetcode.com/submissions/detail/342848629/)
        public int MaxProfit(int[] prices)
        {
            var totalProfit = 0;

            if (prices.Length < 2)
                return totalProfit;

            for (var buyDate = 0; buyDate < prices.Length - 1; buyDate++)
            {
                // Find the trough
                if (buyDate + 1 < prices.Length && prices[buyDate] > prices[buyDate + 1])
                    continue;

                for (var sellDate = buyDate + 1; sellDate < prices.Length; sellDate++)
                {
                    // Find the crest
                    if (sellDate + 1 < prices.Length && prices[sellDate] < prices[sellDate + 1])
                        continue;

                    var profit = prices[sellDate] - prices[buyDate];
                    if (profit > 0)
                    {
                        totalProfit += profit;
                        buyDate = sellDate;
                    }

                    break;
                }
            }
            return totalProfit;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void MaxProfitTest()
        {
            var s = new Solution();
            int[] intArray;
            int expected;

            intArray = new int[] { 7, 1, 5, 3, 6, 4 };
            expected = 7;
            Assert.Equal(expected, s.MaxProfit(intArray));

            intArray = new int[] { 1, 2, 3, 4, 5 };
            expected = 4;
            Assert.Equal(expected, s.MaxProfit(intArray));

            intArray = new int[] { 7, 6, 4, 3, 1 };
            expected = 0;
            Assert.Equal(expected, s.MaxProfit(intArray));

            intArray = new int[] { 1, 2 };
            expected = 1;
            Assert.Equal(1, s.MaxProfit(intArray));

            intArray = new int[] { 2, 1, 4, 5, 2, 9, 7 };
            expected = 11;
            Assert.Equal(expected, s.MaxProfit(intArray));
        }
    }
}