using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Stack
{
    class CustomStack
    {
        private int[] items;
        private int last = -1; // -1 because items array is empty
        private int size;
        public CustomStack(int sizeOfArray)
        {
            items = new int[sizeOfArray];
            size = sizeOfArray;
        }

        public void Push(int item)
        {
            last++;

            if (last > size) throw new InvalidOperationException("Size of initialized array is too small");
            
            if (last == size)
            {
                size *=  2;
                var itemsNew = new int[size];
                items.CopyTo(itemsNew, 0);
                items = itemsNew;
            }
            items[last] = item;
        }

        public int Pop()
        {
            if (IsEmpty()) throw new System.InvalidOperationException("Empty stack cannot be popped");
            last--;
            return items[last + 1];
        }

        public int Peek()
        {
            if (IsEmpty()) throw new System.InvalidOperationException("Empty stack cannot be peeked");
            return items[last];
        }

        public bool IsEmpty()
        {
            return (last == -1) ? true : false;
        }

        public void Print()
        {
            for (int i = last; i >= 0; i--)
            {
                Console.WriteLine(items[i]);
            }
        }
    }
}
