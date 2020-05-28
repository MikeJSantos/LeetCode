using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public bool CheckStraightLine(int[][] coordinates)
        {
            if (coordinates == null || coordinates.GetLength(0) < 2)
                return false;

            int rise = 0, run = 0;
            double slope = double.MinValue, initialSlope = double.MinValue;

            for (var row = 1; row < coordinates.GetLength(0); row++)
            {
                if (coordinates[row].Length < 2)
                    return false;

                rise  = coordinates[row][1] - coordinates[row-1][1];
                run   = coordinates[row][0] - coordinates[row-1][0];
                slope = (double) rise / run;

                if (row == 1)
                    initialSlope = slope;
                else if (slope != initialSlope)
                    return false;
            }

            return true;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void CheckStraightLineTest()
        {
            var s = new Solution();
            int[][] coordinates;

            coordinates = new int[][] {
                new int[] {1,2},
                new int[] {2,3},
                new int[] {3,4},
                new int[] {4,5},
                new int[] {5,6},
                new int[] {6,7}
            };
            Assert.True(s.CheckStraightLine(coordinates));

            coordinates = new int[][] {
                new int[] {1,1},
                new int[] {2,2},
                new int[] {3,4},
                new int[] {4,5},
                new int[] {5,6},
                new int[] {7,7}
            };
            Assert.False(s.CheckStraightLine(coordinates));
        }
    }
}