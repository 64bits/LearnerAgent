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
            
            // Create a pleasure node and connect pleasure inputs with one degree of separation
            
            // Create a pin node and connect pain inputs with one degree of separation
        }

        public Node GetPleasureNode()
        {
            return null;
        }

        public Node GetPainNode()
        {
            return null;
        }
    }
}