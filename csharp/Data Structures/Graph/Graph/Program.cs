using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new CustomGraph();
            graph.AddNode("Mary");
            graph.AddNode("Mary");
            graph.AddNode("Tom");
            graph.AddNode("Rose");
            graph.AddNode("Harry");

            graph.RemoveNode("Mary");
            
            
            graph.AddEdge("Rose", "Tom");
            graph.AddEdge("Rose", "Harry");
            graph.RemoveEdge("Tom", "Rose");
            graph.AddEdge("Harry", "Rose");

            graph.Print();
            Console.WriteLine();

            var graph2 = new CustomGraph();
            graph2.AddNode("A");
            graph2.AddNode("B");
            graph2.AddNode("C");
            graph2.AddNode("D");

            graph2.AddEdge("A", "B");
            graph2.AddEdge("A", "C");
            graph2.AddEdge("B", "D");
            graph2.AddEdge("D", "C");

            Console.WriteLine("Recursive Depth First Traversal: ");
            graph2.DepthFirstTraversalRecursive("A");
            Console.WriteLine("Iterative Depth First Traversal: ");
            graph2.DepthFirstTraversalIterative("A");
            Console.WriteLine("Iterative Breadth First Traversal: ");
            graph2.BreadthFirstTraversal("A");


            var graph3 = new CustomGraph();
            graph3.AddNode("X");
            graph3.AddNode("A");
            graph3.AddNode("B");
            graph3.AddNode("P");

            graph3.AddEdge("X", "A");
            graph3.AddEdge("X", "B");
            graph3.AddEdge("A", "P");
            graph3.AddEdge("B", "P");
            graph3.AddEdge("P", "X");
            var dependencies = graph3.TopologicalSort();
            Console.WriteLine($"Topological Sort: [{string.Join(", ", dependencies)}]");

            Console.WriteLine($"{ graph3.HasCycle("X") }");
            Console.WriteLine();
        }
    }
}
