using System;
using System.Linq;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // named Solve() in LC problem
        public void SurroundedRegions(char[][] board)
        {
            if (board == null || board.Length < 3 || board[0].Length < 3)
                return;

            for (var rowIdx = 1; rowIdx < board.Length - 1; rowIdx++)
                for (var colIdx = 1; colIdx < board[rowIdx].Length - 1; colIdx++)
                {
                    if (board[rowIdx][colIdx] == 'X')
                        continue;

                    // System.Console.WriteLine($"Checking [{rowIdx},{colIdx}]");

                    // Check horizontally
                    var isHorizontallySurrounded = SurroundedRegions_IsSurrounded(board[rowIdx], colIdx);

                    // Check vertically (get vertical slice first)
                    var colArray = Enumerable.Range(0, board.Length)
                        .Select(x => board[x][colIdx])
                        .ToArray();
                    var isVerticallySurrounded = SurroundedRegions_IsSurrounded(colArray, rowIdx);

                    // var str = isHorizontallySurrounded && isVerticallySurrounded ? "" : " NOT";
                    // System.Console.WriteLine($" [{rowIdx},{colIdx}] is{str} surrounded");

                    if (isHorizontallySurrounded && isVerticallySurrounded)
                    {
                        board[rowIdx][colIdx] = 'X';
                    }
                }
        }

        private bool SurroundedRegions_IsSurrounded(char[] array, int index)
        {
            // Check left/above
            var subArray = new char[index];
            Array.Copy(array, subArray, index);

            if (!Array.Exists(subArray, c => c == 'X'))
                return false;

            // Check right/below
            subArray = new char[array.Length - index - 1];
            Array.Copy(array, index + 1, subArray, 0, subArray.Length);

            return Array.Exists(subArray, c => c == 'X');
        }
    }

    public partial class UnitTests
    {
        [Fact(Skip = "Incomplete")]
        public void SurroundedRegionsTest()
        {
            var s = new Solution();
            char[][] board, expected;

            board = Read2dCharArrayFromFile("SurroundedRegions_input.txt", ' ');
            s.SurroundedRegions(board);
            expected = Read2dCharArrayFromFile("SurroundedRegions_output.txt", ' ');
            Assert.Equal(expected, board);

            board = Read2dCharArrayFromFile("SurroundedRegions_28_input.txt", ' ');
            s.SurroundedRegions(board);
            expected = Read2dCharArrayFromFile("SurroundedRegions_28_output.txt", ' ');
            Assert.Equal(expected, board);

            board = Read2dCharArrayFromFile("SurroundedRegions_37_input.txt", ' ');
            Print2dCharArray("Input", board);
            s.SurroundedRegions(board);
            Print2dCharArray("Output", board);
            expected = Read2dCharArrayFromFile("SurroundedRegions_37_output.txt", ' ');
            Print2dCharArray("Expected", expected);
            Assert.Equal(expected, board);
        }
    }
}