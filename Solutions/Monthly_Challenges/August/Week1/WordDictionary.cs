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

            public Dictionary<string, TrieNode> Children
            {
                get { return _children; }
            }

            public TrieNode()
            {
                _key = string.Empty;
                _count = 0;
                _children = new Dictionary<string, TrieNode>();
            }

            public TrieNode(string key)
            {
                _key = key;
                _count = 1;
                _children = new Dictionary<string, TrieNode>();
            }

            public TrieNode Add(string newKey)
            {
                // Verify that child is key + char, bypassed for first character (root node)
                if (_key != string.Empty && _key != newKey.Substring(0, newKey.Length - 1))
                    return null;

                if (_children.ContainsKey(newKey))
                    _children[newKey]._count++;
                else
                    _children[newKey] = new TrieNode(newKey);

                return _children[newKey];
            }

            public bool Search(string word, int index, Dictionary<string, TrieNode> potentialMatches)
            {
                if (potentialMatches == null || potentialMatches.Keys.Count == 0)
                    return false;

                var newDictionary = new Dictionary<string, TrieNode>();

                if (index == word.Length - 1 && (word[index] == '.' || potentialMatches.Keys.Any(key => key[index] == word[index])))
                    return true;
                
                foreach (var keyValuePair in potentialMatches)
                {
                    if (word[index] == '.' || word[index] == keyValuePair.Key[index])
                        newDictionary = newDictionary
                            .Concat(keyValuePair.Value.Children)
                            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                }
                potentialMatches = newDictionary;

                return Search(word, index + 1, potentialMatches);
            }

            public override string ToString()
            {
                return _children.Count != 0
                    ? $"{_key}: [{string.Join(',', _children.Keys)}]"
                    : _key;
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

            // TODO: https://leetcode.com/submissions/detail/378922632
        }
    }
}