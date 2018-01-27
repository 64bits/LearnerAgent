using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LearnerAgent
{
    /// <summary>
    /// Represents a node in the knowledge graph, which in turn represents some concept. Each node has linkes to
    /// several different nodes, as well as a weight that corresponds to the amount of attention that node has, at
    /// the moment.
    /// </summary>
    public class Node
    {
        private float attention;
        public float Attention
        {
            get => attention;
            set
            {
                //float c = (float) (2 / (1 + Math.Exp(-2 * value))) - 1;
                attention = value < 0 ? 0 : value;
            }
        }

        public List<Edge> Edges { get; }
        
        public Node(double originalValue)
        {
            // We can start off with a random amount of attention > 0
            Attention = (float) originalValue;
            Edges = new List<Edge>();
        }

        /// <summary>
        /// Finds out whether this node is connected to a given node
        /// </summary>
        /// <returns></returns>
        public bool ConnectedTo(Node other)
        {
            foreach (Edge edge in Edges)
            {
                if (edge.Nodes.Contains(other))
                {
                    return true;
                }
            }

            return false;
        }
    }
}