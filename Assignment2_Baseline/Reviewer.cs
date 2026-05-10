using System;

namespace Assignment2_Baseline
{
    /// <summary>
    /// Represents a reviewer who assigns a random review score.
    /// </summary>
    internal class Reviewer
    {
        // Reuse a single Random instance to avoid creation overhead during repeated scoring.
        private static readonly Random RandomScorer = new Random();

        public void AssignReview()
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Review assigned");
            }
        }

        /// <summary>
        /// Submits a random score between 1 and 10 (inclusive).
        /// </summary>
        public int SubmitScore()
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Submitting score...");
            }

            return RandomScorer.Next(1, 10);
        }
    }
}