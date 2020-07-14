using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // Beats 76.73% of submissions (12ms/5% slower than mode)
        // https://leetcode.com/submissions/detail/366504408
        public int[] PrisonAfterNDays(int[] cells, int N)
        {
            if (cells == null || cells.Length < 3 || N < 1)
                return cells;

            var cellDictionary = new Dictionary<string, int[]>();
            var loopList = new List<string>();

            for (var day = 1; day <= N; day++)
            {
                var key = string.Join("", cells);

                if (loopList.Contains(key))
                {
                    var daysRemaining = N - day;
                    var loopSize      = loopList.Count() - loopList.IndexOf(key);
                    var dayOffset     = daysRemaining % loopSize;
                    var finalKey      = loopList[loopList.IndexOf(key) + dayOffset];
                    return cellDictionary[finalKey];
                }
                else if (cellDictionary.ContainsKey(key))
                {
                    cells = cellDictionary[key];
                    loopList.Add(key);
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
                    tempCells[tempCells.Length - 1] = 0;
                }

                cells = tempCells;
                loopList.Add(key);
                cellDictionary[key] = tempCells;
            }

            return cells;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void PrisonAfterNDaysTest()
        {
            var s = new Solution();
            int[] cells, expected;
            int N;

            cells = new int[] { 0, 1, 0, 1, 1, 0, 0, 1 };
            N = 7;
            expected = new int[] { 0, 0, 1, 1, 0, 0, 0, 0 };
            Assert.Equal(expected, s.PrisonAfterNDays(cells, N));

            cells = new int[] { 1, 0, 0, 1, 0, 0, 1, 0 };
            N = 1000000000;
            expected = new int[] { 0, 0, 1, 1, 1, 1, 1, 0 };
            Assert.Equal(expected, s.PrisonAfterNDays(cells, N));
        }
    }
}