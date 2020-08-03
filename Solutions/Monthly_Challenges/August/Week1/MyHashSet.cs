using Xunit;

namespace LeetCode
{
    // Beats 98.09% of submissions
    // https://leetcode.com/submissions/detail/375445340/
    public class MyHashSet
    {
        private bool[] _hashSet;

        public MyHashSet()
        {
            _hashSet = new bool[1000000];
        }

        public void Add(int key)
        {
            _hashSet[key] = true;
        }

        public void Remove(int key)
        {
            _hashSet[key] = false;
        }

        public bool Contains(int key)
        {
            return _hashSet[key];
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void MyHashSetTest()
        {
            var hs = new MyHashSet();
            hs.Add(1);
            hs.Add(2);
            Assert.True(hs.Contains(1));
            Assert.False(hs.Contains(3));
            hs.Add(2);
            Assert.True(hs.Contains(2));
            hs.Remove(2);
            Assert.False(hs.Contains(2));
        }
    }
}