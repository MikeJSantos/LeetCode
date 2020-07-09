using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Faster than 8.67% of submissions (172ms/69% slower than mode)
        // https://leetcode.com/submissions/detail/364326703
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            if (root == null)
                return new List<IList<int>>();

            var lvlOrderValsDictionary = new Dictionary<int, List<int>>();
            LevelOrderBottom_Recurse(root, lvlOrderValsDictionary, 0);

            var retVal = new List<IList<int>>();
            foreach (var key in lvlOrderValsDictionary.Keys.OrderByDescending(k => k))
            {
                retVal.Add(lvlOrderValsDictionary[key]);
            }

            return retVal;
        }

        private void LevelOrderBottom_Recurse(TreeNode node, Dictionary<int, List<int>> lvlOrderValsDictionary, int level)
        {
            if (node == null)
                return;

            if (!lvlOrderValsDictionary.ContainsKey(level))
                lvlOrderValsDictionary[level] = new List<int>();

            lvlOrderValsDictionary[level].Add(node.val);

            LevelOrderBottom_Recurse(node.left, lvlOrderValsDictionary, level+1);
            LevelOrderBottom_Recurse(node.right, lvlOrderValsDictionary, level+1);
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void LevelOrderBottomTest()
        {
            var s = new Solution();
            TreeNode root;
            List<List<int>> expected;

            root = null;
            expected = new List<List<int>>();
            Assert.Equal(expected, s.LevelOrderBottom(root));

            root = TreeNode.Build(3, 9, 20, null, null, 15, 7);
            expected = new List<List<int>> {
                new List<int> { 15, 7},
                new List<int> { 9, 20},
                new List<int> { 3 }
            };
            Assert.Equal(expected, s.LevelOrderBottom(root));
        }
    }
}