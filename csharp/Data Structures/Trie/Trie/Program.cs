using System;
using System.Runtime.InteropServices;

namespace Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new CustomTrieHashMap();
            trie.Insert("car");
            trie.Insert("care");
            trie.Insert("dog");
            Console.WriteLine($"trie contains the word cabbage {trie.Contains("cabbage")}");
            Console.WriteLine($"trie contains the word cat {trie.Contains("cat")}");
            Console.WriteLine($"trie contains the word ca {trie.Contains("ca")}");

            Console.WriteLine("Pre Order Traversal: ");
            trie.Traverse();
            Console.WriteLine("Post Order Traversal: ");
            trie.TraversePostOrder();

            trie.Remove("care");
            trie.Remove("book");

            Console.WriteLine("Check if removal works: ");
            Console.WriteLine(trie.Contains("care"));
            Console.WriteLine(trie.Contains("car"));

            trie.Insert("care");
            Console.WriteLine();

            Console.WriteLine("Autocomplete Functionality: ");
            trie.AutoComplete("c").ForEach(Console.WriteLine); ;
        }
    }
}
