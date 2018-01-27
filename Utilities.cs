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
            if (outputs[0].Attention > ATTENTION_THRESHOLD)
            {
                MyGame.Y += 1;
            }
            if (outputs[1].Attention > ATTENTION_THRESHOLD)
            {
                MyGame.X += 1;
            }
            if (outputs[2].Attention > ATTENTION_THRESHOLD)
            {
                MyGame.Y -= 1;
            }
            if (outputs[3].Attention > ATTENTION_THRESHOLD)
            {
                MyGame.X -= 1;
            }
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
                    // TODO: I'm just connecting directly for now, later might need an indirection
                    if (first.Edges.TrueForAll((edge) => edge.To != second))
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
            
        }

        /// <summary>
        /// Decrease the strength of the edges that connect to the pain node, based on attention threshold
        /// </summary>
        public void ConstrictPipes()
        {
            
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
                    edge.To.Attention += (node.Attention * 0.25f) * edge.Strength;
                    node.Attention -= (node.Attention * 0.25f) * edge.Strength;
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
            foreach (Node node in _knowledgeGraph.Nodes)
            {
                node.Attention += (float) _knowledgeGraph.GetRandomNoise();
            }
        }
    }
}