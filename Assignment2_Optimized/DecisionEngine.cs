using System;

namespace Assignment2_Optimized
{
    /// <summary>
    /// Centralised decision logic based on average score and consensus.
    /// </summary>
    internal class DecisionEngine
    {
        private const double AcceptanceThreshold = 7.0;

        /// <summary>
        /// Determines the evaluation outcome (Accepted, Rejected, or Revision).
        /// </summary>
        public string EvaluateDecision(double averageScore, bool consensusAchieved)
        {
            if (Program.EnableLogging)
                Console.WriteLine("Evaluating decision...");

            if (averageScore >= AcceptanceThreshold && consensusAchieved)
                return "Accepted";
            if (averageScore < AcceptanceThreshold && consensusAchieved)
                return "Rejected";
            if (averageScore >= AcceptanceThreshold && !consensusAchieved)
                return "Revision";

            return "Rejected"; // low score, no consensus
        }
    }
}