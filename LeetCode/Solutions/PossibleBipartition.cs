using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public bool PossibleBipartition(int N, int[][] dislikes)
        {
            if (N <= 1 || dislikes == null || dislikes.Length == 0)
                return true;

            // Build graph dictionary. Key: person1, Value: people person1 is connected to
            var adjacencyDictionary = new Dictionary<int, List<int>>();

            for (var i = 0; i < dislikes.Length; i++)
            {
                var person1 = dislikes[i][0];
                var person2 = dislikes[i][1];

                if (!adjacencyDictionary.ContainsKey(person1))
                    adjacencyDictionary[person1] = new List<int>();
                adjacencyDictionary[person1].Add(person2);

                if (!adjacencyDictionary.ContainsKey(person2))
                    adjacencyDictionary[person2] = new List<int>();
                adjacencyDictionary[person2].Add(person1);
            }

            // Zero index ignored to keep consistency with N range: {1 ... N}
            var wasVisited = new bool[N+1];
            // null: no group, false: group A, true: group B
            var inGroup  = new bool?[N+1];

            // Set first person to Group A
            inGroup[1] = false;
            return PossibleBipartition_IsBipartite(adjacencyDictionary, wasVisited, inGroup, 1);
        }

        private bool PossibleBipartition_IsBipartite(Dictionary<int, List<int>> adjacencyDictionary, bool[] wasVisited, bool?[] inGroup, int person1)
        {
            foreach(var person2 in adjacencyDictionary[person1])
            {
                if (!wasVisited[person2])
                {
                    wasVisited[person2] = true;

                    inGroup[person2] = !inGroup[person1];

                    if (!PossibleBipartition_IsBipartite(adjacencyDictionary, wasVisited, inGroup, person2))
                        return false;
                }
                else if (inGroup[person1] == inGroup[person2])
                    return false;
            }

            return true;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void PossibleBipartitionTest()
        {
            var s = new Solution();
            int N;
            int[][] dislikes;

            N = 4;
            dislikes = new int[][] {
                new int[] { 1, 2 },
                new int[] { 1, 3 },
                new int[] { 2, 4 },
            };
            Assert.True(s.PossibleBipartition(N, dislikes));

            N = 3;
            dislikes = new int[][] {
                new int[] { 1, 2 },
                new int[] { 1, 3 },
                new int[] { 2, 3 },
            };
            Assert.False(s.PossibleBipartition(N, dislikes));

            N = 5;
            dislikes = new int[][] {
                new int[] { 1, 2 },
                new int[] { 2, 3 },
                new int[] { 3, 4 },
                new int[] { 4, 5 },
                new int[] { 1, 5 },
            };
            Assert.False(s.PossibleBipartition(N, dislikes));

            // Test case 41/66 (https://leetcode.com/submissions/detail/345420300)
            N = 10;
            var dislikesList = new List<int[]>();

            var fileInput = ReadTestDataFromFile("PossibleBipartition_input.txt")
                .Split(new[] { "\r\n", "\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var str in fileInput)
            {
                var line = str.Split(',')
                    .Select(n => Convert.ToInt32(n))
                    .ToArray();
                dislikesList.Add(line);
            }

            dislikes = dislikesList.ToArray();
            Assert.True(s.PossibleBipartition(N, dislikes));

            // Test case 66/66 (https://leetcode.com/submissions/detail/345505746/)
            N = 5;
            dislikes = new int[][] {
                new int[] {1,2},
                new int[] {3,4},
                new int[] {4,5},
                new int[] {3,5}
            };
            Assert.False(s.PossibleBipartition(N, dislikes));
        }
    }
}