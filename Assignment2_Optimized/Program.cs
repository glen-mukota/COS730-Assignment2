using System;

namespace Assignment2_Optimized
{
    internal class Program
    {
        /// <summary>
        /// Global flag used to suppress diagnostic console output during benchmarks.
        /// </summary>
        public static bool EnableLogging { get; set; } = true;

        static void Main(string[] args)
        {
            // The benchmark runner disables logging before measuring.
            BenchmarkRunner.Run();

            Console.WriteLine("\nBenchmark complete. Press Enter to exit...");
            Console.ReadLine();
        }
    }
}