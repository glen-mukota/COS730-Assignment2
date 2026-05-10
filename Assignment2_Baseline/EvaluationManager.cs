using System;
using System.Collections.Generic;

namespace Assignment2_Baseline
{
    /// <summary>
    /// Coordinates the evaluation process: collects scores, calculates average,
    /// checks consensus, applies decision rules, and triggers appropriate notifications.
    /// </summary>
    internal class EvaluationManager
    {
        private Database database = new Database();
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

            double average = CalculateAverage(scores);
            bool consensus = CheckConsensus(scores);
            string decision = ApplyRules(average, consensus);

            switch (decision)
            {
                case "accepted":
                    notificationService.NotifyAcceptance();
                    break;
                case "rejected":
                    notificationService.NotifyRejection();
                    break;
                default:
                    notificationService.NotifyRevision();
                    break;
            }
        }

        public double CalculateAverage(List<int> scores)
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Calculating average...");
            }

            double sum = 0;
            foreach (var s in scores)
            {
                sum += s;
            }

            return sum / scores.Count;
        }

        public bool CheckConsensus(List<int> scores)
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Checking consensus...");
            }

            // Placeholder: real consensus logic would examine score variance.
            return true;
        }

        public string ApplyRules(double average, bool consensus)
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Applying rules...");
            }

            if (average > 7 && consensus)
                return "accepted";

            if (average < 4)
                return "rejected";

            return "revision";
        }
    }
}