namespace LearnerAgent
{
    public class Edge
    {
        public float Strength { get; set; }

        public Node To { get; set; }

        /// <summary>
        /// Creates a directional edge from the first node to the second node
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        public Edge(Node first, Node second)
        {
            Strength = 1f;
            To = second;
            first.Edges.Add(this);
        }
    }
}