using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // Beats 80% of submissions. https://leetcode.com/submissions/detail/354021662
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
                return null;
            else if (root.val == val) 
                return root;
            // Using else if shaves off 64ms?! https://leetcode.com/submissions/detail/354021486

            var node = root.val > val
                ? root.left
                : root.right;

            return SearchBST(node, val);
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void SearchBSTTest()
        {
            var s = new Solution();
            TreeNode root, expected;
            int val;

            root     = TreeNode.Build(4, 2, 7, 1, 3);
            val      = 2;
            expected = TreeNode.Build(2, 1, 3);
            Assert.Equal(expected, s.SearchBST(root, val));
        }
    }
}