using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize. Beats 18.22% of submissions (https://leetcode.com/submissions/detail/341321059/)
        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;

            var maxDiameter = 0;
            var nodeQueue = new Queue<TreeNode>();
            nodeQueue.Enqueue(root);

            while (nodeQueue.Any())
            {
                var node = nodeQueue.Dequeue();

                if (node.left != null)
                    nodeQueue.Enqueue(node.left);
                if (node.right != null)
                    nodeQueue.Enqueue(node.right);

                var diameter = DiameterOfBinaryTreeRecurse(node, 0);
                if (diameter > maxDiameter)
                    maxDiameter = diameter;
            }

            return maxDiameter;
        }

        private int DiameterOfBinaryTreeRecurse(TreeNode node, int depth)
        {
            if (node == null)
                return depth - 1; // Redundant?

            var leftDepth = node.left != null
                ? DiameterOfBinaryTreeRecurse(node.left, depth + 1)
                : depth;
            var rightDepth = node.right != null
                ? DiameterOfBinaryTreeRecurse(node.right, depth + 1)
                : depth;

            if (depth == 0)
                return leftDepth + rightDepth;
            else
                return leftDepth >= rightDepth ? leftDepth : rightDepth;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void DiameterOfBinaryTreeTest()
        {
            var s = new Solution();
            TreeNode head;

            var leftNode = new TreeNode(2, 4, 5);
            head = new TreeNode(1, leftNode, new TreeNode(3));
            Assert.Equal(3, s.DiameterOfBinaryTree(head));

            head = new TreeNode(1);
            Assert.Equal(0, s.DiameterOfBinaryTree(head));

            head = new TreeNode(1, new TreeNode(2), null);
            Assert.Equal(1, s.DiameterOfBinaryTree(head));

            head = TreeNode.Build(new int?[] { 
                4, -7, -3, null, null, -9, -3, 9, -7, -4, null, 6, null, -6, -6, null, 
                null, 0, 6, 5, null, 9, null, null, -1, -4, null, null, null, -2
            });
            Assert.Equal(8, s.DiameterOfBinaryTree(head));
        }
    }
}