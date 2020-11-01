using System;

namespace WeightedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new CustomWeightedGraph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");

            graph.AddEdge("A", "B", 3);
            graph.AddEdge("B", "C", 2);
            graph.AddEdge("B", "D", 4);
            graph.AddEdge("A", "C", 1);
            graph.AddEdge("C", "D", 5);
            graph.Print();

            var from = "A";
            var to = "D";
            Console.WriteLine($"Shortest Distance {from}->{to} : {graph.GetShortestDistance(from, to)}");
            Console.WriteLine($"Shortest Path {from}->{to}");
            graph.GetShortestPath(from, to).Print();

            Console.WriteLine($"Graph has cycle? : {graph.HasCycle()}");

            Console.WriteLine("Creating Minimum Span Tree using Prim's Algorithm");
            var minimumSpanTree = graph.MinimumSpanTree();
            minimumSpanTree.Print();
        }
    }
}
