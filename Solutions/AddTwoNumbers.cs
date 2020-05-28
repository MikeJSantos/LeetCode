using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode retVal = null,
                        tail = null,
                        newNode;
            int l1val,
                l2val,
                sum,
                remainder = 0;

            while (l1 != null || l2 != null)
            {
                l1val = (l1 != null) ? l1.val : 0;
                l2val = (l2 != null) ? l2.val : 0;
                sum = l1val + l2val + remainder;
                remainder = 0;

                if (sum > 9)
                {
                    remainder = sum / 10;
                    sum = sum % 10;
                }

                newNode = new ListNode(sum);
                if (tail != null)
                {
                    tail.next = newNode;
                    tail = newNode;
                }
                else
                {
                    retVal = newNode;
                    tail = newNode;
                }

                l1 = l1?.next;
                l2 = l2?.next;
            }

            while (remainder > 0)
            {
                newNode   = new ListNode(remainder % 10);
                tail.next = newNode;
                tail      = newNode;
                remainder = remainder / 10;
            }

            return retVal;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void AddTwoNumbersTest()
        {
            var s = new Solution();
            ListNode l1, l2, expected;

            l1       = ListNode.Build(2, 4, 3);
            l2       = ListNode.Build(5, 6, 4);
            expected = ListNode.Build(7, 0, 8);
            Assert.Equal(expected, s.AddTwoNumbers(l1, l2));

            l1       = ListNode.Build(0);
            l2       = ListNode.Build(0);
            expected = ListNode.Build(0);
            Assert.Equal(expected, s.AddTwoNumbers(l1, l2));

            l1       = ListNode.Build(0);
            l2       = ListNode.Build(1);
            expected = ListNode.Build(1);
            Assert.Equal(expected, s.AddTwoNumbers(l1, l2));

            l1       = ListNode.Build(5);
            l2       = ListNode.Build(5);
            expected = ListNode.Build(0, 1);
            Assert.Equal(expected, s.AddTwoNumbers(l1, l2));

            l1       = ListNode.Build(9);
            l2       = ListNode.Build(1, 9, 9, 9, 9, 9, 9, 9, 9, 9);
            expected = ListNode.Build(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            Assert.Equal(expected, s.AddTwoNumbers(l1, l2));

            l1       = ListNode.Build(1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            l2       = ListNode.Build(5, 6, 4);
            expected = ListNode.Build(6, 6, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            Assert.Equal(expected, s.AddTwoNumbers(l1, l2));
        }
    }
}