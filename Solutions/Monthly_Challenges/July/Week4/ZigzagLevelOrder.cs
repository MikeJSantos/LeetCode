using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Beats 27.67% of submissions (88ms/35% slower than mode)
        // https://leetcode.com/submissions/detail/370158402
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var treeListDictionary = new Dictionary<int, List<int>>();
            ZigzagLevelOrder_Recurse(root, treeListDictionary, 1);

            var zigzagList = new List<IList<int>>();

            foreach(var level in treeListDictionary.Keys)
            {
                var levelList = treeListDictionary[level];
                if (level % 2 == 0)
                    levelList.Reverse();
                zigzagList.Add(levelList);
            }

            return zigzagList;
        }

        private void ZigzagLevelOrder_Recurse(TreeNode node, Dictionary<int, List<int>> treeListDictionary, int level)
        {
            if (node == null)
                return;

            if (!treeListDictionary.ContainsKey(level))
                treeListDictionary[level] = new List<int>();

            treeListDictionary[level].Add(node.val);

            if (node.left != null)
                ZigzagLevelOrder_Recurse(node.left, treeListDictionary, level+1);
            if (node.right != null)
                ZigzagLevelOrder_Recurse(node.right, treeListDictionary, level+1);
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void ZigzagLevelOrderTest()
        {
            var s = new Solution();
            TreeNode root;
            IList<IList<int>> expected;

            root = TreeNode.Build(3, 9, 20, null, null, 15, 7);
            expected = new List<IList<int>>() {
                new List<int> { 3 },
                new List<int> { 20, 9 },
                new List<int> { 15, 7 },
            };
            Assert.Equal(expected, s.ZigzagLevelOrder(root));
        }
    }
}