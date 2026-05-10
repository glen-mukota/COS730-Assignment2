using System;

namespace Assignment2_Optimized
{
    /// <summary>
    /// Implements the centralised decision logic derived from Task 3 decision table.
    /// Follows Information Expert principle (Kung, 2024, Section 6.3).
    /// </summary>
    internal class DecisionEngine
    {
        // Threshold value from decision table (C2: Average score ≥ threshold)
        private const double THRESHOLD = 7.0;

        /// <summary>
        /// Evaluates the outcome based on average score and consensus.
        /// Maps directly to decision table rules R2, R3, R4, R5.
        /// </summary>
        /// <param name="averageScore">Calculated average score from reviewers</param>
        /// <param name="consensusAchieved">Whether reviewers reached consensus</param>
        /// <returns>Outcome string: "Accepted", "Rejected", or "Revision"</returns>
        public string EvaluateDecision(double averageScore, bool consensusAchieved)
        {
            Console.WriteLine("Evaluating decision...");

            // R2: High score + consensus → Accept
            if (averageScore >= THRESHOLD && consensusAchieved)
                return "Accepted";

            // R3: Low score + consensus → Reject
            if (averageScore < THRESHOLD && consensusAchieved)
                return "Rejected";

            // R4: High score + NO consensus → Revise
            if (averageScore >= THRESHOLD && !consensusAchieved)
                return "Revision";

            // R5: Low score + NO consensus → Reject (else/default case)
            return "Rejected";
        }
    }
}