using System;
using System.Collections.Generic;

namespace Assignment2_Optimized
{
    internal class Database
    {
        public void SaveSubmission(string data)
        {
            if (Program.EnableLogging)
                Console.WriteLine("Saving submission...");
        }

        public List<Reviewer> FetchReviewers()
        {
            if (Program.EnableLogging)
                Console.WriteLine("Fetching reviewers...");

            return new List<Reviewer>
            {
                new Reviewer(),
                new Reviewer()
            };
        }

        public void SaveScore(int score)
        {
            if (Program.EnableLogging)
                Console.WriteLine("Saving score: " + score);
        }
    }
}