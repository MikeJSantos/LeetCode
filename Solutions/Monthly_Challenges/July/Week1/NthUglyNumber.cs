using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public int NthUglyNumber(int n)
        {
            if (n < 1)
                return 0;

            var uglyNumbersList = new List<int>();
            var excludedPrimeNumbers = new List<int>(); // Prime numbers not 1, 2, 3 or 5
            var uglyNumberArray = new int[][] {
                new int[] { 2, 3, 5 }, // remains static
                new int[] { 2, 3, 5 }, // incremented as ugly numbers
            };

            for (var i = 1; i <= n; i++)
            {
                if (i == 1)
                {
                    uglyNumbersList.Add(i);
                    continue;
                }

                var uglyNumber = uglyNumberArray[1].Min();
                uglyNumbersList.Add(uglyNumber);

                // System.Console.Write($"{uglyNumber} => [{string.Join(',', uglyNumberArray[1])}] => ");

                NthUglyNumber_CalculateNext(uglyNumberArray, uglyNumber, excludedPrimeNumbers);

                // System.Console.WriteLine($"[{string.Join(',', uglyNumberArray[1])}]");
            }

            // System.Console.WriteLine($"Excluded prime numbers [{string.Join(", ", excludedPrimeNumbers)}]");
            // System.Console.WriteLine($"n = {n} [{string.Join(", ", uglyNumbersList)}]");
            return uglyNumbersList.Last();
        }

        private void NthUglyNumber_CalculateNext(int[][] uglyNumberArray, int uglyNumber, List<int> excludedPrimeNumbers)
        {
            for (var colNum = 0; colNum < uglyNumberArray[0].Length; colNum++)
            {
                if (uglyNumberArray[1][colNum] != uglyNumber)
                    continue;

                var factor = uglyNumberArray[0][colNum];

                if (uglyNumber < 5)
                {
                    uglyNumberArray[1][colNum] = uglyNumber + factor;
                    continue;
                }

                var newUglyNumber = uglyNumber;
                do
                {
                    newUglyNumber += factor;

                    var startingNumber = excludedPrimeNumbers.Any()
                        ? excludedPrimeNumbers.Last()
                        : 7;

                    // Construct list of excluded prime numbers (not 1, 2, 3 or 5)
                    for (var num = startingNumber; num <= newUglyNumber / 2; num += 2)
                        if (!excludedPrimeNumbers.Any(i => num % i == 0) && !uglyNumberArray[0].Any(j => num % j == 0))
                            excludedPrimeNumbers.Add(num);

                } while (excludedPrimeNumbers.Any(i => newUglyNumber % i == 0));

                uglyNumberArray[1][colNum] = newUglyNumber;
            }
        }
    }

    public partial class UnitTests
    {
        [Fact(Skip = "Time Limit Exceeded")]
        public void NthUglyNumberTest()
        {
            var s = new Solution();
            int n, expected;

            n = 10;
            expected = 12;
            Assert.Equal(expected, s.NthUglyNumber(n));

            // https://leetcode.com/submissions/detail/366523558
            n = 11;
            expected = 15;
            Assert.Equal(expected, s.NthUglyNumber(n));

            // https://leetcode.com/submissions/detail/366525700
            n = 13;
            expected = 18;
            Assert.Equal(expected, s.NthUglyNumber(n));

            // (TLE) https://leetcode.com/submissions/detail/366544422
            n = 205;
            expected = 36;
            Assert.Equal(expected, s.NthUglyNumber(n));
        }
    }
}