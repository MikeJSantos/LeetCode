using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Submission not ranked (https://leetcode.com/submissions/detail/337539911/)
        public int FindJudge(int N, int[][] trust)
        {
            if (N == 1) return 1;
            if (N < 1 || trust.Length == 0) return -1;

            var trustDictionary = new Dictionary<int, int>();
            var cannotBeAJudge = new List<int>();

            for (int row = 0; row < trust.Length; row++)
            {
                var truster = trust[row][0];
                var trustee = trust[row][1];

                // 1. The town judge trusts nobody.
                if (!cannotBeAJudge.Contains(truster))
                {
                    cannotBeAJudge.Add(truster);
                    if (trustDictionary.ContainsKey(truster))
                        trustDictionary.Remove(truster);
                }

                if (!cannotBeAJudge.Contains(trustee))
                {
                    trustDictionary[trustee] = trustDictionary.ContainsKey(trustee)
                        ? trustDictionary[trustee] + 1
                        : 1;
                }
            }

            if (!trustDictionary.Any())
                return -1;

            var maxTrust = trustDictionary.Values.Max();

            // 2. Everybody (except for the town judge) trusts the town judge.
            // 3. There is exactly one person that satisfies properties 1 and 2.
            if (maxTrust != N - 1 || trustDictionary.Values.Count(v => v == maxTrust) > 1)
                return -1;

            return trustDictionary.First(v => v.Value == maxTrust).Key;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void FindJudgeTest()
        {
            var s = new Solution();
            int[][] trust;

            trust = new int[][] {
                new int[] {1, 2}
            };
            Assert.Equal(2, s.FindJudge(2, trust));

            trust = new int[][] {
                new int[] {1, 3},
                new int[] {2, 3},
            };
            Assert.Equal(3, s.FindJudge(3, trust));

            trust = new int[][] {
                new int[] {1, 3},
                new int[] {2, 3},
                new int[] {3, 1},
            };
            Assert.Equal(-1, s.FindJudge(3, trust));

            trust = new int[][] {
                new int[] {1, 2},
                new int[] {2, 3},
            };
            Assert.Equal(-1, s.FindJudge(3, trust));

            trust = new int[][] {
                new int[] {1, 3},
                new int[] {1, 4},
                new int[] {2, 3},
                new int[] {2, 4},
                new int[] {4, 3}
            };
            Assert.Equal(3, s.FindJudge(4, trust));

            trust = new int[][] { };
            Assert.Equal(1, s.FindJudge(1, trust));

            trust = new int[][] {
                new int[] {1, 2},
                new int[] {3, 2},
                new int[] {1, 3},
                new int[] {4, 1},
                new int[] {3, 1},
                new int[] {2, 1},
                new int[] {2, 3},
                new int[] {4, 3},
                new int[] {4, 2},
                new int[] {3, 4},
                new int[] {2, 4}
            };
            Assert.Equal(-1, s.FindJudge(4, trust));
        }
    }
}