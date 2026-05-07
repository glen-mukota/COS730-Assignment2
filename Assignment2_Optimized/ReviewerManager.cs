using System;
using System.Collections.Generic;

namespace Assignment2_Optimized
{
    /// <summary>
    /// Consolidated reviewer filtering – single pass instead of three separate traversals.
    /// Implements high cohesion (Kung Section 6.3.5) and reduces chatty interactions.
    /// </summary>
    internal class ReviewerManager
    {
        private Database database = new Database();

        public List<Reviewer> GetEligibleReviewers()
        {
            // Fetch all reviewers from persistence
            List<Reviewer> reviewers = database.FetchReviewers();

            // Single consolidated filtering operation (replaces fetch -> filter conflicts -> check workload)
            reviewers = FilterEligibleReviewers(reviewers);

            return reviewers;
        }

        /// <summary>
        /// Applies all eligibility criteria in one pass.
        /// </summary>
        private List<Reviewer> FilterEligibleReviewers(List<Reviewer> reviewers)
        {
            Console.WriteLine("Filtering eligible reviewers (combined conflict + workload check)...");

            List<Reviewer> eligible = new List<Reviewer>();

            foreach (var reviewer in reviewers)
            {
                // Check conflict-of-interest (simplified demonstration)
                bool hasConflict = CheckConflict(reviewer);
                // Check workload capacity (simplified demonstration)
                bool withinWorkload = CheckWorkload(reviewer);

                if (!hasConflict && withinWorkload)
                    eligible.Add(reviewer);
            }

            return eligible;
        }

        private bool CheckConflict(Reviewer reviewer)
        {
            // In a real system: query database, check affiliations, etc.
            // Placeholder for demonstration
            return false;
        }

        private bool CheckWorkload(Reviewer reviewer)
        {
            // In a real system: count assigned reviews, compare to max capacity
            // Placeholder for demonstration
            return true;
        }
    }
}