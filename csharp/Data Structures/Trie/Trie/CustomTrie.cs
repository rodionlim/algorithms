using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Trie
{
    class CustomTrie
    {
        private Node root = new Node(' ');
        public static int ALPHABET_SIZE = 26;
        class Node
        {
            public char value;
            // The problem with using an array to store the children of a node is that everytime we create a node object,
            // we are allocating an array with 26 elements. This is going to waste a lot of memory. A hash table would 
            // solve this problem instead.
            public Node[] children = new Node[ALPHABET_SIZE];
            public bool isWord;
            public Node(char val) { value = val; }

            public override string ToString()
            {
                return "value=" + value.ToString();
            }
        }
        public void Insert(string word)
        {
            var current = root;
            foreach (var c in word.ToLower())
                current = GetOrCreateNextNode(current, c);
            
            current.isWord = true;
        }

        private Node GetOrCreateNextNode(Node current, char c)
        {
            var nextIndex = c - 'a';
            if (current.children[nextIndex] == null)
                current.children[nextIndex] = new Node(c);
            return current.children[nextIndex];
        }
    }
}
