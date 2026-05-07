using System;
using System.Collections.Generic;

namespace Assignment2_Baseline
{
    internal class ReviewerManager
    {
        private Database database = new Database();

        public List<Reviewer> GetAvailableReviewers()
        {
            List<Reviewer> reviewers = database.FetchReviewers();

            reviewers = FilterConflicts(reviewers);
            reviewers = CheckWorkload(reviewers);

            return reviewers;
        }

        public List<Reviewer> FilterConflicts(List<Reviewer> reviewers)
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Filtering conflicts...");
            }

            return reviewers;
        }

        public List<Reviewer> CheckWorkload(List<Reviewer> reviewers)
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Checking workload...");
            }

            return reviewers;
        }
    }
}