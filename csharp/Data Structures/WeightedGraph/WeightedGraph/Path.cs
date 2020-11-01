using System;
using System.Collections.Generic;

namespace WeightedGraph
{
    public class Path
    {
        private List<String> nodes = new List<string>();
        public void Add(string node) => nodes.Add(node);
        public void Print()
        {
            var reverseList = new List<String>();
            for (int i = nodes.Count - 1; i >= 0; i--)
                reverseList.Add(nodes[i]);
            Console.WriteLine($"[{string.Join("->", reverseList)}]");
        }
    }
}
