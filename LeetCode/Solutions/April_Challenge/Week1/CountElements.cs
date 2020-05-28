using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public int CountElements(int[] arr)
        {
            if (arr.Length < 2)
                return 0;

            var counter = 0;
            Array.Sort(arr);
            var duplicates = new Dictionary<int, int>();

            for (var i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] + 1 == arr[i + 1])
                    counter += duplicates.ContainsKey(arr[i]) ? duplicates[arr[i]] : 1;

                // Add duplicates to a dictionary
                if (arr[i] == arr[i + 1])
                {
                    var j = i;
                    while (j < arr.Length - 1 && arr[j] == arr[j + 1])
                        j++;

                    duplicates[arr[i]] = j - i + 1;
                    i = j - 1;
                }
            }

            return counter;
        }

        public partial class UnitTests
        {
            [Fact]
            public void CountElementsTest()
            {
                var s = new Solution();
                int[] arr;

                arr = new int[] { 1, 2, 3 }; // 2
                Assert.Equal(2, s.CountElements(arr));

                arr = new int[] { 1, 1, 3, 3, 5, 5, 7, 7 }; // 0
                Assert.Equal(0, s.CountElements(arr));

                arr = new int[] { 1, 3, 2, 3, 5, 0 }; // 3
                Assert.Equal(3, s.CountElements(arr));

                arr = new int[] { 1, 1, 1, 1, 2, 2 }; // 4
                Assert.Equal(4, s.CountElements(arr));
            }
        }
    }
}