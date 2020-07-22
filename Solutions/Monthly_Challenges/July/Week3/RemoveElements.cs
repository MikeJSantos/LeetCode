using System;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize? Beats 59.39% of submissions (12ms/12% slower than mode)
        // https://leetcode.com/submissions/detail/370178982
        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode node = head, previousNode = null;

            while (node != null)
            {
                if (node.val == val)
                {
                    if (previousNode != null)
                        previousNode.next = node.next;
                    else
                        head = head.next;
                }
                else
                    previousNode = node;

                node = node.next;
            }

            return head;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void RemoveElementsTest()
        {
            var s = new Solution();
            ListNode head, expected;
            int val;

            head = ListNode.Build(1, 2, 6, 3, 4, 5, 6);
            val = 6;
            expected = ListNode.Build(1, 2, 3, 4, 5);
            Assert.Equal(expected, s.RemoveElements(head, val));
        }
    }
}