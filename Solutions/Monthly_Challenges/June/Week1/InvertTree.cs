using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize? Beats 78.91% of submissions
        // https://leetcode.com/submissions/detail/347578702
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return root;

            var queue = new Queue<TreeNode>();
            var retVal = root;
            queue.Enqueue(retVal);

            while (queue.Any())
            {
                var node = queue.Dequeue();
                var temp = node.left;
                node.left = node.right;
                node.right = temp;

                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }

            return retVal;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void InvertTreeTest()
        {
            var s = new Solution();
            TreeNode root, expected;

            root     = TreeNode.Build(4, 2, 7, 1, 3, 6, 9);
            expected = TreeNode.Build(4, 7, 2, 9, 6, 3, 1);
            Assert.Equal(expected, s.InvertTree(root));
        }
    }
}