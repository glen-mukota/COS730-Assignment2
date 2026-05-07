using System;
using System.Collections.Generic;

namespace Assignment2_Optimized
{
    internal class DecisionEngine
    {
        private NotificationService notificationService = new NotificationService();

        public void EvaluateOutcome(List<int> scores)
        {
            double avg = CalculateAverage(scores);
            bool consensus = CheckConsensus(scores);

            string result = ApplyRules(avg, consensus);

            // Trigger outcome (matches sequence diagram alt fragment)
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

        private double CalculateAverage(List<int> scores)
        {
            Console.WriteLine("Calculating average...");

            double sum = 0;
            foreach (var s in scores)
            {
                sum += s;
            }

            return sum / scores.Count;
        }

        private bool CheckConsensus(List<int> scores)
        {
            Console.WriteLine("Checking consensus...");
            return true;
        }

        private string ApplyRules(double avg, bool consensus)
        {
            Console.WriteLine("Applying rules...");

            if (avg > 7 && consensus)
                return "accepted";

            if (avg < 4)
                return "rejected";

            return "revision";
        }
    }
}
