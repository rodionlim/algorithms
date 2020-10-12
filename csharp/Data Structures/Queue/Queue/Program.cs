using System;
using System.Collections.Generic;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            // C# Native Queue Implementation
            var queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(15);
            queue.Enqueue(20);
            Reverse(queue);

            foreach (var item in queue)
                Console.WriteLine(item);

            // Custom Queue - Circular Array
            Console.WriteLine("*** Custom Array Queue ***");
            var arrayQueue = new CustomArrayQueue(5);
            Console.WriteLine($"Queue is empty? {arrayQueue.IsEmpty()}");
            arrayQueue.Enqueue(5);
            arrayQueue.Enqueue(10);
            arrayQueue.Enqueue(15);
            arrayQueue.Dequeue();
            arrayQueue.Print();
            Console.WriteLine($"Queue is empty? {arrayQueue.IsEmpty()}");

            Console.WriteLine("*** Custom Stack Queue ***");
            var stackQueue = new CustomStackQueue();
            stackQueue.Enqueue(5);
            stackQueue.Enqueue(10);
            stackQueue.Enqueue(15);
            stackQueue.Dequeue();
            var first = stackQueue.Dequeue();
            Console.WriteLine(first);

            Console.WriteLine("*** Custom Priority Queue ***");
            var priorityQueue = new CustomPriorityQueue(4);
            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(15);
            priorityQueue.Enqueue(10);
            priorityQueue.Dequeue();
            priorityQueue.Enqueue(20);
            priorityQueue.Dequeue();
            priorityQueue.Enqueue(25);
            priorityQueue.Enqueue(30);

            priorityQueue.Print();
        }

        static void Reverse(Queue<int> queue)
        {
            var stack = new Stack<int>();

            while (queue.Count > 0)
                stack.Push(queue.Dequeue());

            while (stack.Count > 0)
                queue.Enqueue(stack.Pop());
        }
    }
}
