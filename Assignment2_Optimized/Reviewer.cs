using System;

namespace Assignment2_Optimized
{
    internal class Reviewer
    {
        private static readonly Random RandomScoreGenerator = new Random();

        public void AssignReview()
        {
            if (Program.EnableLogging)
                Console.WriteLine("Review assigned");
        }

        public int SubmitScore()
        {
            if (Program.EnableLogging)
                Console.WriteLine("Submitting score...");

            return RandomScoreGenerator.Next(1, 10);
        }
    }
}