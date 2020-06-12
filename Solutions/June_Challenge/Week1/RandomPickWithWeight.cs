using System;
using System.Linq;
using Xunit;

namespace LeetCode
{
    // Optimize. Beats 27.69% of submissions. 2x / 228ms slower than median
    public class RandomPickWithWeight
    {
        private Random _random;
        private int[] _weightArray;
        private int _weightSum;

        public RandomPickWithWeight(int[] w)
        {
            _random      = new Random();
            _weightArray = w;
            _weightSum   = _weightArray.Sum();
        }

        public int PickIndex()
        {
            var randomNumber = _random.Next() % _weightSum;

            // TODO: This is slow. Find a faster algorithm
            for (var i = 0; i < _weightArray.Length; i++)
            {
                if (randomNumber < _weightArray[i])
                    return i;
                randomNumber -= _weightArray[i];
            }

            return _random.Next() % _weightArray.Length;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void RandPickWithWeightTest()
        {
            RandomPickWithWeight s;
            int[] w;

            // w = new int[] { 1, 2, 3, 4, 5 };
            w = new int[] { 20, 100, 1, 50, 500 };
            s = new RandomPickWithWeight(w);

            for (var i = 0; i < 10; i++)
                System.Console.WriteLine($"PickIndex(): {s.PickIndex()}");


            // Test case 56/57 (https://leetcode.com/submissions/detail/349415849)

        }
    }
}