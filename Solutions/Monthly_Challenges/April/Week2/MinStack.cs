using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public class MinStack
    {
        public class ListNode
        {
            public int Value;
            public ListNode next;
            public ListNode(int x) { Value = x; }

            public override string ToString()
            {
                if (this == null) return string.Empty;

                var list = new List<int>();
                var node = this;

                while (node != null)
                {
                    list.Add(node.Value);
                    node = node.next;
                }

                return string.Join(" > ", list);
            }
        }

        private ListNode _head, _tail;
        private ListNode _minNode;

        public MinStack()
        {
            _head = null;
            _tail = null;
            _minNode = null;
        }

        public void Push(int x)
        {
            if (_head == null)
            {
                _head = new ListNode(x);
                _tail = _head;
                _minNode = _head;
            }
            else
            {
                var newNode = new ListNode(x);
                _tail.next = newNode;
                _tail = newNode;

                if (x < _minNode.Value)
                    _minNode = newNode;
            }
        }

        public void Pop()
        {
            if (_head.next == null)
            {
                _head = null;
                _tail = null;
                _minNode = null;
            }
            else
            {
                var node = _head;
                var previousNode = _head;
                _minNode = _head;

                while (node.next != null)
                {
                    previousNode = node;

                    if (node.Value < _minNode.Value)
                        _minNode = node;

                    node = node.next;
                }

                previousNode.next = null;
                _tail = previousNode;
            }
        }

        public int Top()
        {
            return _tail != null ? _tail.Value : 0;
        }

        public int GetMin()
        {
            return _minNode != null ? _minNode.Value : 0;
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void MinStackTest()
        {
            var minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            Assert.Equal(-3, minStack.GetMin());

            minStack.Pop();
            Assert.Equal(0, minStack.Top());
            Assert.Equal(-2, minStack.GetMin());
        }
    }
}