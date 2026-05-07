using System;
using System.Collections.Generic;

namespace Assignment2_Baseline
{
    internal class EvaluationManager
    {
        private Database database = new Database();
        private NotificationService notificationService = new NotificationService();

        public void StartEvaluation(List<Reviewer> reviewers)
        {
            List<int> scores = new List<int>();

            foreach (var reviewer in reviewers)
            {
                int score = reviewer.SubmitScore();
                database.SaveScore(score);
                scores.Add(score);
            }

            double avg = CalculateAverage(scores);
            bool consensus = CheckConsensus(scores);
            string result = ApplyRules(avg, consensus);

            if (result == "accepted")
            {
                notificationService.NotifyAcceptance();
            }
            else if (result == "rejected")
            {
                notificationService.NotifyRejection();
            }
            else
            {
                notificationService.NotifyRevision();
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

            return true;
        }

        public string ApplyRules(double avg, bool consensus)
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Applying rules...");
            }

            if (avg > 7 && consensus)
                return "accepted";

            if (avg < 4)
                return "rejected";

            return "revision";
        }
    }
}