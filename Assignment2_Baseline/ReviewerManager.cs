using System;
using System.Collections.Generic;

namespace Assignment2_Baseline
{
    /// <summary>
    /// Manages the selection and preparation of reviewers before evaluation.
    /// </summary>
    internal class ReviewerManager
    {
        private Database database = new Database();

        /// <summary>
        /// Fetches all available reviewers, filters conflicts, and checks workload.
        /// </summary>
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

            return reviewers; // Currently no filtering is implemented.
        }

        public List<Reviewer> CheckWorkload(List<Reviewer> reviewers)
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Checking workload...");
            }

            return reviewers; // Currently no workload check is implemented.
        }
    }
}