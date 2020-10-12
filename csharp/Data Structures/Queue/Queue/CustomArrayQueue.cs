using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    class CustomArrayQueue
    {
        // Array Queue
        private int[] items;
        private int rear;
        private int head;
        private int length;
        private int sizeOfArray;

        public CustomArrayQueue(int size)
        {
            items = new int[size];
            rear = head = -1;
            length = 0;
            sizeOfArray = size;
        }

        public void Enqueue(int item)
        {
            // 5     10     15     0      0   
            // Head         Rear       
            if (IsFull()) throw new System.InvalidOperationException("Queue is already full");
            if (IsEmpty()) head++;
            
            length++;
            rear = (rear + 1) % sizeOfArray; // Built in circularity
            items[rear] = item;
        }

        public int Dequeue()
        {
            if (IsEmpty()) throw new System.InvalidOperationException("Queue is empty. Nothing to dequeue");
            
            length--;
            int item = items[head];
            head = (head + 1) % sizeOfArray;
            return item;
        }

        public bool IsEmpty()
        {
            return length == 0;
        }

        public bool IsFull()
        {
            return sizeOfArray == length;
        }

        public void Print()
        {
            if (IsEmpty()) return;
            for (int i = 0; i < length; i++)
                Console.WriteLine(items[(i + head) % sizeOfArray]);
        }
    }
}
