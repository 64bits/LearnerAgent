using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;

namespace LearnerAgent
{
    public class Utilities
    {
        private Graph _knowledgeGraph;
        // TODO: This should be calculated using an S-curve or a ReLu
        private float ATTENTION_THRESHOLD = 0.01f;
        private List<Edge> _visited;
        
        public Utilities(Graph knowledgeGraph)
        {
            _knowledgeGraph = knowledgeGraph;
        }
        
        /// <summary>
        /// Delete and recreate the attention node, based on attention thresholds - this must happen before the
        /// recalculations happen
        /// </summary>
        public void RecalculateAttention()
        {
            
        }
        
        /// <summary>
        /// Look at the graph and determine whether the attention threshold on the flagella is enough to cause
        /// the agent to move - and then move it!
        /// </summary>
        public void MoveAgent()
        {
            Node[] outputs = _knowledgeGraph.GetMoveOutputs();
            Console.WriteLine(outputs[0].Attention + "," + outputs[1].Attention + "," + outputs[2].Attention + "," + outputs[3].Attention);
            MyGame.Y += outputs[0].Attention * 100;
            MyGame.X += outputs[1].Attention * 100;
            MyGame.Y -= outputs[2].Attention * 100;
            MyGame.X -= outputs[3].Attention * 100;
        }

        /// <summary>
        /// Look at the graph and create connections between nodes that are above attention threshold, with one
        /// degree of separation
        /// </summary>
        public void CreateConnections()
        {
            List<Node> attentionNodes = new List<Node>();
            foreach (Node node in _knowledgeGraph.Nodes)
            {
                if (node.Attention >= ATTENTION_THRESHOLD)
                {
                    attentionNodes.Add(node);
                }
            }

            foreach (Node first in attentionNodes)
            {
                foreach (Node second in attentionNodes)
                {
                    if (!first.ConnectedTo(second))
                    {
                        new Edge(first, second);
                    }
                }
            }
        }

        /// <summary>
        /// Increase the strength of edges that connect to the pleasure node, based on attention threshold
        /// </summary>
        public void WidenPipes()
        {
            // Perform a breadth first search outwards, increasing pipe strengths as we go
            _visited = new List<Edge>();
            WidenPipesHelper(_knowledgeGraph.GetPleasureNode(), 1);
        }

        void WidenPipesHelper(Node current, int distance)
        {
            if (distance >= 3) return;
            foreach (Edge edge in current.Edges)
            {
                if (!_visited.Contains(edge))
                {
                    edge.Strength += (1 / distance) * 0.25f;
                    _visited.Add(edge);
                    WidenPipesHelper(edge.GetOther(current), distance+1);
                }
            }
        }

        /// <summary>
        /// Decrease the strength of the edges that connect to the pain node, based on attention threshold
        /// </summary>
        public void ConstrictPipes()
        {
            // Perform a breadth first search outwards, decreasing pipe strengths as we go
            _visited = new List<Edge>();
            WidenPipesHelper(_knowledgeGraph.GetPainNode(), 1);
        }
        
        void ConstrictPipesHelper(Node current, int distance)
        {
            if (distance >= 3) return;
            foreach (Edge edge in current.Edges)
            {
                if (!_visited.Contains(edge))
                {
                    edge.Strength -= (1 / distance) * 0.25f;
                    _visited.Add(edge);
                    WidenPipesHelper(edge.GetOther(current), distance+1);
                }
            }
        }

        /// <summary>
        /// Propagates attention values throughout the graph as needed
        /// </summary>
        public void PropagateAttention()
        {
            foreach (Node node in _knowledgeGraph.Nodes)
            {
                foreach (Edge edge in node.Edges)
                {
                    // Find the delta of the two nodes connected by this edge, then move a factor of that from the
                    // more attended node to the less attended node
                    float delta = edge.Nodes[0].Attention - edge.Nodes[1].Attention;
                    float toMove = delta * edge.Strength;
                    edge.Nodes[0].Attention -= toMove;
                    edge.Nodes[1].Attention += toMove;
                }
            }
        }

        /// <summary>
        /// Attention diminishes over time
        /// </summary>
        public void DiminishAttention()
        {
            foreach (Node node in _knowledgeGraph.Nodes)
            {
                node.Attention -= 0.1f;
            }
        }

        /// <summary>
        /// Randomly modifies the values of attention, in hopes to eventually connect all islands together
        /// </summary>
        public void GenerateNoise()
        {
            // Only generate noise in the movement nodes, not in the knowledge graph
            foreach (Node node in _knowledgeGraph.GetMoveOutputs())
            {
                node.Attention += (float) _knowledgeGraph.GetRandomNoise();
            }
        }
    }
}