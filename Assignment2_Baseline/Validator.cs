using System;

namespace Assignment2_Baseline
{
    /// <summary>
    /// Validates research output submissions.
    /// </summary>
    internal class Validator
    {
        /// <summary>
        /// Checks that the submission data is not null or empty.
        /// </summary>
        /// <param name="data">The raw submission string to validate.</param>
        /// <returns>True if the data is considered valid; otherwise false.</returns>
        public bool ValidateFormat(string data)
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Validating format...");
            }

            return !string.IsNullOrEmpty(data);
        }
    }
}