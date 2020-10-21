using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var btree = new CustomBinaryTree();
            Console.WriteLine(btree.Find(10));
            btree.Insert(7);
            btree.Insert(4);
            btree.Insert(9);
            btree.Insert(1);
            btree.Insert(6);
            btree.Insert(8);
            btree.Insert(10);

            var btree2 = new CustomBinaryTree();
            btree2.Insert(7);
            btree2.Insert(4);
            btree2.Insert(9);
            btree2.Insert(1);
            btree2.Insert(6);
            btree2.Insert(8);
            btree2.Insert(10);

            Console.WriteLine(btree.Find(10));

            btree.TraversePreOrder();
            Console.WriteLine();

            btree.TraverseInOrder();
            Console.WriteLine();

            btree.TraversePostOrder();
            Console.WriteLine();

            Console.WriteLine($"Height: {btree.Height()}");
            Console.WriteLine($"Min: {btree.Min()}");
            Console.WriteLine($"Compare if 2 trees are equivalent: {CustomBinaryTree.Equals(btree, btree2)}");

            Console.WriteLine($"Is binary search tree?: {btree.IsBinarySearchTree()}");
            Console.WriteLine();

            int k = 0;
            Console.WriteLine($"Printing K Distance Nodes where k={k}");
            btree.PrintKDistanceNodes(k);
        }
    }
}
