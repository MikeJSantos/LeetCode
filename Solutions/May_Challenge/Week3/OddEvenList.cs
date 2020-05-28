using System;
using System.Linq;
using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // TODO: Optimize? Beats 61.02% of submissions (https://leetcode.com/submissions/detail/341297655/)
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            
            ListNode currentNode  = head,
                     previousNode = null,
                     lastOddNode  = null;                        ;
            bool isCurrentNodeOdd = true;

            while (currentNode != null)
            {
                if (lastOddNode == null)
                    lastOddNode = currentNode;
                    
                if (isCurrentNodeOdd && lastOddNode != currentNode)
                {
                    var newNode = new ListNode(currentNode.val, lastOddNode.next);

                    lastOddNode.next  = newNode;
                    lastOddNode       = newNode;
                    previousNode.next = currentNode.next;
                }

                isCurrentNodeOdd = !isCurrentNodeOdd;
                previousNode     = currentNode;
                currentNode      = currentNode.next;
            }

            return head;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void OddEvenListTest()
        {
            var s = new Solution();
            ListNode input, expected;

            input    = ListNode.Build(1, 2, 3, 4, 5);
            expected = ListNode.Build(1, 3, 5, 2, 4);
            Assert.Equal(expected, s.OddEvenList(input));

            input    = ListNode.Build(2, 1, 3, 5, 6, 4, 7);
            expected = ListNode.Build(2, 3, 6, 7, 1, 5, 4);
            Assert.Equal(expected, s.OddEvenList(input));

            input    = ListNode.Build(1, 2, 3, 4);
            expected = ListNode.Build(1, 3, 2, 4);
            Assert.Equal(expected, s.OddEvenList(input));

            input    = ListNode.Build(1, 2, 3, 4, 5, 6);
            expected = ListNode.Build(1, 3, 5, 2, 4, 6);
            Assert.Equal(expected, s.OddEvenList(input));

            // Test Case 70/71
            var convertedArray = ReadTestDataFromFile("OddEvenList_input.txt")
                .Split(',')
                .Select(n => Convert.ToInt32(n))
                .ToArray();
            input = ListNode.Build(convertedArray);

            convertedArray = ReadTestDataFromFile("OddEvenList_output.txt")
                .Split(',')
                .Select(n => Convert.ToInt32(n))
                .ToArray();
            expected = ListNode.Build(convertedArray);
            Assert.Equal(expected, s.OddEvenList(input));
        }
    }
}