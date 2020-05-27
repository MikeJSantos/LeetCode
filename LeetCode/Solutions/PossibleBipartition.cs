using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize? Beats 30.95% of submissions, 28ms slower than median
        // (https://leetcode.com/submissions/detail/345516225/)
        public bool PossibleBipartition(int N, int[][] dislikes)
        {
            if (N <= 1 || dislikes == null || dislikes.Length == 0)
                return true;

            // Build adjacency dictionary. Key: personA, Value: people personA is connected to
            var adjacencyDictionary = new Dictionary<int, List<int>>();

            for (var i = 0; i < dislikes.Length; i++)
            {
                var personA = dislikes[i][0];
                var personB = dislikes[i][1];

                if (!adjacencyDictionary.ContainsKey(personA))
                    adjacencyDictionary[personA] = new List<int>();
                adjacencyDictionary[personA].Add(personB);

                if (!adjacencyDictionary.ContainsKey(personB))
                    adjacencyDictionary[personB] = new List<int>();
                adjacencyDictionary[personB].Add(personA);
            }

            // Zero index ignored to keep consistency with N range: {1 ... N}
            var wasVisited = new bool[N+1];
            // null: no group, false: 1st group, true: 2nd group
            var inGroup  = new bool?[N+1];

            // Initialize first person
            wasVisited[1] = true;
            inGroup[1]    = false;

            for (var i = 1; i <= N; i++)
            {
                if (!PossibleBipartition_IsBipartite(adjacencyDictionary, wasVisited, inGroup, i))
                    return false;
            }
            
            return true;
        }

        private bool PossibleBipartition_IsBipartite(Dictionary<int, List<int>> adjacencyDictionary, bool[] wasVisited, bool?[] inGroup, int personA)
        {
            if (!adjacencyDictionary.ContainsKey(personA))
                return true;

            foreach(var personB in adjacencyDictionary[personA])
            {
                if (!wasVisited[personB])
                {
                    wasVisited[personB] = true;

                    inGroup[personB] = !inGroup[personA];

                    if (!PossibleBipartition_IsBipartite(adjacencyDictionary, wasVisited, inGroup, personB))
                        return false;
                }
                else if (inGroup[personA] == inGroup[personB])
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
                new int[] { 1, 2 },
                new int[] { 3, 4 },
                new int[] { 4, 5 },
                new int[] { 3, 5 }
            };
            Assert.False(s.PossibleBipartition(N, dislikes));
        }
    }
}