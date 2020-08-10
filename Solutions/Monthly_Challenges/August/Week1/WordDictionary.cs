using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public class WordDictionary
    {
        TrieNode _root;

        public WordDictionary()
        {
            _root = new TrieNode();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            if (word == string.Empty)
                return;

            var node = _root;
            for (var i = 1; i <= word.Length; i++)
            {
                var key = word.Substring(0, i);
                node = node.Add(key);
            }
            node.AddCount();
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            if (word.Trim() == string.Empty)
                return false;

            return _root.Search(word, 0, _root.Children);
        }

        class TrieNode
        {
            private string _key;
            private int _count;
            private Dictionary<string, TrieNode> _children;

            public int Count => _count;
            public Dictionary<string, TrieNode> Children => _children;

            public TrieNode()
            {
                _key = string.Empty;
                _count = 0;
                _children = new Dictionary<string, TrieNode>();
            }

            public TrieNode(string key) : this()
            {
                _key = key;
            }

            public TrieNode Add(string key)
            {
                // Verify that child is key + char, bypassed for first character (root node)
                if (_key != string.Empty && _key != key.Substring(0, key.Length - 1))
                    return null;

                TrieNode node;
                if (_children.ContainsKey(key))
                    node = _children[key];
                else
                {
                    node = new TrieNode(key);
                    _children[key] = node;
                }

                return node;
            }

            public bool Search(string word, int index, Dictionary<string, TrieNode> potentialMatches)
            {
                if (potentialMatches == null || potentialMatches.Keys.Count == 0)
                    return false;

                var character = word[index];

                if (index == word.Length - 1)
                {
                    if (!potentialMatches.Any(kvp => kvp.Key.Length == word.Length))
                        return false;

                    var lastCharMatchFound = potentialMatches.Any(kvp =>
                        kvp.Value.Count > 0 && DoCharsMatch(character, kvp.Key[index])
                    );
                    return lastCharMatchFound;
                }
                    
                var newDictionary = new Dictionary<string, TrieNode>();
                foreach (var kvp in potentialMatches)
                    if (DoCharsMatch(character, kvp.Key[index]))
                        newDictionary = newDictionary
                            .Concat(kvp.Value.Children)
                            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                potentialMatches = newDictionary;

                return Search(word, index + 1, potentialMatches);
            }

            private bool DoCharsMatch(char c, char target) => c == target || c == '.';
            
            public void AddCount()
            {
                _count += 1;
            }

            public override string ToString()
            {
                var str = $"'{_key}' ({_count})";
                if (_children.Count != 0)
                    str += ": [{string.Join(',', _children.Keys)}]";
                return str;
            }
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void WordDictionaryTest()
        {
            var wd = new WordDictionary();
            wd.AddWord("bad");
            wd.AddWord("dad");
            wd.AddWord("mad");
            Assert.False(wd.Search("pad"));
            Assert.True(wd.Search("bad"));
            Assert.True(wd.Search(".ad"));
            Assert.True(wd.Search("b.."));

            // https://leetcode.com/submissions/detail/378922632
            wd = new WordDictionary();
            wd.AddWord("at");
            wd.AddWord("and");
            wd.AddWord("an");
            wd.AddWord("add");
            Assert.False(wd.Search("a"));
            Assert.False(wd.Search(".at"));
            wd.AddWord("bat");
            Assert.True(wd.Search(".at"));
            Assert.True(wd.Search("an."));
            Assert.False(wd.Search("a.d."));
            Assert.False(wd.Search("b."));
            Assert.True(wd.Search("a.d"));
            Assert.False(wd.Search("."));

            // TLE: https://leetcode.com/submissions/detail/378986183
        }
    }
}