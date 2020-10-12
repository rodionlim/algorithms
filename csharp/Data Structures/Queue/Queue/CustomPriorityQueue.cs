using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Queue
{
    class CustomPriorityQueue
    {
        // Priority Queues can be implemented with either an array or a heap
        // Here, we implement Priority Queue with a circular array where lower numbers have priority
        int[] items;
        int length;
        int head;
        int sizeOfArray;

        public CustomPriorityQueue(int size)
        {
            items = new int[size];
            length = head =  0;
            sizeOfArray = size;
        }

        public void Enqueue(int item)
        {
            // [1, 3, 5, 7] insert 2
            if (IsFull()) throw new System.InvalidOperationException("Queue is full");

            if (IsEmpty())
            {
                items[head] = item;
                length++;
                return;
            }

            if (ShiftItemsAndCheckIfInsertRequired(item))
            { 
                items[head] = item;
                length++;
            }
        }

        private bool ShiftItemsAndCheckIfInsertRequired(int item)
        { 
            int currentIdx, forwardIdx;

            for (int i = length - 1; i >= 0; i--)
            {
                currentIdx = (head + i) % sizeOfArray;
                forwardIdx = (head + i + 1) % sizeOfArray;

                if (item > items[currentIdx])
                {
                    items[forwardIdx] = item;
                    length++;
                    return false;
                }
                else
                    items[forwardIdx] = items[currentIdx];
            }
            return true;
        }

        public int Dequeue()
        {
            if (IsEmpty()) throw new System.InvalidOperationException("Queue is empty. Dequeue is not allowed");
            int item = items[head];
            head = (head + 1) % sizeOfArray;
            length--;
            return item;
        }
        
        public bool IsFull()
        {
            return sizeOfArray == length;
        }

        public bool IsEmpty()
        {
            return length == 0;
        }

        public void Print()
        {
            int currentIdx;
            for (int i = 0; i < length; i++)
            {
                currentIdx = (head + i) % sizeOfArray;
                Console.WriteLine(items[currentIdx]);
            }
        }
    }
}
