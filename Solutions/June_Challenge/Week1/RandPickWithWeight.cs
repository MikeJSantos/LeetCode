using System;
using System.Linq;
using Xunit;

namespace LeetCode
{
    public class RandPickWithWeight
    {
        private int[] _weightArray;
        private int weightSum;

        public RandPickWithWeight(int[] w)
        {
            _weightArray = w;
            weightSum = _weightArray.Sum();

            System.Console.WriteLine($"weightSum: {weightSum}");
        }

        public int PickIndex()
        {
            var randomNumber = new Random().Next(1, weightSum);

            for (var i = 0; i < _weightArray.Length; i++)
            {
                if (randomNumber < _weightArray[i])
                    return i;
                randomNumber -= _weightArray[i];
            }

            return new Random().Next(0, _weightArray.Length-1);
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void RandPickWithWeightTest()
        {
            RandPickWithWeight s;
            int[] w;

            // w = new int[] { 1, 2, 3, 4, 5 };
            w = new int[] { 20, 100, 1, 50, 500 };
            s = new RandPickWithWeight(w);

            for (var i = 0; i < 10; i++)
                System.Console.WriteLine($"PickIndex(): {s.PickIndex()}");


            // Test case 56/57 (https://leetcode.com/submissions/detail/349415849)

        }
    }
}