using System;
using System.Collections.Generic;

namespace Assignment2_Optimized
{
    /// <summary>
    /// Selects reviewers by applying conflict‑of‑interest and workload checks in a single pass.
    /// </summary>
    internal class ReviewerManager
    {
        private Database database = new Database();

        public List<Reviewer> GetEligibleReviewers()
        {
            List<Reviewer> reviewers = database.FetchReviewers();

            // Single consolidated filtering step (conflict + workload).
            reviewers = FilterEligibleReviewers(reviewers);

            return reviewers;
        }

        private List<Reviewer> FilterEligibleReviewers(List<Reviewer> reviewers)
        {
            if (Program.EnableLogging)
                Console.WriteLine("Filtering eligible reviewers (combined conflict + workload check)...");

            var eligible = new List<Reviewer>(reviewers.Count);

            foreach (var reviewer in reviewers)
            {
                bool hasConflict = CheckConflict(reviewer);
                bool withinWorkload = CheckWorkload(reviewer);

                if (!hasConflict && withinWorkload)
                    eligible.Add(reviewer);
            }

            return eligible;
        }

        private bool CheckConflict(Reviewer reviewer)
        {
            // Placeholder: perform actual conflict checks in a real system.
            return false;
        }

        private bool CheckWorkload(Reviewer reviewer)
        {
            // Placeholder: verify reviewer’s current load against capacity.
            return true;
        }
    }
}