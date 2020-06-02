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
        [Fact(Skip = "Can't reproduce")]
        public void DeleteNodeTest()
        {
            // TODO: Figure out how to test this
        }
    }
}