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

            coordinates = Create2dArray(2, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7);
            Assert.True(s.CheckStraightLine(coordinates));

            coordinates = Create2dArray(2, 1, 1, 2, 2, 3, 4, 4, 5, 5, 6, 7, 7);
            Assert.False(s.CheckStraightLine(coordinates));
        }
    }
}