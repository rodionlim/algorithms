using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WeightedGraph
{
    public class CustomWeightedGraph
    {
        readonly Dictionary<string, Node> itemsMap = new Dictionary<string, Node>();
        class Node
        {
            public string label;
            public List<Edge> edges = new List<Edge>();
            public Node(string label)
            {
                this.label = label;
            }
            public void AddEdge(Node to, int weight)
            {
                if (to == null) throw new System.InvalidOperationException("Invalid input nodes");
                edges.Add(new Edge(this, to, weight));
            }
            public List<Edge> GetEdges() => edges;

            public override string ToString()
            {
                return label;
            }
        }

        class NodeEntry
        {
            readonly Node node;
            public int priority;
            public NodeEntry(Node node, int priority)
            {
                this.node = node;
                this.priority = priority;
            }
            public NodeEntry(Node node)
            {
                this.node = node;
            }
            public Node GetNode()
            {
                return node;
            }
        }

        class Edge
        {
            public Node from;
            public Node to;
            public int weight;
            public Edge(Node from, Node to, int weight)
            {
                this.from = from;
                this.to = to;
                this.weight = weight;
            }

            public override string ToString() => from + "->" + to;
        }

        public void AddNode(string label)
        {
            if (itemsMap.ContainsKey(label)) return;

            var node = new Node(label);
            itemsMap.Add(label, node);
        }

        public void AddEdge(string from, string to, int weight)
        {
            var fromNode = GetNode(from);
            var toNode = GetNode(to);

            if (fromNode == null || toNode == null) throw new System.InvalidOperationException("Invalid input nodes");

            fromNode.AddEdge(toNode, weight);
            toNode.AddEdge(fromNode, weight);
        }

        class NodeComp : IComparer<NodeEntry>
        {
            public int Compare(NodeEntry a, NodeEntry b)
            {
                return a.priority < b.priority ? 0 : -1;
            }
        }

        public int GetShortestDistance(string from, string to)
        {
            // Dijkstra Algorithm
            var distances = new Dictionary<Node, int>();
            var previousNodes = new Dictionary<Node, Node>();
            var queue = new C5.IntervalHeap<NodeEntry>(new NodeComp()); // Priority Queue
            var visited = new HashSet<Node>();
            var fromNode = GetNode(from);
            var fromNodeEntry = new NodeEntry(fromNode, 0);
            var toNode = GetNode(to);

            foreach (var node in itemsMap.Values)
            {
                distances[node] = int.MaxValue;
                previousNodes[node] = null;
            }

            distances[fromNode] = 0;

            if (fromNode == null || toNode == null) throw new System.InvalidOperationException("Input nodes are invalid");

            queue.Add(fromNodeEntry);

            while (queue.Count > 0)
            {
                var currentNode = queue.DeleteMax().GetNode();
                visited.Add(currentNode);

                foreach (var edge in currentNode.GetEdges())
                {
                    if (visited.Contains(edge.to)) continue;
                    var oldDistance = distances[edge.to];
                    var currentDistance = distances[currentNode] + edge.weight;
                    if (currentDistance < oldDistance)
                    {
                        distances[edge.to] = currentDistance;
                        previousNodes[edge.to] = currentNode;
                        queue.Add(new NodeEntry(edge.to, currentDistance));
                    }
                }
            }

            return distances[toNode];
        }

        public Path GetShortestPath(string from, string to)
        {
            // Dijkstra's Algorithm
            var distances = new Dictionary<Node, int>();
            var previousNodes = new Dictionary<Node, Node>();
            var queue = new C5.IntervalHeap<NodeEntry>(new NodeComp()); // Priority Queue
            var visited = new HashSet<Node>();
            var fromNode = GetNode(from);
            var fromNodeEntry = new NodeEntry(fromNode, 0);
            var toNode = GetNode(to);

            foreach (var node in itemsMap.Values)
            {
                distances[node] = int.MaxValue;
                previousNodes[node] = null;
            }
            distances[fromNode] = 0;

            if (fromNode == null || toNode == null) throw new System.InvalidOperationException("Input nodes are invalid");

            queue.Add(fromNodeEntry);

            // Breadth first traversal + Visit the closest neighbour
            while (queue.Count > 0)
            {
                var currentNode = queue.DeleteMax().GetNode();
                visited.Add(currentNode);

                foreach (var edge in currentNode.GetEdges())
                {
                    if (visited.Contains(edge.to)) continue;
                    var oldDistance = distances[edge.to];
                    var currentDistance = distances[currentNode] + edge.weight;
                    if (currentDistance < oldDistance)
                    {
                        distances[edge.to] = currentDistance;
                        previousNodes[edge.to] = currentNode;
                        queue.Add(new NodeEntry(edge.to, currentDistance));
                    }
                }
            }
            return BuildPath(previousNodes, fromNode, toNode);
        }

        public bool HasCycle()
        {
            var visited = new HashSet<Node>();
            var results = false;

            foreach (var node in itemsMap.Values)
            {
                if (!visited.Contains(node) && HasCycle(node, null, visited)) 
                        return true;
            }
            return results;
        }

        public CustomWeightedGraph MinimumSpanTree()
        {
            // Prim's Algorithm
            var minSpanTree = new CustomWeightedGraph();
            var totalNodes = GetTotalNodes();
            var nodes = new HashSet<Node>();
            var edgesPriorityQueue = new C5.IntervalHeap<Edge>(new EdgeComp());

            if (itemsMap.Count == 0) return minSpanTree; // Error Handling

            var node = itemsMap.Values.First(); // Randomly pick the first node to add to Minimum Span Tree
            nodes.Add(node);
            minSpanTree.AddNode(node.label);
            edgesPriorityQueue.AddAll(node.GetEdges());

            while (nodes.Count < totalNodes)
            {
                var minEdge = edgesPriorityQueue.DeleteMax();

                if (minSpanTree.ContainNode(minEdge.to.label) && minSpanTree.ContainNode(minEdge.from.label)) continue;

                node = minEdge.to;
                nodes.Add(node);

                minSpanTree.AddNode(node.label);
                minSpanTree.AddEdge(minEdge.from.label, minEdge.to.label, minEdge.weight);
                edgesPriorityQueue.AddAll(node.GetEdges().Where(e => !minSpanTree.ContainNode(e.to.label)));
            }
            return minSpanTree;
        }

        class EdgeComp : IComparer<Edge>
        {
            public int Compare(Edge a, Edge b)
            {
                return a.weight < b.weight ? 0 : -1;
            }
        }

        public int GetTotalNodes() => itemsMap.Keys.Count;

        public bool ContainNode(string label) => itemsMap.ContainsKey(label);

        private bool HasCycle(Node current, Node parent, HashSet<Node> visited)
        {
            visited.Add(current);

            foreach (var edges in current.GetEdges())
                if (edges.to != parent)
                    if (visited.Contains(edges.to) || HasCycle(edges.to, current, visited)) return true;    
            return false;
        }

        public void Print()
        {
            foreach (var item in itemsMap)
            {
                if (item.Value.GetEdges().Count > 0)
                {
                    var edges = string.Join(", ", item.Value.GetEdges().Select(e => e.ToString()));
                    Console.WriteLine($"{item.Key} is connected to [{edges}]");
                }
            }
        }

        private static Path BuildPath(Dictionary<Node, Node> previousNodes, Node fromNode, Node toNode)
        {
            var path = new Path();
            path.Add(toNode.label);
            var currentPath = previousNodes[toNode];

            while (currentPath != fromNode)
            {
                path.Add(currentPath.label);
                currentPath = previousNodes[currentPath];
            }
            path.Add(fromNode.label);

            return path;
        }


        private Node GetNode(string label) => itemsMap.GetValueOrDefault(label);
    }
}
