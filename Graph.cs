using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace LearnerAgent
{
    public class Graph
    {
        private List<Node> Nodes { get; set; }

        public Graph()
        {
            Nodes = new List<Node>();
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