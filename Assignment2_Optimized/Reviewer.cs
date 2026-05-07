using System;

namespace Assignment2_Optimized
{
    internal class Reviewer
    {
        public void AssignReview()
        {
            Console.WriteLine("Review assigned");
        }

        public int SubmitScore()
        {
            Console.WriteLine("Submitting score...");
            return new Random().Next(1, 10);
        }
    }
}