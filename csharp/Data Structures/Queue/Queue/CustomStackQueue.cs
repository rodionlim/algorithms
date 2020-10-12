using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Queue
{
    class CustomStackQueue
    {
        // Stack Queue
        readonly Stack<int> enqueueStack;
        readonly Stack<int> dequeueStack;
        public CustomStackQueue()
        {
            enqueueStack = new Stack<int>();
            dequeueStack = new Stack<int>();
        }

        public void Enqueue(int item)
        {
            // [5, 10, 15, 20]
            enqueueStack.Push(item);
        }

        public int Dequeue()
        {
            if (IsEmpty()) throw new System.InvalidOperationException("Queue is empty");
            AddToDequeueStack();

            return dequeueStack.Pop();
        }

        public int Peek()
        {
            if (IsEmpty()) throw new System.InvalidOperationException("Queue is empty");
            AddToDequeueStack();

            return dequeueStack.Peek();
        }

        private void AddToDequeueStack()
        {
            if (dequeueStack.Count == 0)
                while (enqueueStack.Count > 0)
                    dequeueStack.Push(enqueueStack.Pop());
        }

        private bool IsEmpty()
        {
            return enqueueStack.Count + dequeueStack.Count == 0;
        }
    }
}
