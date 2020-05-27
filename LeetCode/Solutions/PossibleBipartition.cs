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
            if (N < 1 || dislikes == null || dislikes.Length < 1)
                return true;

            List<int> groupA = new List<int>(),
                      groupB = new List<int>();

            for (var pairIdx = 0; pairIdx < dislikes.Length; pairIdx++)
                if (!PossibleBipartition_AddToGroups(groupA, groupB, dislikes, pairIdx))
                {
                    System.Console.WriteLine($"False [{string.Join(',',groupA)}], [{string.Join(',',groupB)}] on pair {pairIdx}/{dislikes.Length}: [{string.Join(',',dislikes[pairIdx])}]");
                    return false;
                }
                    

            return true;
        }

        private bool PossibleBipartition_AddToGroups(List<int> groupA, List<int> groupB, int[][] dislikes, int pairIdx)
        {
            var p1 = dislikes[pairIdx][0];
            var p2 = dislikes[pairIdx][1];
            var isP1Added = groupA.Contains(p1) || groupB.Contains(p1);
            var isP2Added = groupA.Contains(p2) || groupB.Contains(p2);

            if (!isP1Added && !isP2Added)
            {
                groupA.Add(p1);
                groupB.Add(p2);
                return true;
            }
            
            if (isP1Added && isP2Added)
            {
                // Verify that p1 & p2 are in opposite groups
                if ((groupA.Contains(p1) && groupB.Contains(p2)) ||
                    (groupA.Contains(p2) && groupB.Contains(p1)))
                    return true;

                if ((groupA.Contains(p1) && groupA.Contains(p2)))
                {   // If both exist in A, try to move one to group B
                    if (PossibleBipartition_IsSwitchValid(groupA, groupB, p1, dislikes, pairIdx))
                        return true;
                    else if (PossibleBipartition_IsSwitchValid(groupA, groupB, p2, dislikes, pairIdx))
                        return true;
                    else
                        return false;
                }
                else
                {   // If both exist in B, try to move one to group A
                    if (PossibleBipartition_IsSwitchValid(groupB, groupA, p1, dislikes, pairIdx))
                        return true;
                    else if (PossibleBipartition_IsSwitchValid(groupB, groupA, p2, dislikes, pairIdx))
                        return true;
                    else
                        return false;
                }
            }

            // Find which group p2 is in & add p1 to the opposite group
            if (!isP1Added && isP2Added)
            {
                if (groupA.Contains(p2))
                    groupB.Add(p1);
                else
                    groupA.Add(p1);

                return true;
            }

            // Find which group p1 is in & add p2 to the opposite group
            if (isP1Added && !isP2Added)
            {
                if (groupA.Contains(p1))
                    groupB.Add(p2);
                if (groupB.Contains(p1))
                    groupA.Add(p2);

                return true;
            }

            return false;
        }

        private bool PossibleBipartition_IsSwitchValid(List<int> sourceGroup, List<int> targetGroup, int person, int[][] dislikes, int dislikeIdx)
        {
            var tempTargetGroup = new List<int>(targetGroup);
            tempTargetGroup.Add(person);

            for (var pairIdx = 0; pairIdx <= dislikeIdx; pairIdx++)
            {
                var p1 = dislikes[pairIdx][0];
                var p2 = dislikes[pairIdx][1];
                if (tempTargetGroup.Contains(p1) && tempTargetGroup.Contains(p2))
                {
                    System.Console.WriteLine($"- Add {person} to [{string.Join(',', targetGroup)}] failed. dislikes[{pairIdx}] => [{p1},{p2}]");
                    return false;
                }
            }

            sourceGroup.Remove(person);
            targetGroup.Add(person);
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
            // Assert.True(s.PossibleBipartition(N, dislikes));

            N = 3;
            dislikes = new int[][] {
                new int[] { 1, 2 },
                new int[] { 1, 3 },
                new int[] { 2, 3 },
            };
            // Assert.False(s.PossibleBipartition(N, dislikes));

            N = 5;
            dislikes = new int[][] {
                new int[] { 1, 2 },
                new int[] { 2, 3 },
                new int[] { 3, 4 },
                new int[] { 4, 5 },
                new int[] { 1, 5 },
            };
            // Assert.False(s.PossibleBipartition(N, dislikes));

            // Test case 40/66 (https://leetcode.com/submissions/detail/345420300)
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
        }
    }
}