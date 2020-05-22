using System.Text;

namespace LeetCode
{
    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        
        public ListNode(int x, ListNode n = null) {
            val = x;
            next = n;
        }

        public static ListNode Build(params int[] intArray)
        {
            ListNode head = null; ;
            ListNode iterationNode = null;

            foreach (var num in intArray)
            {
                var newNode = new ListNode(num);

                if (head == null)
                {
                    head = newNode;
                    iterationNode = newNode;
                }
                else
                {
                    iterationNode.next = newNode;
                    iterationNode = newNode;
                }
            }

            return head;
        }

        public override string ToString()
        {
            var node = this;
            var strBuilder = new StringBuilder();

            while (node != null)
            {
                strBuilder.Append(node.val);

                if (node.next != null)
                    strBuilder.Append(" > ");

                node = node.next;
            }

            return strBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            var comparisonNode = obj as ListNode;
            
            if (comparisonNode == null)
                return false;

            var thisNode = this;

            while (thisNode != null)
            {
                if (comparisonNode == null || thisNode.val != comparisonNode.val)
                    return false;

                thisNode = thisNode.next;
                comparisonNode = comparisonNode.next;
            }

            return comparisonNode == null;
        }

        public override int GetHashCode()
        {
            return val * base.GetHashCode();
        }
    }
}