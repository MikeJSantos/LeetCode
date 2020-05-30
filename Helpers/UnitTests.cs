using System;
using System.Linq;
using System.IO;
using Xunit;

namespace LeetCode
{
    public partial class UnitTests
    {
        private string ReadTestDataFromFile(string fileName)
        {
            var basePath = Directory.GetCurrentDirectory();

            var path = Path.Combine(basePath, "TestData", fileName);
            using (var sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }

        private int[] ReadIntArrayFromFile(string fileName)
        {
            return ReadTestDataFromFile(fileName)
                .Split(',')
                .Select(n => Convert.ToInt32(n))
                .ToArray();
        }

        private int[][] Create2dArray(int elementsPerRow, params int[] inputs)
        {
            if (elementsPerRow < 1 || inputs.Length == 0)
                return new int[][] {};

            var numRows = (int) Math.Ceiling((double) inputs.Length/elementsPerRow);
            var array = new int[numRows][];

            for (var rowIdx = 0; rowIdx < numRows; rowIdx++)
            {
                var sourceIndex = rowIdx * elementsPerRow;
                var length = (sourceIndex + elementsPerRow <= inputs.Length)
                    ? elementsPerRow
                    : inputs.Length - sourceIndex;
                var row = new int[length];
                Array.Copy(inputs, sourceIndex, row, 0, length);
                array[rowIdx] = row;
            }
            
            return array;
        }

        [Fact]
        public void Create2dArrayTest()
        {
            int[][] expected;

            expected = new int[][] {
                new int[] { 1, 2 },
                new int[] { 3, 4 }
            };
            Assert.Equal(expected, Create2dArray(2, 1, 2, 3, 4));

            expected = new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5 }
            };
            Assert.Equal(expected, Create2dArray(3, 1, 2, 3, 4, 5));
        }
    }
}