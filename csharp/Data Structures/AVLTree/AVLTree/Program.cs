using System;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Self Rotating Binary Tree
            var avlTree = new CustomAVLTree();
            avlTree.Insert(10);
            avlTree.Insert(30);
            avlTree.Insert(20);
            
            Console.WriteLine();
        }
    }
}
