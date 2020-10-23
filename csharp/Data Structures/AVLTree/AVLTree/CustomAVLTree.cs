using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;

namespace AVLTree
{
    public class CustomAVLTree
    {
        private AVLNode root;
        private class AVLNode
        {
            public int val;
            public AVLNode left;
            public AVLNode right;
            public int height;
            public AVLNode(int value)
            {
                val = value;
            }
            public override string ToString() => $"val: {val}";

        }

        public void Insert(int val) => root = Insert(val, root);

        private AVLNode Insert(int val, AVLNode root)
        {
            var newNode = new AVLNode(val);
            if (root == null) return newNode;

            if (val > root.val)
                root.right = Insert(val, root.right);
            else if (val < root.val)
                root.left = Insert(val, root.left);
            else
                return null;

            SetHeight(root);

            return Balance(root);
        }

        private AVLNode Balance(AVLNode root)
        {
            if (IsLeftHeavy(root))
            {
                if (GetBalanceFactor(root.left) < 0)
                    root.left = RotateLeft(root.left);
                return RotateRight(root);
            }
            else if (IsRightHeavy(root))
            {
                if (GetBalanceFactor(root.right) > 0)
                    root.right = RotateRight(root.right);
                return RotateLeft(root);
            }
            return root;
        }

        private AVLNode RotateLeft(AVLNode root)
        {
            var newRoot = root.right;
            root.right = newRoot.left;
            root.height = GetHeight(root);

            newRoot.left = root;
            newRoot.height = GetHeight(newRoot); 

            return newRoot;
        }

        private AVLNode RotateRight(AVLNode root)
        {
            var newRoot = root.left;
            root.left = newRoot.right;
            SetHeight(root);

            newRoot.right = root;
            SetHeight(newRoot);

            return newRoot;
        }

        private void SetHeight(AVLNode node) => node.height = 1 + Math.Max(GetHeight(node.right), GetHeight(node.left));

        private bool IsLeftHeavy(AVLNode node) => GetBalanceFactor(node) > 1;

        private bool IsRightHeavy(AVLNode node) => GetBalanceFactor(node) < -1;

        private int GetBalanceFactor(AVLNode node) => (node == null) ? 0 : GetHeight(node.left) - GetHeight(node.right);

        private int GetHeight(AVLNode node) => (node == null) ? -1 : node.height;
    }
}
