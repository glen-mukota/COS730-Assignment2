using System;

namespace Assignment2_Optimized
{
    internal class UI
    {
        private SubmissionController controller = new SubmissionController();

        public void SubmitResearchOutput(string data)
        {
            controller.Submit(data);
        }

        public void ReturnError()
        {
            if (Program.EnableLogging)
                Console.WriteLine("Error: Invalid submission");
        }
    }
}