using System;

namespace Assignment2_Optimized
{
    internal class Validator
    {
        public bool ValidateFormat(string data)
        {
            if (Program.EnableLogging)
                Console.WriteLine("Validating format...");

            return !string.IsNullOrEmpty(data);
        }
    }
}