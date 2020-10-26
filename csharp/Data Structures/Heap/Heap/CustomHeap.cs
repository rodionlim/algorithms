using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Heap
{
    class CustomHeap
    {
        int[] items;
        public int next;

        public CustomHeap(int size) => items = new int[size];

        public void Insert(int item)
        {
            if (next == items.Length) throw new System.InvalidOperationException("Array is full");

            var currentIndex = next;
            items[next++] = item;
            
            while (!IsValidHeap(currentIndex))
                currentIndex = BubbleUp(currentIndex);
        }

        public int Delete()
        {
            if (IsEmpty()) throw new System.InvalidOperationException("Nothing in the heap to delete");
            var currentIndex = 0;
            var returnVal = items[0];
            items[0] = items[--next];
            items[next] = 0;

            while (!IsValidHeap(currentIndex))
                currentIndex = BubbleDown(currentIndex);

            return returnVal;
        }

        public bool IsEmpty() => next == 0;

        private int BubbleUp(int currentIndex)
        {
            var parentIndex = GetParent(currentIndex);
            var parent = items[parentIndex];
            var current = items[currentIndex];
            items[currentIndex] = parent;
            items[parentIndex] = current;
            return parentIndex;
        }

        private int BubbleDown(int currentIndex)
        {
            var leftChildIndex = GetLeftChild(currentIndex);
            var rightChildIndex = GetRightChild(currentIndex);

            if (!HasLeftChild(currentIndex)) throw new System.InvalidOperationException("No child to bubble down");

            var parent = items[currentIndex];
            var left = items[leftChildIndex];
            var right = items[rightChildIndex];

            if (!HasRightChild(currentIndex) || left >= right)
            {
                items[currentIndex] = left;
                items[leftChildIndex] = parent;
                return leftChildIndex;
            }
            else 
            {
                items[currentIndex] = right;
                items[rightChildIndex] = parent;
                return rightChildIndex;
            }
        }

        public static void Heapify(int[] items)
        {
            // { 5, 3, 8, 4, 1, 2 } becomes { 8, 3, 5, 4, 1, 2 }
            int size = items.Length;

            // We start from the last parent since leaf nodes have no children and does not need to be swapped for a valid heap
            // Also node that leaf nodes form half of the entire binary tree, so it optimizes half the operations

            // We optimize further by starting from the deepest parent nodes since as we go up in the tree, a lot of the nodes 
            // gets swapped to the right position and less comparisons need to be done.
            var lastParent = items.Length / 2 - 1;
            for (int j = lastParent; j>=0; j--)
            {
                int i = j;
                while (true)
                {
                    var current = items[i];
                    var leftIndex = i * 2 + 1;
                    var rightIndex = i * 2 + 2;

                    if (leftIndex >= size) break;
                    var left = items[leftIndex];

                    if (rightIndex >= size)
                    {
                        if (current < left)
                        {
                            items[i] = left;
                            items[leftIndex] = current;
                            i = leftIndex;
                            continue;
                        }
                        break;
                    }
                    var right = items[rightIndex];

                    var isValid = current >= left && current >= right;
                    if (isValid)
                        break;
                    else if (current < left)
                    {
                        items[i] = left;
                        items[leftIndex] = current;
                        i = leftIndex;
                    }
                    else
                    {
                        items[i] = right;
                        items[rightIndex] = current;
                        i = rightIndex;
                    }
                }
            }
            
        }

        public int KLargestValue(int K)
        {
            int res=0;
            for (int i = 0; i < K; i++)
            {
                res = Delete();
            }
            return res;
        }

        private int GetParent(int current) => (current == 0) ? 0 : (current - 1) / 2;

        private bool HasLeftChild(int current) => GetLeftChild(current) <= (next - 1);

        private bool HasRightChild(int current) => GetRightChild(current) <= (next - 1);

        private int GetLeftChild(int current) => current * 2 + 1;

        private int GetRightChild(int current) => current * 2 + 2;

        private bool IsValidHeap(int current)
        {
            return items[GetParent(current)] >= items[current] &&
                   (!HasLeftChild(current) || items[GetLeftChild(current)] <= items[current]) &&
                   (!HasRightChild(current) || items[GetRightChild(current)] <= items[current]);
        }
    }
}
