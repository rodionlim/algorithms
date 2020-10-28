using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;

namespace Trie
{
    class CustomTrieHashMap
    {
        private Node root = new Node(' ');
        public class Node
        {
            public char value;
            public Dictionary<char, Node> children = new Dictionary<char, Node>();
            public bool isWord;
            public Node(char val) { value = val; }

            public override string ToString()
            {
                return "value=" + value.ToString();
            }

            // Abstraction such that any changes to Node will not affect Trie class. 
            // Instead we expose services for the Node object and not go directly into the children field
            public bool HasChild(char c) => !(GetChild(c) == null);

            public void AddChild(char c) => children.Add(c, new Node(c));

            public void RemoveChild(char c) => children.Remove(c);

            public Node GetChild(char c) => children.GetValueOrDefault(c, null);

            public Node[] GetChildren() => children.Values.ToArray();
            
            public bool HasChildren() => children.Values.ToArray().Length > 0;

        }
        public void Insert(string word)
        {
            var current = root;
            foreach (var c in word.ToLower())
                current = GetOrCreateNextNode(current, c);

            current.isWord = true;
        }

        public bool Contains(string word)
        {
            var current = root;
            foreach (var c in word)
            {
                if (current.HasChild(c))
                    current = current.GetChild(c);
                else
                    return false;
            }
            return current.isWord;
        }

        public void Remove(string word)
        {
            Remove(word, root);
        }

        private bool Remove(string word, Node node)
        {
            if (word == "")
            {
                if (node.isWord)
                    node.isWord = false;
                return true;
            }

            bool removeFlag = false;
            char nextChar = word[0];
            Node nextNode = null;

            if (node.HasChild(nextChar))
                if (word.Length > 0)
                {
                    nextNode = node.GetChild(nextChar);
                    removeFlag = Remove(word.Substring(1), node.GetChild(nextChar));
                }   

            if (removeFlag && !nextNode.HasChildren() && !nextNode.isWord)
            {
                node.RemoveChild(nextChar);
                return true;
            }
            return false;
        }

        public List<string> AutoComplete(string word)
        {
            Node startNode = root;
            var results = new List<string>();

            foreach (var c in word)
            {
                if (startNode.HasChild(c))
                    startNode = startNode.GetChild(c);
                else
                    return results;
            }
            return AutoComplete(word, startNode, results);
        }

        private List<string> AutoComplete(string word, Node node, List<string> results)
        {
            if (node.isWord) results.Add(word);

            if (node.HasChildren())
            {
                foreach (var child in node.GetChildren())
                    AutoComplete(word + child.value, child, results);
            }
            return results;
        }

        public void Traverse() => Traverse(root);

        public void TraversePostOrder() => TraversePostOrder(root);

        private void Traverse(Node node)
        {
            // Pre-order Traversal
            Console.WriteLine(node.value);

            foreach (var child in node.GetChildren())
                Traverse(child);
        }

        private void TraversePostOrder(Node node)
        {
            // Post-order Traversal
            foreach (var child in node.GetChildren())
                TraversePostOrder(child);
            
            Console.WriteLine(node.value);
        }

        private Node GetOrCreateNextNode(Node current, char c)
        {
            if (!current.HasChild(c))
                current.AddChild(c);
            return current.GetChild(c);
        }
    }
}
