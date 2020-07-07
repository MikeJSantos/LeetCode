using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize? Beats 42.81% of submissions (https://leetcode.com/submissions/detail/344073522)
        public TreeNode BstFromPreorder(int[] preorder)
        {
            TreeNode root = null;

            if (preorder.Length < 0)
                return root;
            
            root = new TreeNode(preorder[0]);

            for (var i = 1; i < preorder.Length; i++)
                BstFromPreorder_Insert(root, preorder[i]);

            return root;
        }

        private void BstFromPreorder_Insert(TreeNode root, int value)
        {
            if (root == null)
                return;

            TreeNode node = root,
                     prevNode = null;

            // Find the new node's parent
            while (node != null)
            {
                prevNode = node;

                if (value > node.val)
                    node = node.right;
                else
                    node = node.left;
            }

            var newNode = new TreeNode(value);
            if (value > prevNode.val)
                prevNode.right = newNode;
            else
                prevNode.left = newNode;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void BstFromPreorderTest()
        {
            var s = new Solution();
            int[] preorder;
            TreeNode expected;

            preorder = new int[] { 8, 5, 1, 7, 10, 12 };
            expected = TreeNode.Build(8, 5, 10, 1, 7, null, 12);
            Assert.Equal(expected, s.BstFromPreorder(preorder));
        }
    }
}