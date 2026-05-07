using System;

namespace Assignment2_Baseline
{
    internal class UI
    {
        private SubmissionController controller = new SubmissionController();

        public void SubmitResearchOutput(string data)
        {
            // submit(data)
            controller.Submit(data);
        }

        public void ReturnError()
        {
            Console.WriteLine("Error: Invalid submission");
        }
    }
}