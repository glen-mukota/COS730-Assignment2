using System;
using System.Collections.Generic;

namespace Assignment2_Optimized
{
    /// <summary>
    /// Orchestrates the evaluation workflow: scoring, aggregation, decision, and notification.
    /// </summary>
    internal class EvaluationManager
    {
        private Database database = new Database();
        private DecisionEngine decisionEngine = new DecisionEngine();
        private NotificationService notificationService = new NotificationService();

        public void StartEvaluation(List<Reviewer> reviewers)
        {
            var scores = new List<int>(reviewers.Count);

            foreach (var reviewer in reviewers)
            {
                int score = reviewer.SubmitScore();
                database.SaveScore(score);
                scores.Add(score);
            }

            double averageScore = CalculateAverage(scores);
            bool consensus = CheckConsensus(scores);
            string outcome = decisionEngine.EvaluateDecision(averageScore, consensus);

            // Dispatch notification based on outcome.
            switch (outcome)
            {
                case "Accepted":
                    notificationService.NotifyAcceptance();
                    break;
                case "Rejected":
                    notificationService.NotifyRejection();
                    break;
                case "Revision":
                    notificationService.NotifyRevision();
                    break;
            }
        }

        private double CalculateAverage(List<int> scores)
        {
            if (Program.EnableLogging)
                Console.WriteLine("Calculating average...");

            double sum = 0;
            foreach (var s in scores)
                sum += s;
            return sum / scores.Count;
        }

        private bool CheckConsensus(List<int> scores)
        {
            if (Program.EnableLogging)
                Console.WriteLine("Checking consensus...");

            // Placeholder: implement variance or agreement threshold in production.
            return true;
        }
    }
}