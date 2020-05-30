using System;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Beats 19.81% of submissions (https://leetcode.com/submissions/detail/342756876)
        public int CountSquares(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return 0;

            int totalSquares = 0, maxSize;

            // contains the max size for given row, col (ex: squaresArray[1,2] = 3 means biggest square at [1,2] is 3x3)
            int[,] squaresArray = new int[matrix.Length, matrix[0].Length];

            for (var row = 0; row < matrix.Length; row++)
                for (var col = 0; col < matrix[row].Length; col++)
                {
                    maxSize = Math.Min(matrix.Length - row, matrix[row].Length - col);
                    CountSquares_SubarrayCheck(matrix, row, col, maxSize, squaresArray, ref totalSquares);
                }

            return totalSquares;
        }

        private void CountSquares_SubarrayCheck(int[][] matrix, int startRow, int startCol, int maxSize, int[,] squaresArray, ref int totalSquares)
        {
            if (matrix[startRow][startCol] != 1)
                return;

            for (var size = 1; size <= maxSize; size++)
            {
                if (size == 1)
                {
                    squaresArray[startRow, startCol] = size;
                    totalSquares++;
                    continue;
                }

                // If a 3x3 array at [0,0] exists, then a 2x2 array at [1,1] exists
                if (startRow - 1 >= 0 &&
                    startCol - 1 >= 0 &&
                    size + 1 <= maxSize &&
                    squaresArray[startRow - 1, startCol - 1] >= size + 1)
                {
                    squaresArray[startRow, startCol] = size;
                    totalSquares++;
                    continue;
                }

                // Manually check NxN array at [startRow, startCol]
                var isSquare = true;
                for (var row = startRow; row < startRow + size; row++)
                    for (var col = startCol; col < startCol + size; col++)
                        if (matrix[row][col] != 1)
                        {
                            isSquare = false;
                            break;
                        }

                if (isSquare)
                {
                    squaresArray[startRow, startCol] = size;
                    totalSquares++;
                }
                else
                    break;
            }
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void CountSquaresTest()
        {
            var s = new Solution();
            int[][] matrix;
            int expected;

            matrix = Create2dArray(4, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1);
            expected = 15; // 10 (1), 4 (2), 1 (3)
            Assert.Equal(expected, s.CountSquares(matrix));

            matrix = Create2dArray(3, 1, 0, 1, 1, 1, 0, 1, 1, 0);
            expected = 7; // 6 (1), 1 (2)
            Assert.Equal(expected, s.CountSquares(matrix));

            // test case 21/32
            matrix = Create2dArray(5, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1);
            expected = 19; // 17 (1), 2 (2)
            Assert.Equal(expected, s.CountSquares(matrix));
        }
    }
}