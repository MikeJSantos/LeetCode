using System.Linq;
using System.Collections.Generic;

namespace LeetCode
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

        public TreeNode(int x = 0, TreeNode leftNode = null, TreeNode rightNode = null)
        {
            val = x;
            left = leftNode;
            right = rightNode;
        }

        public TreeNode(int x = 0, int leftValue = 0, int rightValue = 0)
        {
            val = x;
            left = new TreeNode(leftValue);
            right = new TreeNode(rightValue);
        }

        public override string ToString()
        {
            return val.ToString();
        }

        public static TreeNode Build(int?[] array)
        {
            if (array == null || array.Length == 0 || !array[0].HasValue)
                return null;

            TreeNode root = null, parent = null, node;
            var nodesNeedingChildren = new Queue<TreeNode>();
            var nodesNeedingParents  = new Queue<TreeNode>();

            foreach (var element in array)
            {
                node = new TreeNode(element.HasValue ? element.Value : int.MinValue);
                nodesNeedingParents.Enqueue(node);

                if (element.HasValue)
                    nodesNeedingChildren.Enqueue(node);
            }

            root = nodesNeedingChildren.Dequeue();
            parent = root;
            nodesNeedingParents.Dequeue();

            while (nodesNeedingParents.Any())
            {
                node = nodesNeedingParents.Dequeue();
                if (node.val != int.MinValue)
                    parent.left = node;

                if (!nodesNeedingParents.Any())
                    break;

                node = nodesNeedingParents.Dequeue();
                if (node.val != int.MinValue)
                    parent.right = node;

                if (!nodesNeedingChildren.Any())
                    break;

                parent = nodesNeedingChildren.Dequeue();    
            }

            return root;
        }
    }
}