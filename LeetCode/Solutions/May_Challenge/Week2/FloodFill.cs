using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            if (!FloodFill_IsCoordinateValid(image, sr, sc) || !FloodFill_IsColorValid(newColor))
                return image;

            var matchColor = image[sr][sc];

            if (!FloodFill_IsColorValid(matchColor) || matchColor == newColor)
                return image;

            FloodFill_Recurse(image, sr, sc, matchColor, newColor);

            return image;
        }

        private void FloodFill_Recurse(int[][] image, int row, int col, int matchColor, int newColor)
        {
            if (!FloodFill_IsCoordinateValid(image, row, col)) return;

            if (image[row][col] == matchColor)
            {
                image[row][col] = newColor;
                FloodFill_Recurse(image, row-1, col, matchColor, newColor);
                FloodFill_Recurse(image, row+1, col, matchColor, newColor);
                FloodFill_Recurse(image, row, col-1, matchColor, newColor);
                FloodFill_Recurse(image, row, col+1, matchColor, newColor);
            }
        }

        private bool FloodFill_IsCoordinateValid(int[][] image, int row, int col)
        {
            return row >= 0 && row < image.Length && col >= 0 && col < image[row].Length;
        }

        private bool FloodFill_IsColorValid(int color)
        {
            return color >= 0 && color <= 65535;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void FloodFillTest()
        {
            var s = new Solution();
            int[][] image, retVal;
            int sr, sc, newColor;

            image = new int[][] {
                new int[] {1,1,1},
                new int[] {1,1,0},
                new int[] {1,0,1}
            };
            sr = 1;
            sc = 1;
            newColor = 2;

            retVal = new int[][] {
                new int[] {2,2,2},
                new int[] {2,2,0},
                new int[] {2,0,1}
            };

            Assert.Equal(retVal, s.FloodFill(image, sr, sc, newColor));

            image = new int[][] {
                new int[] {0,0,0},
                new int[] {0,1,1},
            };
            sr = 1;
            sc = 1;
            newColor = 1;
            Assert.Equal(image, s.FloodFill(image, sr, sc, newColor));
        }
    }
}