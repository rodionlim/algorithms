using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace Graph
{
    class CustomGraph
    {
        private Dictionary<string, Node> itemsMap = new Dictionary<string, Node>();
        private Dictionary<Node, List<Node>> adjacencyList = new Dictionary<Node, List<Node>>();

        class Node
        {
            public string label;
            public Node(string value)
            {
                label = value;
            }
            public override string ToString()
            {
                return label;
            }
        }

        public void AddNode(string label)
        {
            if (itemsMap.ContainsKey(label)) { return; }
            var node = new Node(label);
            itemsMap.Add(label, node);
            adjacencyList.Add(node, new List<Node>());
        }

        public void RemoveNode(string label)
        { 
            if (!itemsMap.ContainsKey(label)) { return; }
            var node = itemsMap[label];
            itemsMap.Remove(label);
            adjacencyList[node] = new List<Node>();
            
            foreach (var item in adjacencyList)
                item.Value.Remove(node);
        }

        public void AddEdge(string from, string to)
        {
            var fromNode = itemsMap.GetValueOrDefault(from);
            var toNode = itemsMap.GetValueOrDefault(to);
            ValidateFromAndToParams(fromNode, toNode);

            CheckAndAddEdgeIfNotPresent(fromNode, toNode);
        }
        
        public void RemoveEdge(string from, string to)
        {
            var fromNode = itemsMap.GetValueOrDefault(from);
            var toNode = itemsMap.GetValueOrDefault(to);
            ValidateFromAndToParams(fromNode, toNode);

            CheckAndRemoveEdgeIfPresent(fromNode, toNode);
        }

        public void Print()
        {   
            foreach (var item in adjacencyList)
            {
                if (item.Value.Count > 0)
                {
                    var edges = string.Join(", ", item.Value.Select(e => e.label).ToArray());
                    Console.WriteLine($"{item.Key} is connected to [{edges}]");
                }
            }
        }

        public void DepthFirstTraversalRecursive(string label)
        {
            if (!itemsMap.ContainsKey(label)) { return; }
            var node = itemsMap[label];

            DepthFirstTraversal(node, new HashSet<Node>());
        }

        public void DepthFirstTraversalIterative(string label)
        {
            if (!itemsMap.ContainsKey(label)) { return; }

            var node = itemsMap[label];
            var visited = new HashSet<Node>();
            var stack = new Stack<Node>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (visited.Contains(current))
                    continue;
                
                Console.WriteLine(current);
                visited.Add(current);

                foreach (var neighbour in adjacencyList[current])
                { 
                    if (!visited.Contains(neighbour))
                        stack.Push(neighbour);
                }
            }
        }

        public void BreadthFirstTraversal(string label)
        {
            if (!itemsMap.ContainsKey(label)) { return; }

            var node = itemsMap[label];
            var visited = new HashSet<Node>();
            var queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (visited.Contains(current))
                    continue;

                Console.WriteLine(current);
                visited.Add(current);

                foreach (var neighbour in adjacencyList[current])
                {
                    if (!visited.Contains(neighbour))
                        queue.Enqueue(neighbour);
                }
            }
        }

        public List<string> TopologicalSort()
        {
            var visited = new HashSet<Node>();
            var stack = new Stack<Node>();
            var results = new List<string>();

            foreach (var node in itemsMap.Values)
                TopologicalSort(node, stack, visited);

            while (stack.Count > 0)
                results.Add(stack.Pop().label);
            return results;
        }

        public bool HasCycle(string label)
        {
            var visiting = new HashSet<Node>();
            var visited = new HashSet<Node>();
            var parents = new Dictionary<Node, Node>();

            foreach (var node in itemsMap.Values)
            {
                bool results = HasCycle(node, null, visiting, visited, parents);
                if (results)
                {
                    return true;
                } 
            }

            return false;
        }

        private bool HasCycle(Node node, Node parent, HashSet<Node> visiting, HashSet<Node> visited, Dictionary<Node, Node> parents)
        {
            if (visiting.Contains(node)) return true;
            if (visited.Contains(node)) return false;
            visiting.Add(node);
            parents.Add(node, parent);

            foreach (var neighbour in adjacencyList[node])
            {
                if (HasCycle(neighbour, node, visiting, visited, parents)) return true;
            }

            visited.Add(node);
            visiting.Remove(node);
            return false;
        }

        private void TopologicalSort(Node node, Stack<Node> stack, HashSet<Node> visited)
        {
            if (visited.Contains(node)) return;
            visited.Add(node);

            foreach (var neighbour in adjacencyList[node])
                TopologicalSort(neighbour, stack, visited);

            stack.Push(node);
        }

        private void DepthFirstTraversal(Node node, HashSet<Node> visited)
        {
            Console.WriteLine(node);

            var edges = adjacencyList[node];
            foreach (var neighbour in edges)
            {
                if (!visited.Contains(neighbour))
                {
                    visited.Add(neighbour);
                    DepthFirstTraversal(neighbour, visited);
                }
            }
        }

        private static void ValidateFromAndToParams(Node from, Node to)
        {
            if (from == null || to == null)
                throw new System.InvalidOperationException("Please ensure that nodes are valid");
        }

        private void CheckAndAddEdgeIfNotPresent(Node fromNode, Node toNode)
        {
            foreach (var node in adjacencyList[fromNode])
                if (node == toNode) return;
            adjacencyList[fromNode].Add(toNode);
        }

        private void CheckAndRemoveEdgeIfPresent(Node fromNode, Node toNode)
        {
            foreach (var node in adjacencyList[fromNode])
                if (node == toNode) 
                {
                    adjacencyList[fromNode].Remove(toNode);
                    return; 
                }
        }
    }
}
