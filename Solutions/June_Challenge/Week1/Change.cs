using System;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public int Change(int amount, int[] coins)
        {
            var count = 0;
            Array.Sort(coins);

            for (var i = 0; i < coins.Length; i++)
            {
                count += Change_Iteration(amount, coins, i);
            }

            return count;
        }

        private int Change_Iteration(int amount, int[] coins, int coinIdx)
        {
            var count = 0;
            var sum = 0;
            var startingDenomination = coins[coinIdx];

            for (var i = 0; i < 500; i++)
            {
                sum += startingDenomination;

                
            }

            return count;
        }
    }

    public partial class UnitTests
    {
        [Fact(Skip = "Incomplete")]
        public void ChangeTest()
        {
            var s = new Solution();
            int amount, expected;
            int[] coins;

            amount   = 5;
            coins    = new int[] { 1, 2, 5 };
            expected = 4;
            Assert.Equal(expected, s.Change(amount, coins));

            amount   = 3;
            coins    = new int[] { 2 };
            expected = 0;
            Assert.Equal(expected, s.Change(amount, coins));

            amount   = 10;
            coins    = new int[] { 10 };
            expected = 1;
            Assert.Equal(expected, s.Change(amount, coins));
        }
    }
}