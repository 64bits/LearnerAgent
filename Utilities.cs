namespace LearnerAgent
{
    public class Utilities
    {
        private Graph _knowledgeGraph;
        // TODO: This should be calculated using an S-curve or a ReLu
        private float ATTENTION_THRESHOLD = 0.25f;
        
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
            
        }

        /// <summary>
        /// Look at the graph and create connections between nodes that are above attention threshold, with one
        /// degree of separation
        /// </summary>
        public void CreateConnections()
        {
            
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
            
        }

        /// <summary>
        /// Attention diminishes over time
        /// </summary>
        public void DiminishAttention()
        {
            
        }

        /// <summary>
        /// Randomly modifies the values of attention, in hopes to eventually connect all islands together
        /// </summary>
        public void GenerateNoise()
        {
            
        }
    }
}