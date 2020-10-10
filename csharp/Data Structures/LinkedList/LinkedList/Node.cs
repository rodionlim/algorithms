using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    class Node
    {
        public int? value { get; set; }
        public Node? next { get; set; }
        public Node(int val)
        {
            value = val; 
        }
        public Node(int val, Node nextNode)
        {
            value = val;
            next = nextNode;
        }

    }
}
