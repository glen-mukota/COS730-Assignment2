using System;

namespace Assignment2_Baseline
{
    /// <summary>
    /// Provides the user‑facing entry point for submitting research output.
    /// </summary>
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
            {
                Console.WriteLine("Error: Submission failed");
            }
        }
    }
}