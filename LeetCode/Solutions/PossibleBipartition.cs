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

            foreach (var pair in dislikes)
                if (!AddPeopleToGroups(groupA, groupB, pair))
                {
                    System.Console.WriteLine($"GroupA: [{string.Join(',',groupA)}]\nGroupB: [{string.Join(',',groupB)}]\nPair: [{string.Join(',',pair)}]");
                    return false;
                }
                    

            return true;
        }

        private bool AddPeopleToGroups(List<int> groupA, List<int> groupB, int[] pair)
        {
            var p1 = pair[0];
            var p2 = pair[1];
            var isP1Added = groupA.Contains(p1) || groupB.Contains(p1);
            var isP2Added = groupA.Contains(p2) || groupB.Contains(p2);

            if (!isP1Added && !isP2Added)
            {
                groupA.Add(p1);
                groupB.Add(p2);
                return true;
            }

            // Verify that p1 & p2 are in opposite groups
            if (isP1Added && isP2Added)
            {
                return (groupA.Contains(p1) && groupB.Contains(p2)) ||
                       (groupA.Contains(p2) && groupB.Contains(p1));
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
            dislikes = new int[][] {
                new int[] {4,7},
                new int[] {4,8},
                new int[] {2,8},
                new int[] {8,9},
                new int[] {1,6},
                new int[] {5,8},
                new int[] {1,2}, // Both exist in A. Try to move 1/2 to group B
                new int[] {6,7},
                new int[] {3,10},
                new int[] {8,10},
                new int[] {1,5},
                new int[] {7,10},
                new int[] {1,10},
                new int[] {3,5},
                new int[] {3,6},
                new int[] {1,4},
                new int[] {3,9},
                new int[] {2,3},
                new int[] {1,9},
                new int[] {7,9},
                new int[] {2,7},
                new int[] {6,8},
                new int[] {5,7},
                new int[] {3,4}
            };
            Assert.True(s.PossibleBipartition(N, dislikes));
        }
    }
}