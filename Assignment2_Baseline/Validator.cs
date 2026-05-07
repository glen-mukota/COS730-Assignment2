using System;

namespace Assignment2_Baseline
{
    internal class Validator
    {
        public bool ValidateFormat(string data)
        {
            Console.WriteLine("Validating format...");
            return !string.IsNullOrEmpty(data);
        }
    }
}