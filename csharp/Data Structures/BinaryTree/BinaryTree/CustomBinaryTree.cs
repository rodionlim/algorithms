using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class CustomBinaryTree
    {
        public Node root;
        public class Node
        {
            public int? val;
            public Node left;
            public Node right;

            public Node(int value)
            {
                val = value;
            }
            public Node() {}

            public override string ToString()
            {
                return $"Node={val}";
            }
        }

        public CustomBinaryTree() { }

        public CustomBinaryTree(int val)
        {
            root = new Node(val);
        }

        public bool Find(int val)
        {
            var lastNode = GetLastPosition(val);
            return (lastNode !=null) && (lastNode.val == val);
        }

        public void Insert(int val)
        {
            var lastNode = GetLastPosition(val);
            var newNode = new Node(val);

            if (lastNode == null) { root = newNode; return; }

            if (lastNode.val == val)
                return;
            else
            {
                if (val > lastNode.val)
                    lastNode.right = newNode;
                else
                    lastNode.left = newNode;
            }
        }

        private Node GetLastPosition(int val)
        {
            Node current = root;
            Node previous = root;

            while (current != null)
            {
                if (val == current.val)

                    return current;
                else if (val > current.val)
                {
                    previous = current;
                    current = current.right;
                }
                else if (val < current.val)
                {
                    previous = current;
                    current = current.left;
                }
            }
            return previous;
        }

        public void TraversePreOrder() => TraversePreOrder(root);

        public void TraverseInOrder() => TraverseInOrder(root);

        public void TraversePostOrder() => TraversePostOrder(root);

        public int Height() => Height(root);

        public int? Min() => Min(root);

        public static bool Equals(CustomBinaryTree tree1, CustomBinaryTree tree2)
        {
            return Equals(tree1.root, tree2.root);
        }

        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(root, int.MinValue, int.MaxValue);
        }

        public void PrintKDistanceNodes(int distance)
        {
            PrintKDistanceNodes(root, distance);
        }

        private void PrintKDistanceNodes(Node current, int distance)
        {
            if (current == null) return;
            if (distance == 0)
            {
                Console.WriteLine(current.val);
                return;
            }
            PrintKDistanceNodes(current.left, distance - 1); 
            PrintKDistanceNodes(current.right, distance - 1);
        }

        private static bool Equals(Node node1, Node node2)
        {
            if (IsLeaf(node1) && IsLeaf(node2)) return node1.val == node2.val;
            if ((!IsLeaf(node1) && IsLeaf(node2)) || (IsLeaf(node1) && !IsLeaf(node2))) return false;

            var left = Equals(node1.left, node2.left);
            var right = Equals(node1.right, node2.right);
            return left && right;
        }

        private void TraversePreOrder(Node node)
        {
            if (node == null) return;
            Console.WriteLine(node.val);
            TraversePreOrder(node.left);
            TraversePreOrder(node.right);
        }

        private void TraverseInOrder(Node node)
        {
            if (node == null) return;
            TraverseInOrder(node.left);
            Console.WriteLine(node.val);
            TraverseInOrder(node.right);
        }

        private void TraversePostOrder(Node node)
        {
            if (node == null) return;
            TraversePostOrder(node.left);
            TraversePostOrder(node.right);
            Console.WriteLine(node.val);
        }

        private int Height(Node node)
        {
            if (node == null) return -1;
            if (IsLeaf(node)) return 0;
            return 1 + Math.Max(Height(node.left), Height(node.right));
        }

        private int Min(Node node)
        {
            if (node == null) return 0;
            if (IsLeaf(node)) return (int)node.val;
            var left = Min(node.left);
            var right = Min(node.right);
            return Math.Min(Math.Min(left, right), (int)node.val);
        }

        private static bool IsLeaf(Node node)
        {
            return node.left == null && node.right == null;
        }

        private bool IsBinarySearchTree(Node node, int? lLimit, int? uLimit)
        {
            if (node == null) return true;

            var withinRange = node.val > lLimit || node.val < uLimit;
            if (!withinRange) return false;

            var left = IsBinarySearchTree(node.left, lLimit, node.val);
            var right = IsBinarySearchTree(node.right, node.val, uLimit);

            return left && right;
        }

    }
}
