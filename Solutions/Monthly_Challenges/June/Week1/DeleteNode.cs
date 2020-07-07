using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public void DeleteNode(ListNode node)
        {
            while (node != null)
            {
                node.val = node.next.val;
                if (node.next.next == null)
                    node.next = null;
                node = node.next;
            }
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void DeleteNodeTest()
        {
            var s = new Solution();
            ListNode before, after, nodeToDelete;

            before = ListNode.Build(1, 2, 3, 4, 5);
            after  = ListNode.Build(1, 2, 4, 5);

            nodeToDelete = before;
            while (nodeToDelete.val != 3)
                nodeToDelete = nodeToDelete.next;

            s.DeleteNode(nodeToDelete);
            Assert.Equal(before, after);
        }
    }
}