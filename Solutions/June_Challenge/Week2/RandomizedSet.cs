using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    // TODO: Optimize. Beats 55.11% of submissions (16 ms slower than median)
    // https://leetcode.com/submissions/detail/352689711
    public class RandomizedSet
    {
        private Random _random;
        private List<int> _list;
        private HashSet<int> _hashSet;

        public RandomizedSet()
        {
            _random  = new Random();
            _list    = new List<int>();
            _hashSet = new HashSet<int>();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (_hashSet.Contains(val))
                return false;

            _hashSet.Add(val);
            _list.Add(val);
            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!_hashSet.Contains(val))
                return false;

            _hashSet.Remove(val);
            _list.Remove(val);
            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            var index = _random.Next() % _list.Count;
            return _list[index];
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void RandomizedSetTest()
        {
            var rs = new RandomizedSet();

            Assert.True(rs.Insert(1));
            Assert.False(rs.Remove(2));
            Assert.True(rs.Insert(2));
            Assert.True(new List<int> { 1, 2 }.Any(i => i == rs.GetRandom()));
            Assert.True(rs.Remove(1));
            Assert.False(rs.Insert(2));
            Assert.True(new List<int> { 2 }.Any(i => i == rs.GetRandom()));

            // Failed test case 18/18 https://leetcode.com/submissions/detail/352679922
        }
    }
}