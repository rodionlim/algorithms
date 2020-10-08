using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace LinkedList
{
    class LinkedList
    {
        private Node first;
        private Node last;
        private int size;

        public void AddFirst(int val)
        {
            var node = new Node(val);
            if (IsEmpty())
            {
                first = last = node;
            }
            else 
            { 
                node.next = first;
                first = node;
            }
            size++;
        }

        public void AddLast(int val)
        {
            var node = new Node(val);
            if (IsEmpty())
            {
                first = last = node;
            }
            else 
            { 
                last.next = node;
                last = node;
            }
            size++;
        }

        public void DeleteFirst()
        {
            if (IsEmpty()) throw new System.InvalidOperationException("Linked list is empty");

            if (first == last)
            {
                first = last = null;
            }
            else
            {
                var second = first.next;
                first.next = null;
                first = second;
            }
            size--;
        }

        public void DeleteLast()
        {
            if (IsEmpty()) throw new System.InvalidOperationException("Linked list is empty");

            if (first == last)
            { 
                first = last = null;
            }
            else
            { 
                var secondLastNode = GetPrevious(last);
                secondLastNode.next = null;
                last = secondLastNode;
            }
            size--;
        }


        public int IndexOf(int val)
        {
            var currentNode = first;
            int currentIndex = 0;
            do
            {
                if (currentNode.value == val) return currentIndex;
                currentNode = currentNode.next;
                currentIndex++;
            } while (currentNode != null);

            return -1;
        }

        public bool Contains(int val)
        {
            return IndexOf(val) != -1;
        }

        public int[] ToArray()
        {
            var array = new int[size];
            int i = 0;
            var currentNode = first;

            while (currentNode != null)
            {
                array[i++] = (int)currentNode.value;
                currentNode = currentNode.next;
            }

            return array;
        }

        public void Reverse()
        {
            if (IsEmpty() || (first == last)) return;
            
            var current = first;
            Node before = null;
            Node next = current.next;
            Node following;

            while (true)
            {
                following = next.next;
                current.next = before;
                next.next = current;

                before = current;
                current = next;
                next = following;

                if (following == null)
                {
                    last = first;
                    first = current;
                    break;
                }
            }
        }

        public void Print()
        {
            var currentNode = first;

            if (IsEmpty()) return;

            if (first.value != null)
            {
                while (true)
                {
                    Console.WriteLine(currentNode.value);
                    if (currentNode.next == null) break;
                    currentNode = currentNode.next;
                }
            }
        }

        private bool IsEmpty()
        {
            return first == null;
        }

        private Node GetPrevious(Node node)
        {
            var currentNode = first;

            if (IsEmpty()) return null;

            while (currentNode.next != node)
            {
                currentNode = currentNode.next;
            }
            return currentNode;
        }

        public int Size()
        {
            return size;
        }
    }
}
