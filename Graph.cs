using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace LearnerAgent
{
    public class Graph
    {
        private List<Node> Nodes { get; set; }

        private Node _pleasureNode;
        private Node _painNode;
        private Node[] _pleasureInputs;
        private Node[] _painInputs;
        private Node[] _moveOutputs;

        public Graph()
        {
            Nodes = new List<Node>();
            Random random = new Random();
            
            // Create four pleasure input nodes, one per cardinal direction
            _pleasureInputs = new []
            {
                new Node(random.NextDouble()), 
                new Node(random.NextDouble()), 
                new Node(random.NextDouble()), 
                new Node(random.NextDouble())
            };
            
            // Create four pain input nodes, one per cardinal direction
            _painInputs = new []
            {
                new Node(random.NextDouble()), 
                new Node(random.NextDouble()), 
                new Node(random.NextDouble()), 
                new Node(random.NextDouble())
            }; 
            
            // Create four move output nodes, one per cardinal direction
            _moveOutputs = new []
            {
                new Node(random.NextDouble()), 
                new Node(random.NextDouble()), 
                new Node(random.NextDouble()), 
                new Node(random.NextDouble())
            }; 
            
            // Create a pleasure node and connect pleasure inputs with one degree of separation each
            _pleasureNode = new Node(random.NextDouble());
            Nodes.Add(_pleasureNode);
            foreach(Node input in _pleasureInputs)
            {
                Nodes.Add(input);
                Node intermediate = new Node(random.NextDouble());
                Nodes.Add(intermediate);
                // TODO: Should this be bidirectional?
                new Edge(input, intermediate);
                // Bidirectional connection
                new Edge(intermediate, _pleasureNode);
                new Edge(_pleasureNode, intermediate);
            }
            
            // Create a pain node and connect pain inputs with one degree of separation
            _painNode = new Node(random.NextDouble());
            Nodes.Add(_painNode);
            foreach(Node input in _painInputs)
            {
                Nodes.Add(input);
                Node intermediate = new Node(random.NextDouble());
                Nodes.Add(intermediate);
                // TODO: Should this be bidirectional?
                new Edge(input, intermediate);
                // Bidirectional connection
                new Edge(intermediate, _painNode);
                new Edge(_painNode, intermediate);
            }
            
            // Add the move outputs to the graph as well
            foreach(Node output in _moveOutputs)
            {
                Nodes.Add(output);
            }
        }

        public Node GetPleasureNode()
        {
            return _pleasureNode;
        }

        public Node GetPainNode()
        {
            return _painNode;
        }
    }
}