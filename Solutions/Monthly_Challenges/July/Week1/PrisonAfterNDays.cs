using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution {
        public int[] PrisonAfterNDays(int[] cells, int N) {
            if (cells == null || cells.Length < 3 || N < 1)
                return cells;
            
            // System.Console.WriteLine($"Day 0: [{string.Join(", ", cells)}]");
            var cellDictionary = new Dictionary<string,int[]>();
            var loopList = new List<string>();

            for (var day = 1; day <= N; day++)
            {
                if (day % 5000000 == 0)
                    System.Console.WriteLine($"Day: {String.Format("{0:n0}", day)} / {String.Format("{0:n0}", N)}");
                
                var key = string.Join(',', cells);

                if (cellDictionary.ContainsKey(key))
                {
                    // TODO: Check for loop detection
                    cells = cellDictionary[key];
                    continue;
                }

                var tempCells = new int[cells.Length];

                for (var cellNum = 1; cellNum < cells.Length - 1; cellNum++)
                {
                    tempCells[cellNum] = cells[cellNum - 1] == cells[cellNum + 1]
                        ? 1 : 0;
                }

                if (day == 1)
                {
                    tempCells[0] = 0;
                    tempCells[tempCells.Length-1] = 0;
                }
                
                cellDictionary[key] = tempCells;
                cells = tempCells;
            }

            return cells;
        }
    }

    public partial class UnitTests
    {
        [Fact(Skip = "Implement loop detection")]
        public void PrisonAfterNDaysTest()
        {
            var s = new Solution();
            int[] cells, expected;
            int N;

            cells    = new int[] { 0, 1, 0, 1, 1, 0, 0, 1 };
            N        = 7;
            expected = new int[] { 0, 0, 1, 1, 0, 0, 0, 0 };
            Assert.Equal(expected, s.PrisonAfterNDays(cells, N));

            cells    = new int[] { 1, 0, 0, 1, 0, 0, 1, 0 };
            N        = 1000000000;
            expected = new int[] { 0, 0, 1, 1, 1, 1, 1, 0 };
            Assert.Equal(expected, s.PrisonAfterNDays(cells, N));
        }
    }
}