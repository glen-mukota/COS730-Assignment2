using Assignment2_Optimised;
using System;

namespace Assignment2_Optimized
{
    internal class Program
    {
        // Global flag to enable/disable console logging (for accurate benchmarking)
        public static bool EnableLogging { get; set; } = true;

        static void Main(string[] args)
        {
            // Run benchmark (logging automatically disabled inside benchmark)
            BenchmarkRunner.Run();

            Console.WriteLine("\nBenchmark complete. Press Enter to exit...");
            Console.ReadLine();
        }
    }
}