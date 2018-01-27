using System;
using System.Collections.Generic;
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
                float c = (float) (2 / (1 + Math.Exp(-2 * value))) - 1;
                attention = c < 0 ? 0 : c;
            }
        }

        public List<Edge> Edges { get; }
        
        public Node(double originalValue)
        {
            // We can start off with a random amount of attention > 0
            Attention = (float) originalValue;
            Edges = new List<Edge>();
        }
    }
}