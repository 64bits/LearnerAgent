using System;

namespace LearnerAgent
{
    public class Edge
    {
        private float strength;
        public float Strength
        {
            get => strength;
            set { strength = Math.Clamp(value, 0.001f, 1f); }
        }

        public Node[] Nodes { get; set; }

        /// <summary>
        /// Creates a bidirectional edge between the first and second nodes
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        public Edge(Node first, Node second)
        {
            Strength = 0.5f;
            Nodes = new Node[]
            {
                first,
                second
            };
            first.Edges.Add(this);
            second.Edges.Add(this);
        }
    }
}