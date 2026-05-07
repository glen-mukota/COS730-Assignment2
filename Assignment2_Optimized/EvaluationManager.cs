using System;
using System.Collections.Generic;

namespace Assignment2_Optimized
{
    /// <summary>
    /// Responsible for score aggregation only (High Cohesion – Kung Section 6.3.5).
    /// Decision logic removed and delegated to DecisionEngine.
    /// </summary>
    internal class EvaluationManager
    {
        private Database database = new Database();
        private DecisionEngine decisionEngine = new DecisionEngine();

        public void StartEvaluation(List<Reviewer> reviewers)
        {
            List<int> scores = new List<int>();

            // Loop each reviewer (as per optimised sequence diagram)
            foreach (var reviewer in reviewers)
            {
                int score = reviewer.SubmitScore();
                database.SaveScore(score);
                scores.Add(score);
            }

            // Calculate metrics (responsibility of EvaluationManager)
            double averageScore = CalculateAverage(scores);
            bool consensusAchieved = CheckConsensus(scores);

            // Delegate decision outcome to DecisionEngine (pure fabrication)
            string outcome = decisionEngine.EvaluateDecision(averageScore, consensusAchieved);

            // Trigger notification based on outcome (matches sequence diagram alt fragment)
            NotificationService notificationService = new NotificationService();
            if (outcome == "Accepted")
                notificationService.NotifyAcceptance();
            else if (outcome == "Rejected")
                notificationService.NotifyRejection();
            else if (outcome == "Revision")
                notificationService.NotifyRevision();
        }

        private double CalculateAverage(List<int> scores)
        {
            Console.WriteLine("Calculating average...");
            double sum = 0;
            foreach (var s in scores)
                sum += s;
            return sum / scores.Count;
        }

        private bool CheckConsensus(List<int> scores)
        {
            Console.WriteLine("Checking consensus...");
            // For demonstration – in real system this would check variance, etc.
            return true;
        }
    }
}