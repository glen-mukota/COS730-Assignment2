using System;
using System.Collections.Generic;

namespace Assignment2_Baseline
{
    /// <summary>
    /// Simulates a database for storing submissions and reviewer information.
    /// </summary>
    internal class Database
    {
        public void SaveSubmission(string data)
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Saving submission...");
            }
        }

        /// <summary>
        /// Retrieves a fixed list of reviewer objects.
        /// </summary>
        public List<Reviewer> FetchReviewers()
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Fetching reviewers...");
            }

            return new List<Reviewer>
            {
                new Reviewer(),
                new Reviewer()
            };
        }

        public void SaveScore(int score)
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Saving score: " + score);
            }
        }
    }
}