using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    // TODO: Optimize. Submission not ranked (https://leetcode.com/submissions/detail/339319929/)
    public class Trie
    {
        TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            string partialWord;
            var currentNode = root;

            for (var i = 0; i < word.Length; i++)
            {
                partialWord = word.Substring(0, i+1);

                if (currentNode.children.ContainsKey(partialWord))
                    currentNode = currentNode.children[partialWord];
                else
                {
                    var newNode = new TrieNode(partialWord);
                    currentNode.children[partialWord] = newNode;
                    currentNode = newNode;
                }
            }

            currentNode.count++;
        }

        public bool Search(string word)
        {
            return Find(word, true);
        }

        public bool StartsWith(string prefix)
        {
            return Find(prefix);
        }

        private bool Find(string word, bool isFullSearch = false)
        {
            if (root == null) return false;

            string partialWord;
            var currentNode = root;

            for (var i = 0; i < word.Length; i++)
            {
                partialWord = word.Substring(0, i+1);

                if (!currentNode.children.ContainsKey(partialWord))
                    return false;

                currentNode = currentNode.children[partialWord];
            }
            
            return isFullSearch
                ? currentNode.count > 0
                : true;
        }

        class TrieNode
        {
            public string val;
            public int count;
            public Dictionary<string, TrieNode> children;

            public TrieNode()
            {
                children = new Dictionary<string, TrieNode>();    
            }

            public TrieNode(string val) : this()
            {
                this.val = val;
            }

            public override string ToString()
            {
                return $"{val}: [{string.Join(',', children.Keys)}]";
            }
        }
    }

    public partial class UnitTests
    {
        [Fact]
        public void TrieTest()
        {
            var trie = new Trie();

            string word1 = "apple", word2 = "app";

            trie.Insert(word1);

            Assert.True(trie.Search(word1));
            Assert.False(trie.Search(word2));
            Assert.True(trie.StartsWith(word2));

            trie.Insert(word2);

            Assert.True(trie.Search(word2));
        }
    }
}